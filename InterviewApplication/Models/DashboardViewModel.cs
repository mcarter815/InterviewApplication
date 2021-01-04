using System.Collections.Generic;
using InterviewApplication.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InterviewApplication.UI.Models
{
    public class DashboardViewModel
    {
        public IReadOnlyList<Dashboard> DashboardList { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public int PageSize { get; set; }
        public List<SelectListItem> PageSizeSelectList = new List<SelectListItem>
        {
            new SelectListItem("25", "25"),
            new SelectListItem("50", "50"),
            new SelectListItem("100", "100"),
            new SelectListItem("200", "200")
        };
        public string SearchText { get; set; }
    }
}
