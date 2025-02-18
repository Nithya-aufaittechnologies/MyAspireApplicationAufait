using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationDbContext;

namespace MyAspireApplicationAufait.ApiService.Infrastructure.Entities
{
    public class RoleTestDI: CommonEntity
    {       
        public string? RoleName { get; set; }
        public DateTime Date {  get; set; }
    }
}
