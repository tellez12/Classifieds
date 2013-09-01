using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Domain.EF
{
    public class EFBaseRepository
    {
        protected MyContext db = new MyContext();

        public void Dispose(bool disposing)
        {
            db.Dispose();

        }
    }
}
