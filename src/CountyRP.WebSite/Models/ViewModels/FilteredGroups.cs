using System.Collections.Generic;

using CountyRP.Models;

namespace CountyRP.WebSite.Models.ViewModels
{
    public class FilteredGroups
    {
        public List<Group> Groups { get; set; }
        public int AllAmount { get; set; }
        public int Page { get; set; }
        public int MaxPage { get; set; }
    }
}
