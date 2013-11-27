using System;

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