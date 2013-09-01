using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.EF;
using Classifieds.Domain.Abstract;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class FeatureTypeController : Controller
    {
        private IFeatureTypeRepository repository;
        private ISectionRepository sectionRepository;
        public int pageSize = 4;

        public FeatureTypeController(IFeatureTypeRepository MyRepository, ISectionRepository MySectionRepository)
        {
            this.repository = MyRepository;
            this.sectionRepository = MySectionRepository;
        }

        //
        // GET: /FeatureType/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = repository.GetFeatureTypes.Count();
            ViewBag.pagingInfo = pagingInfo;
            return View(repository.GetFeatureTypes.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }

        //
        // GET: /FeatureType/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureType FeatureType = repository.GetFeatureType(id);
            if (FeatureType == null)
            {
                return HttpNotFound();
            }
            return View(FeatureType);
        }

        //
        // GET: /FeatureType/Create

        public ActionResult Create()
        {
            ViewBag.SectionSelect = new SelectList(sectionRepository.GetSections.ToList(), "Id", "Name");
            return View();
        }

        //
        // POST: /FeatureType/Create

        [HttpPost]
        public ActionResult Create(FeatureType FeatureType)
        {
            if (ModelState.IsValid)
            {

                repository.Create(FeatureType);
                return RedirectToAction("Index");
            }

            return View(FeatureType);
        }

        //
        // GET: /FeatureType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureType FeatureType = repository.GetFeatureType(id);
            if (FeatureType == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionSelect = new SelectList(sectionRepository.GetSections.ToList(), "Id", "Name");

            return View(FeatureType);
        }

        //
        // POST: /FeatureType/Edit/5

        [HttpPost]
        public ActionResult Edit(FeatureType FeatureType)
        {
            if (ModelState.IsValid)
            {

                repository.Edit(FeatureType);
                return RedirectToAction("Index");
            }

            return View(FeatureType);
        }

        //
        // GET: /FeatureType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeatureType FeatureType = repository.GetFeatureType(id);

            if (FeatureType == null)
            {
                return HttpNotFound();
            }
            return View(FeatureType);
        }

        //
        // POST: /FeatureType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            // repository.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}