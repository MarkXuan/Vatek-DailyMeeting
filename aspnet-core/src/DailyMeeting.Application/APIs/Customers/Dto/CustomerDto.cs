using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DailyMeeting.Anotations;
using DailyMeeting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Customers.Dto
{
    [AutoMapTo(typeof(Customer))]
    public class CustomerDto : EntityDto<long>
    {
        [ApplySearchAttribute]
        public string FullName { get; set; }
        [ApplySearchAttribute]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
