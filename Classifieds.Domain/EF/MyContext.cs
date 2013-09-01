using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.EF
{
    public class MyContext: DbContext
    {
        public MyContext()
            : base("DefaultConnection")
        {
          
        }

  
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureType> FeatureTypes { get; set; }
        public DbSet<FeatureTypeValue> FeatureTypeValues { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
