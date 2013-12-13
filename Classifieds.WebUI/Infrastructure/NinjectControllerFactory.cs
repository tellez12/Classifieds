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
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddEFBindings();
            // AddBindings();
        }

        private void AddEFBindings()
        {
            _ninjectKernel.Bind<ISectionRepository>().To<EFSectionRepository>();
            _ninjectKernel.Bind<IItemRepository>().To<EFItemRepository>();
            _ninjectKernel.Bind<IFeatureTypeRepository>().To<EFFeatureTypeRepository>();
            _ninjectKernel.Bind<ICurrencyRepository>().To<EFCurrencyRepository>();
            _ninjectKernel.Bind<IFeatureTypeValueRepository>().To<EFFeatureTypeValueRepository>();
            _ninjectKernel.Bind<IItemTypeRepository>().To<EFItemTypeRepository>();
            _ninjectKernel.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var mock = new Mock<IFeatureTypeRepository>();

            mock.Setup(m => m.GetFeatureTypes).Returns(new List<FeatureType> {
                 new FeatureType { Name = "Football"},
                 new FeatureType { Name = "Surf board"},
                 new FeatureType { Name = "Running shoes" }
             }.AsQueryable());

            _ninjectKernel.Bind<IFeatureTypeRepository>().ToConstant(mock.Object);
        }
    }
}