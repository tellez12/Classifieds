using Classifieds.Domain.Entities;

namespace Classifieds.Domain.UOW
{
    public interface IUnitOfWork
    {
        GenericRepository<Classifieds.Domain.Entities.Currency> CurrencyRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.Feature> FeatureRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.FeatureType> FeatureTypeRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.Item> ItemRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.ItemType> ItemTypeRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.Picture> PictureRepository { get; }

        GenericRepository<Classifieds.Domain.Entities.Section> SectionRepository { get; }

        void Save();

        void Dispose();
    }
}