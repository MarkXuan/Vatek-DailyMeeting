using Abp.Authorization;
using Abp.UI;
using DailyMeeting.APIs.Dailies.Dto;
using DailyMeeting.Authorization;
using DailyMeeting.Entities;
using DailyMeeting.Extension;
using DailyMeeting.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Dailies
{
    [AbpAuthorize(PermissionNames.Pages_Dailies)]
    public class DailyAppService : DailyMeetingAppServiceBase
    {
        [HttpPost]
        public async Task<DailyDto> Create(DailyDto input)
        {
            var isExist = await WorkScope.GetAll<Daily>().AnyAsync(s => s.Date == input.Date && s.ProjectId == input.ProjectId);
            //if (isExist)
            //{
            //    throw new UserFriendlyException(string.Format("You have daily in this project"));
            //}
            var daily = ObjectMapper.Map<Daily>(input);
            daily.UserId = AbpSession.UserId.Value;
            input.Id = await WorkScope.InsertAndGetIdAsync(daily);
            return input;
        }

        [HttpPut]
        public async Task<DailyDto> Update(DailyDto input)
        {
            //var isExist = await WorkScope.GetAll<Daily>().AnyAsync(s => s.Date == input.Date && s.ProjectId == input.ProjectId && s.Id != input.Id);
            //if (isExist)
            //{
            //    throw new UserFriendlyException(string.Format("You have daily in this project"));
            //}
            var daily = await WorkScope.GetAsync<Daily>(input.Id);
            if (daily == null)
            {
                throw new UserFriendlyException(string.Format("Your daily is not exist"));
            }
            ObjectMapper.Map<DailyDto, Daily>(input, daily);
            await WorkScope.UpdateAsync(daily);
            return input;
        }

        [HttpDelete]
        public async Task Delete(long id)
        {
            var daily = await WorkScope.GetAsync<Daily>(id);
            if (daily == null)
            {
                throw new UserFriendlyException(string.Format("Not found your daily"));
            }
            await WorkScope.DeleteAsync<Daily>(id);
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectDailyDto>> GetAll(GetDailyInput input)
        {
            return (WorkScope.GetAll<Daily>()
                .Where(s => s.Date <= input.EndDate && s.Date >= input.StartDate)
                .Where(s => s.ProjectId == input.ProjectId)
                .Include(s => s.User)
                .Include(s => s.Project)
                .AsEnumerable()
                .Select(s => new
                {
                    s.Id,
                    s.User.AvatarPath,
                    s.User.Surname,
                    s.User.Name,
                    s.UserId,
                    s.ProjectId,
                    ProjectName = s.Project.Name,
                    s.Content,
                    s.Date,
                    s.CreationTime,
                    IsEdit = s.LastModificationTime.HasValue
                })).GroupBy(s => new { s.ProjectId, s.Date, s.ProjectName })
                .Select(p => new ProjectDailyDto
                {
                    Date = p.Key.Date,
                    ProjectId = p.Key.ProjectId,
                    ProjectName = p.Key.ProjectName,
                    Details = p.Select(s => new DailyDetailDto
                    {
                        Id = s.Id,
                        AvatarPath = s.AvatarPath,
                        Surname = s.Surname,
                        Name = s.Name,
                        UserId = s.UserId,
                        Content = s.Content,
                        CreationTime = s.CreationTime,
                        IsEdit = s.IsEdit
                    }).ToList()
                }).ToList();
        }
    }
}
