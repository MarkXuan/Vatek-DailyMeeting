using Abp.Authorization;
using Abp.UI;
using AutoMapper.QueryableExtensions;
using DailyMeeting.APIs.Customers.Dto;
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

namespace DailyMeeting.APIs.Customers
{
    [AbpAuthorize(PermissionNames.Pages_Customers)]
    public class CustomerAppService : DailyMeetingAppServiceBase
    {
        [HttpPost]
        public async Task<CustomerDto> Create(CustomerDto input)
        {
            var isExist = await WorkScope.GetAll<Customer>().AnyAsync(s => s.FullName == input.FullName);
            if (isExist)
            {
                throw new UserFriendlyException(string.Format("Customer name already exist"));
            }
            var customer = ObjectMapper.Map<Customer>(input);
            input.Id = await WorkScope.InsertAndGetIdAsync(customer);
            return input;
        }

        [HttpPut]
        public async Task<CustomerDto> Update(CustomerDto input)
        {
            var isExist = await WorkScope.GetAll<Customer>().AnyAsync(s => s.FullName == input.FullName && s.Id != input.Id);
            if (isExist)
            {
                throw new UserFriendlyException(string.Format("Customer name already exist"));
            }
            var customer = await WorkScope.GetAsync<Customer>(input.Id);
            ObjectMapper.Map<CustomerDto, Customer>(input, customer);
            await WorkScope.UpdateAsync(customer);
            return input;
        }

        [HttpDelete]
        public async Task Delete(long id)
        {
            var customer = await WorkScope.GetAsync<Customer>(id);
            if (customer == null)
            {
                throw new UserFriendlyException(string.Format("Not found customer"));
            }
            var hasProject = await WorkScope.GetAll<Project>().AnyAsync(s => s.CustomerId == id);
            if (hasProject)
                throw new UserFriendlyException(string.Format("Can not delete Customer when have linked Project"));
            await WorkScope.DeleteAsync<Customer>(id);
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAll()
        {
            return await WorkScope.GetAll<Customer>().Select(s => new CustomerDto
            {
                Id = s.Id,
                Address = s.Address,
                Email = s.Email,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
            }).ToListAsync();
        }
        [HttpGet]
        public async Task<GridResult<CustomerDto>> GetAllPaging(GridParam input)
        {
            var query = WorkScope.GetAll<Customer>().Select(s => new CustomerDto
            {
                Id = s.Id,
                Address = s.Address,
                Email = s.Email,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
            }).OrderBy(s => s.FullName);
            return await query.GetGridResult(query, input);
        }
    }
}
