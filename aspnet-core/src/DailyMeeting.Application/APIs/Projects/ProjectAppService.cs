using Abp.Authorization;
using Abp.UI;
using DailyMeeting.APIs.Projects.Dto;
using DailyMeeting.Authorization;
using DailyMeeting.Authorization.Users;
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
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.APIs.Projects
{
    [AbpAuthorize(PermissionNames.Pages_Projects)]
    public class ProjectAppService : DailyMeetingAppServiceBase
    {
        [HttpPost]
        public async Task<CreateProjectDto> Create(CreateProjectDto input)
        {
            var isExist = await WorkScope.GetAll<Project>().AnyAsync(s => s.Name == input.Name);
            if (isExist)
            {
                throw new UserFriendlyException(string.Format("Project name already exist"));
            }
             var project = ObjectMapper.Map<Project>(input);
            input.Id = await WorkScope.InsertAndGetIdAsync(project);
            foreach (var puser in input.ProjectUsers)
            {
                var projectUser = new ProjectUser
                {
                    ProjectId = input.Id,
                    UserId = puser.UserId,
                    IsActive = puser.IsActive,
                    Type = puser.Type
                };
                puser.Id = await WorkScope.InsertAndGetIdAsync(projectUser);
            }
            return input;
        }
        [HttpPut]
        public async Task<CreateProjectDto> Update(CreateProjectDto input)
        {
            //update project
            var isExist = await WorkScope.GetAll<Project>().AnyAsync(s => s.Name == input.Name && s.Id != input.Id);
            if (isExist)
            {
                throw new UserFriendlyException(string.Format("Project name already exist"));
            }
            var project = await WorkScope.GetAsync<Project>(input.Id);
            ObjectMapper.Map<CreateProjectDto, Project>(input, project);
            //update projectUser
            var currentUserIds = await WorkScope.GetAll<ProjectUser>().Where(s => s.ProjectId == input.Id).Select(s => s.UserId).ToListAsync();
            var newUserIds = input.ProjectUsers.Select(s => s.UserId).ToList();
            var usersDelete = input.ProjectUsers.Where(s => currentUserIds.Except(newUserIds).Contains(s.Id));
            var usersInsert = input.ProjectUsers.Where(s => newUserIds.Except(currentUserIds).Contains(s.Id));
            var usersUpdate = input.ProjectUsers.Where(s => currentUserIds.Intersect(newUserIds).Contains(s.Id));
            foreach (var puser in usersDelete)
            {
                await WorkScope.DeleteAsync<ProjectUser>(puser.Id);
            }
            foreach (var puser in usersInsert)
            {
                var projectUser = new ProjectUser
                {
                    UserId = puser.UserId,
                    ProjectId = input.Id,
                    IsActive = puser.IsActive,
                    Type = puser.Type
                };
                puser.Id = await WorkScope.InsertAndGetIdAsync(projectUser);
            }
            foreach (var puser in usersUpdate)
            {
                var projectUser = new ProjectUser
                {
                    UserId = puser.UserId,
                    ProjectId = input.Id,
                    IsActive = puser.IsActive,
                    Type = puser.Type
                };
                await WorkScope.UpdateAsync(projectUser);
            }
            return input;
        }
        [HttpDelete]
        public async Task Delete(long id)
        {
            var project = await WorkScope.GetAsync<Project>(id);
            if (project == null)
            {
                throw new UserFriendlyException(string.Format("Not found project"));
            }
            var hasProjectUser = await WorkScope.GetAll<ProjectUser>().AnyAsync(s => s.ProjectId == id);
            if (hasProjectUser)
                throw new UserFriendlyException(string.Format("Can not delete Project when have linked ProjectUser"));
            await WorkScope.DeleteAsync<Project>(id);
        }
        [HttpPost]
        public async Task Active(long id)
        {
            var project = await WorkScope.GetAsync<Project>(id);
            if (project == null)
            {
                throw new UserFriendlyException(string.Format("Not found project"));
            }
            if (project.Status == ProjectStatus.Active)
            {
                project.Status = ProjectStatus.Deactive;
            }
            else
            {
                project.Status = ProjectStatus.Active;
            }
            await WorkScope.UpdateAsync(project);
        }
        [HttpGet]
        public async Task<ProjectDetailDto> GetById(long id)
        {
            return (from p in WorkScope.GetAll<Project>().Include(s => s.Customer).Where(p => p.Id == id).AsEnumerable()
                    join u in WorkScope.GetAll<ProjectUser>().Include(s => s.User).AsEnumerable() on p.Id equals u.ProjectId into pu
                    select new ProjectDetailDto
                    {
                        Id = id,
                        Code = p.Code,
                        Country = p.Country,
                        CustomerId = p.CustomerId,
                        CustomerName = p.Customer.FullName,
                        Description = p.Description,
                        Name = p.Name,
                        ProjectType = p.ProjectType,
                        Status = p.Status,
                        TimeEnd = p.TimeEnd,
                        TimeStart = p.TimeStart,
                        ProjectUsers = pu.Select(p => new ProjectUserDto
                        {
                            Id = p.Id,
                            ProjectId = p.ProjectId,
                            FullNameUser = p.User.FullName,
                            AvatarPath = p.User.AvatarPath,
                            IsActive = p.IsActive,
                            Type = p.Type,
                            UserId = p.UserId
                        }).ToList()
                    }).FirstOrDefault();
        }
        [HttpGet]
        public async Task<GridResult<ProjectDto>> GetAllPaging(GridParam input)
        {
            var query = WorkScope.GetAll<Project>().Select(p => new ProjectDto
            {
                Id = p.Id,
                Code = p.Code,
                Country = p.Country,
                CustomerId = p.CustomerId,
                CustomerName = p.Customer.FullName,
                Description = p.Description,
                Name = p.Name,
                ProjectType = p.ProjectType,
                Status = p.Status,
                TimeEnd = p.TimeEnd,
                TimeStart = p.TimeStart
            }).OrderBy(p => p.Name);
            return await query.GetGridResult(query, input);
        }
    }
}
