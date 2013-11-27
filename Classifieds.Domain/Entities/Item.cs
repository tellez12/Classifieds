using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classifieds.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public virtual List<Feature> Features { get; set; }

        public virtual List<Picture> Pictures { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PublishDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime AdquiredDate { get; set; }
    }
}