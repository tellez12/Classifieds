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
    public class SectionController : Controller
    {
        private ISectionRepository repository;
        public int pageSize = 4;

        public SectionController(ISectionRepository MyRepository)
        {
            this.repository = MyRepository; 
        } 

        //
        // GET: /Section/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = repository.GetSections.Count();
            ViewBag.pagingInfo = pagingInfo;
            return View(repository.GetSections.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }

        //
        // GET: /Section/Details/5

        public ActionResult Details(int id = 0)
        {
            Section section = repository.GetSection(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        //
        // GET: /Section/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Section/Create

        [HttpPost]
        public ActionResult Create(Section section)
        {
            if (ModelState.IsValid)
            {

                repository.Create(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        //
        // GET: /Section/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Section section = repository.GetSection(id);
            if (section == null)
            {
                return HttpNotFound();
            }
           
            return View(section);
        }

        //
        // POST: /Section/Edit/5

        [HttpPost]
        public ActionResult Edit(Section section)
        {
            if (ModelState.IsValid)
            {

                repository.Edit(section);
                return RedirectToAction("Index");
            }
          
            return View(section);
        }

        //
        // GET: /Section/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Section section = repository.GetSection(id);

            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        //
        // POST: /Section/Delete/5

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