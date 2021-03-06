﻿using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.Abstract
{
    public interface IFeatureTypeValueRepository
    {
        IQueryable<FeatureTypeValue> GetFeatureTypeValues { get; }

        FeatureTypeValue GetFeatureTypeValue(int id);

        Message Create(FeatureTypeValue value);

        Message Edit(FeatureTypeValue featureTypeValue);

        Message Delete(int id);
    }
}