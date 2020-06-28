using System.Collections.Generic;

namespace CountyRP.WebAPI.Models.ViewModels
{
    public class FilteredModels<T>
    {
        public List<T> Items { get; set; }
        public int AllAmount { get; set; }
        public int Page { get; set; }
        public int MaxPage { get; set; }
    }
}
