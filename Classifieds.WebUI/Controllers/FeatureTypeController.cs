using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.Domain.Utils;
using Classifieds.WebUI.ViewModels;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class FeatureTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public FeatureTypeController(IUnitOfWork myUnitOfWork)
        {
            unitOfWork = myUnitOfWork;
        }

        //
        // GET: /FeatureType/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo(page, unitOfWork.FeatureTypeRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.FeatureTypeRepository.Get(includeProperties: "Section").OrderBy(p => p.Id).Skip((page - 1) * pagingInfo.ItemsPerPage).Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /FeatureType/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureType featureType = unitOfWork.FeatureTypeRepository.GetById(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            return View(featureType);
        }

        //
        // GET: /FeatureType/Create

        public ActionResult Create()
        {
            return View(new FeatureTypeViewModel(unitOfWork));
        }

        //
        // POST: /FeatureType/Create

        [HttpPost]
        public ActionResult Create(FeatureTypeViewModel featureType)
        {
            if (ModelState.IsValid)
            {
                featureType.SetRepositories(unitOfWork);
                unitOfWork.FeatureTypeRepository.Insert(featureType.ToModel());
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(featureType);
        }

        //
        // GET: /FeatureType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureType featureType = unitOfWork.FeatureTypeRepository.GetById(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionSelect = new SelectList(unitOfWork.SectionRepository.Get().ToList(), "Id", "Name");
            var enumList = from ControlType s in Enum.GetValues(typeof(ControlType))
                           select new { ID = (int)s, Name = s.ToString() };

            var typeList = new SelectList(enumList, "ID", "Name", featureType.ControlType);

            ViewData["TypeDD"] = typeList;

            return View(featureType);
        }

        //
        // POST: /FeatureType/Edit/5

        [HttpPost]
        public ActionResult Edit(FeatureType featureType, ControlType typeDD)
        {
            if (ModelState.IsValid)
            {
                featureType.ControlType = typeDD;
                unitOfWork.FeatureTypeRepository.Update(featureType);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(featureType);
        }

        //
        // GET: /FeatureType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var featureType = unitOfWork.FeatureTypeRepository.GetById(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            return View(featureType);
        }

        //
        // POST: /FeatureType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.FeatureTypeRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}