using Microsoft.AspNetCore.Mvc.Rendering;
using Bee.Pagination;

namespace Bee.Models.ViewModel
{
    public class EventViewModel
    {
        //public PaginatedList<Event> EventsList { get; set; }
        public SelectList Type { get; set; }
        public Company CompanyType { get; set; }
        public string CurrentFilter { get; set; }
    }
}
