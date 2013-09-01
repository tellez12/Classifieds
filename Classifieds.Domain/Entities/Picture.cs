using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
