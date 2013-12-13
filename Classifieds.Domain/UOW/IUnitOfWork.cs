using Classifieds.Domain.Entities;

namespace Classifieds.Domain.UOW
{
    public interface IUnitOfWork
    {
        GenericRepository<Section> SectionRepository { get; }
        GenericRepository<ItemType> ItemTypeRepository { get; }
        GenericRepository<FeatureType> FeatureTypeRepository { get; }
        void Save();
        void Dispose();
    }
}