using System;

namespace Classifieds.Domain.EF
{
    public class EFBaseRepository
    {
        protected MyContext Db = new MyContext();

        public void Dispose(bool disposing)
        {
            Db.Dispose();
        }
    }
}