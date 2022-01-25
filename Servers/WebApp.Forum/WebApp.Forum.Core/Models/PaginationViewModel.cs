﻿namespace WebApp.Forum.Models
{
    using System;
    public class PaginationViewModel
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string SearchTerm { get; set; }
        public int PageNumber { get; set; }

        public int? CategoryId { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public int PreviousPageNumber => PageNumber - 1;

        public bool HasNextPage => PageNumber < PagesCount;

        public int NextPageNumber => PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)ItemsCount / ItemsPerPage);

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}