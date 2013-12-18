using System.Collections.Generic;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;

namespace Classifieds.WebUI.ViewModels
{
    public class ItemTypeFeatureViewModel
    {
        private IUnitOfWork unitOfWork;

        public List<Section> Sections { get; set; }

        public ItemTypeFeatureViewModel(int myItemTypeId, IUnitOfWork myUnitOfWork)
        {
            unitOfWork = myUnitOfWork;
            Sections = unitOfWork.SectionRepository.Get(includeProperties: "Features").ToList();

            foreach (var item in Sections)
            {
                item.Features = item.Features
                    .Where(f => f.ItemTypes.Any(i => i.Id == myItemTypeId))
                    .ToList();
            }
            Sections = Sections.Where(s => s.Features.Count() > 0).ToList();
        }
    }
}