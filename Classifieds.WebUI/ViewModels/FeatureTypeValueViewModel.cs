using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.Domain.Utils;

namespace Classifieds.WebUI.ViewModels
{
    public class FeatureTypeValueViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public String Value { get; set; }

        public SelectList FeatureTypeSelect { get; set; }

        //private IUnitOfWork unitOfWork;
        public FeatureTypeValueViewModel() {  }
        public FeatureTypeValueViewModel(IUnitOfWork unitOfWork)
        {
            //this.unitOfWork = unitOfWork;
            FeatureTypeSelect = new SelectList(unitOfWork.FeatureTypeRepository.Get(t => t.ControlType == ControlType.DropDown ).ToList(), "Id", "Name", TypeId);
            
        }


        internal FeatureTypeValue ToModel()
        {
            var ftv = new FeatureTypeValue
                      {
                          TypeId = this.TypeId, Value = this.Value
                      };

            return ftv;
        }
    }
}