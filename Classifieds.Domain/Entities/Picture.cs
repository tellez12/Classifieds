using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classifieds.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public string path { get; set; }
    }
}