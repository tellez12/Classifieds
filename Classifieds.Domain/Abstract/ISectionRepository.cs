using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.Abstract
{
    public interface ISectionRepository
    {
        IQueryable<Section> GetSections { get; }

        Section GetSection(int id);
        Message Create(Section section);
        Message Edit(Section section);
        Message Delete(int id);
        
    }
}
