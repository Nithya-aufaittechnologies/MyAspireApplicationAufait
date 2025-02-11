namespace MyAspireApplicationAufait.ApiService.Application.Models
{
    public class RolePermissionDto
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? updatedBy { get; set; }
        public string? roleId { get; set; }
        public string? Permission { get; set; }
        public bool? GrandAccess { get; set; }
        public bool? CanView { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanDelete { get; set; }
    }
}
