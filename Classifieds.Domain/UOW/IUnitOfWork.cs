using Classifieds.Domain.Entities;

namespace Classifieds.Domain.UOW
{
    public interface IUnitOfWork
    {
        GenericRepository<Currency> CurrencyRepository { get; }

        GenericRepository<Feature> FeatureRepository { get; }

        GenericRepository<FeatureType> FeatureTypeRepository { get; }

        GenericRepository<FeatureTypeValue> FeatureTypeValueRepository { get; }

        GenericRepository<Item> ItemRepository { get; }

        GenericRepository<ItemType> ItemTypeRepository { get; }

        GenericRepository<Picture> PictureRepository { get; }

        GenericRepository<Section> SectionRepository { get; }

        void Dispose();

        void Save();
    }
}