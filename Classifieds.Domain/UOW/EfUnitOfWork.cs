using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.EF;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.UOW
{
    public class EfUnitOfWork : IUnitOfWork,IDisposable
    {
        private MyContext context = new MyContext();

        private GenericRepository<Item> itemRepository;
        private GenericRepository<Section> sectionRepository;
        private GenericRepository<Currency> currencyRepository;
        private GenericRepository<Feature> featureRepository;
        private GenericRepository<FeatureType> featureTypeRepository;
        private GenericRepository<FeatureTypeValue> featureTypeValueRepository;
        private GenericRepository<Picture> pictureRepository;
        private GenericRepository<ItemType> itemTypeRepository;

        public GenericRepository<Currency> CurrencyRepository
        {
            get
            {
                if (this.currencyRepository == null)
                {
                    this.currencyRepository = new GenericRepository<Currency>(context);
                }
                return currencyRepository;
            }
        }

        public GenericRepository<FeatureTypeValue> FeatureTypeValueRepository
        {
            get
            {
                if (this.featureTypeValueRepository == null)
                {
                    this.featureTypeValueRepository = new GenericRepository<FeatureTypeValue>(context);
                }
                return featureTypeValueRepository;
            }
        }

        public GenericRepository<Section> SectionRepository
        {
            get
            {
                if (this.sectionRepository == null)
                {
                    this.sectionRepository = new GenericRepository<Section>(context);
                }
                return sectionRepository;
            }
        }

        public GenericRepository<Item> ItemRepository
        {
            get
            {
                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<Item>(context);
                }
                return itemRepository;
            }
        }

        public GenericRepository<Feature> FeatureRepository
        {
            get
            {
                if (this.featureRepository == null)
                {
                    this.featureRepository = new GenericRepository<Feature>(context);
                }
                return featureRepository;
            }
        }

        public GenericRepository<Picture> PictureRepository
        {
            get
            {
                if (this.pictureRepository == null)
                {
                    this.pictureRepository = new GenericRepository<Picture>(context);
                }
                return pictureRepository;
            }
        }

        public GenericRepository<ItemType> ItemTypeRepository
        {
            get
            {
                if (this.itemTypeRepository == null)
                {
                    this.itemTypeRepository = new GenericRepository<ItemType>(context);
                }
                return itemTypeRepository;
            }
        }

        public GenericRepository<FeatureType> FeatureTypeRepository
        {
            get
            {
                if (this.featureTypeRepository == null)
                {
                    this.featureTypeRepository = new GenericRepository<FeatureType>(context);
                }
                return featureTypeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}