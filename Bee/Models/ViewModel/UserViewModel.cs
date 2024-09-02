using Microsoft.AspNetCore.Mvc.Rendering;
using Bee.Pagination;

namespace Bee.Models.ViewModel
{
    public class UserViewModel
    {
        public PaginatedList<ApplicationUser> UsersList { get; set; }
        public SelectList Type { get; set; }
        public Department DepartmentType { get; set; }
        public string CurrentFilter { get; set; }
        public Dictionary<string, IList<string>> UserRoles { get; set; }
        public ApplicationUser User { get; set; }
    }
}
