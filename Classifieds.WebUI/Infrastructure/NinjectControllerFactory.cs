using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.EF;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Moq;
using Ninject;

namespace Classifieds.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddEFBindings();
            // AddBindings();
        }

        private void AddEFBindings()
        {
            ninjectKernel.Bind<ISectionRepository>().To<EFSectionRepository>();
            ninjectKernel.Bind<IItemRepository>().To<EFItemRepository>();
            ninjectKernel.Bind<IFeatureTypeRepository>().To<EFFeatureTypeRepository>();
            ninjectKernel.Bind<ICurrencyRepository>().To<EFCurrencyRepository>();
            ninjectKernel.Bind<IFeatureTypeValueRepository>().To<EFFeatureTypeValueRepository>();
            ninjectKernel.Bind<IItemTypeRepository>().To<EFItemTypeRepository>();
            ninjectKernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var mock = new Mock<IFeatureTypeRepository>();

            mock.Setup(m => m.GetFeatureTypes).Returns(new List<FeatureType>
                                                       {
                                                           new FeatureType {Name = "Football"},
                                                           new FeatureType {Name = "Surf board"},
                                                           new FeatureType {Name = "Running shoes"}
                                                       }.AsQueryable());

            ninjectKernel.Bind<IFeatureTypeRepository>().ToConstant(mock.Object);
        }
    }
}