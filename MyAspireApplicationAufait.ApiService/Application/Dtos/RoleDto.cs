using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspireApplicationAufait.AppHost.Domain
{
    public class RoleDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ClientId { get; set; }
        public string? RoleName { get; set; }
    }
}
