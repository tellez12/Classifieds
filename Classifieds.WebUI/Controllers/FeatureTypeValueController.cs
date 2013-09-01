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
    public class FeatureTypeValueController : Controller
    {
        private IFeatureTypeValueRepository repository;
        public int pageSize = 4;

        public FeatureTypeValueController(IFeatureTypeValueRepository MyRepository)
        {
            this.repository = MyRepository; 
        } 

        //
        // GET: /FeatureTypeValue/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = repository.GetFeatureTypeValues.Count();
            ViewBag.pagingInfo = pagingInfo;
            return View(repository.GetFeatureTypeValues.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }

        //
        // GET: /FeatureTypeValue/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureTypeValue FeatureTypeValue = repository.GetFeatureTypeValue(id);
            if (FeatureTypeValue == null)
            {
                return HttpNotFound();
            }
            return View(FeatureTypeValue);
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
        public ActionResult Create(FeatureTypeValue FeatureTypeValue)
        {
            if (ModelState.IsValid)
            {

                repository.Create(FeatureTypeValue);
                return RedirectToAction("Index");
            }

            return View(FeatureTypeValue);
        }

        //
        // GET: /FeatureTypeValue/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureTypeValue FeatureTypeValue = repository.GetFeatureTypeValue(id);
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

                repository.Edit(FeatureTypeValue);
                return RedirectToAction("Index");
            }
          
            return View(FeatureTypeValue);
        }

        //
        // GET: /FeatureTypeValue/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeatureTypeValue FeatureTypeValue = repository.GetFeatureTypeValue(id);

            if (FeatureTypeValue == null)
            {
                return HttpNotFound();
            }
            return View(FeatureTypeValue);
        }

        //
        // POST: /FeatureTypeValue/Delete/5

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