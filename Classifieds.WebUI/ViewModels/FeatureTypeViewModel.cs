using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classifieds.WebUI.ViewModels
{
    public class FeatureTypeViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public string RequiredText { get; set; }

        public int ControlType { get; set; }

        public int Order { get; set; }

        public int SectionId { get; set; }
        public int[] ItemTypes { set; get; }
        public SelectList SectionSelect { get; set; }
        public SelectList ControllerTypeSelect { get; set; }
        public SelectList ItemTypeSelect { get; set; }

        public FeatureTypeViewModel() { }

        public FeatureTypeViewModel(FeatureType ft, IFeatureTypeRepository myRepository, ISectionRepository mySectionRepository, IItemTypeRepository myItemTypeRepository)
        {
            Id = ft.Id;
            Name = ft.Name;
            Required = ft.Required;
            RequiredText = ft.RequiredText;
            ControlType = (int)ft.ControlType;
            Order = ft.Order;
            SectionId = ft.Section.Id;
            ItemTypes = getItemTypesId(ft.ItemTypes).ToArray();
            FillSelectList(myRepository, mySectionRepository, myItemTypeRepository);     

        }

        public FeatureTypeViewModel(IFeatureTypeRepository myRepository, ISectionRepository mySectionRepository, IItemTypeRepository myItemTypeRepository)
        {
            FillSelectList(myRepository, mySectionRepository, myItemTypeRepository);
        }

        private void FillSelectList(IFeatureTypeRepository myRepository, ISectionRepository mySectionRepository, IItemTypeRepository myItemTypeRepository)
        {


            SectionSelect = new SelectList(mySectionRepository.GetSections.ToList(), "Id", "Name",SectionId);
            ItemTypeSelect = new SelectList(myItemTypeRepository.GetItemTypes.ToList(), "Id", "Name",ItemTypes);

            var TypeEnumSelect = from ControlType s in Enum.GetValues(typeof(ControlType))
                                 select new { ID = (int)s, Name = s.ToString() };
            ControllerTypeSelect = new SelectList(TypeEnumSelect, "ID", "Name", ControlType);
        }

        private IEnumerable<int> getItemTypesId(IEnumerable<ItemType> list)
        {
            return list.Select(item => item.Id);
        }

        public FeatureType ToModel()
        {
            var ft = new FeatureType
                         {
                             Name = Name,
                             ControlType = (ControlType) ControlType,
                             Order = Order,
                             Required = Required,
                             RequiredText = RequiredText,
                             ItemTypes = GetItemTypes(),
                             Section =  new Section{Id=SectionId},
                            
                         };

            return ft;
        }

        private List<ItemType> GetItemTypes()
        {
            return ItemTypes.Select(typeId => new ItemType {Id = typeId}).ToList();
        }
    }
}