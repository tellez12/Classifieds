using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classifieds.WebUI.ViewModels
{
    public class ItemViewModel
    {
        public int ItemType { get; set; }

        public SelectList ItemTypeSelect { get; set; }

            private IUnitOfWork unitOfWork;

            public void SetRepositories(IUnitOfWork myUnitOfWork)
        {
            unitOfWork = myUnitOfWork;
        }

            public ItemViewModel(IUnitOfWork myUnitOfWork)
        {
            SetRepositories( myUnitOfWork);
            FillSelectList();
        }

        private void FillSelectList()
        {
            //SectionSelect = new SelectList(unitOfWork.SectionRepository.Get().ToList(), "Id", "Name", SectionId);
            ItemTypeSelect = new SelectList(unitOfWork.ItemTypeRepository.Get().ToList(), "Id", "Name");
            
        }
    }
}