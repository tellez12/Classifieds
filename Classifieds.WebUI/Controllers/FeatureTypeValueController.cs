using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class FeatureTypeValueController : Controller
    {
        private IUnitOfWork unitOfWork;
        public int pageSize = 4;

        public FeatureTypeValueController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /FeatureTypeValue/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = unitOfWork.FeatureTypeValueRepository.Get().Count();
            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.FeatureTypeValueRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }

        //
        // GET: /FeatureTypeValue/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureTypeValue featureTypeValue = unitOfWork.FeatureTypeValueRepository.GetById(id);
            if (featureTypeValue == null)
            {
                return HttpNotFound();
            }
            return View(featureTypeValue);
        }

        //
        // GET: /FeatureTypeValue/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FeatureTypeValue/Create

        [HttpPost]
        public ActionResult Create(FeatureTypeValue featureTypeValue)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FeatureTypeValueRepository.Insert(featureTypeValue);
                return RedirectToAction("Index");
            }

            return View(featureTypeValue);
        }

        //
        // GET: /FeatureTypeValue/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureTypeValue FeatureTypeValue = unitOfWork.FeatureTypeValueRepository.GetById(id);
            if (FeatureTypeValue == null)
            {
                return HttpNotFound();
            }

            return View(FeatureTypeValue);
        }

        //
        // POST: /FeatureTypeValue/Edit/5

        [HttpPost]
        public ActionResult Edit(FeatureTypeValue FeatureTypeValue)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FeatureTypeValueRepository.Update(FeatureTypeValue);
                return RedirectToAction("Index");
            }

            return View(FeatureTypeValue);
        }

        //
        // GET: /FeatureTypeValue/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeatureTypeValue featureTypeValue = unitOfWork.FeatureTypeValueRepository.GetById(id);

            if (featureTypeValue == null)
            {
                return HttpNotFound();
            }
            return View(featureTypeValue);
        }

        //
        // POST: /FeatureTypeValue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.FeatureTypeValueRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}