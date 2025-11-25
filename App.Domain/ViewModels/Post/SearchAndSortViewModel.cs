using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Post
{
    public class SearchAndSortViewModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public int SortType { get; set; }
    }
}
