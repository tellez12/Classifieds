using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.Domain.Utils;

namespace Classifieds.WebUI.ViewModels
{
    public class ItemViewModel
    {
        public int ItemType { get; set; }

        public FeaturesViewModel[] Feature { get; set; }
        public SelectList ItemTypeSelect { get; set; }

        private IUnitOfWork unitOfWork;

        public void SetRepositories(IUnitOfWork myUnitOfWork)
        {
            unitOfWork = myUnitOfWork;
        }

        public ItemViewModel()
        {

        }
        public ItemViewModel(IUnitOfWork myUnitOfWork)
        {
            SetRepositories(myUnitOfWork);
            FillSelectList();
        }

        private void FillSelectList()
        {
            //SectionSelect = new SelectList(unitOfWork.SectionRepository.Get().ToList(), "Id", "Name", SectionId);
            ItemTypeSelect = new SelectList(unitOfWork.ItemTypeRepository.Get().ToList(), "Id", "Name");
        }

        internal Item ToModel()
        {
            var item = new Item
            {
                Type = unitOfWork.ItemTypeRepository.GetById(ItemType),
                Features = GetFeatures()
            };

            return item;
        }

        private List<Feature> GetFeatures()
        {
            var list = new List<Feature>();
            foreach (var feature in Feature)
            {
                var temp = new Feature
                {
                    StringValue = feature.Value,
                    FeatureType = GetFeatureType(feature.Id)
                };
                if (temp.FeatureType.ControlType == ControlType.DropDown)
                {
                    temp.Value = GetFeatureTypeValue(feature.Value);
                }
                else
                {
                    temp.StringValue = feature.Value;
                }
                list.Add(temp);
            }

            return list;

        }

        private FeatureTypeValue GetFeatureTypeValue(string id)
        {
            return unitOfWork.FeatureTypeValueRepository.GetById(int.Parse(id));
        }

        private FeatureType GetFeatureType(string id)
        {
            return unitOfWork.FeatureTypeRepository.GetById(int.Parse(id));
        }
    }

    public class FeaturesViewModel
    {
        public String Id { get; set; }

        public String Value { get; set; }

    }
}