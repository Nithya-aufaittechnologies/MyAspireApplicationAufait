using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspireApplicationAufait.ApiService.Infrastructure.Entities
{
    public class RoleTest
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ClientId { get; set; }
        public string? RoleName { get; set; }
        public DateTime Date {  get; set; }
    }
}
