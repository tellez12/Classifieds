using System.Collections.Generic;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;

namespace Classifieds.WebUI.ViewModels
{
    public class ItemTypeFeatureViewModel
    {
        public int ItemTypeId { get; set; }

        private IUnitOfWork unitOfWork;

        public List<Section> Sections { get; set; }

        public ItemTypeFeatureViewModel(int myItemTypeId, IUnitOfWork myUnitOfWork)
        {
            ItemTypeId = myItemTypeId;
            unitOfWork = myUnitOfWork;
            unitOfWork.SectionRepository.Get(includeProperties: "Features");

            foreach (var item in Sections)
            {
                var x = new List<FeatureType>();
                foreach (var feature in item.Features)
                {
                    foreach (var itemType in feature.ItemTypes)
                    {
                        if (itemType.Id == ItemTypeId)
                        {
                            x.Add(feature);
                            break;
                        }
                    }
                }
                item.Features = x;
            }
        }
    }
}