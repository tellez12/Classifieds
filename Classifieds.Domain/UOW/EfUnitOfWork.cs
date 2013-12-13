using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.EF;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.UOW
{
   public  class EfUnitOfWork : IUnitOfWork
   {
       private MyContext context = new MyContext();

       private GenericRepository<Section> sectionRepository;
       private GenericRepository<ItemType> itemTypeRepository;
       private GenericRepository<FeatureType> featureTypeRepository;

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
