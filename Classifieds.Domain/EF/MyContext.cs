using System;
using System.Data.Entity;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.EF
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<FeatureType> FeatureTypes { get; set; }

        public DbSet<FeatureTypeValue> FeatureTypeValues { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }
    }
}