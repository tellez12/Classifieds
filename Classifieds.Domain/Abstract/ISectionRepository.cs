using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

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