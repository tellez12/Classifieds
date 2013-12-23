using System;

namespace Classifieds.WebUI.ViewModels.Shared
{
    public class PagingInfo
    {
        private const int DefaultItemsPerPage = 20;

        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public PagingInfo(int totalItems, int currentPage, int itemsPerPage = DefaultItemsPerPage)
        {
            TotalItems = TotalItems;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}