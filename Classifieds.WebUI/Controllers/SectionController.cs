﻿using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository _repository;
        public int PageSize = 4;

        public SectionController(ISectionRepository myRepository)
        {
            this._repository = myRepository;
        }

        //
        // GET: /Section/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
                                 {
                                     CurrentPage = page,
                                     ItemsPerPage = PageSize,
                                     TotalItems = _repository.GetSections.Count()
                                 };
            ViewBag.pagingInfo = pagingInfo;
            return View(_repository.GetSections.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /Section/Details/5

        public ActionResult Details(int id = 0)
        {
            var section = _repository.GetSection(id);
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
                _repository.Create(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        //
        // GET: /Section/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var section = _repository.GetSection(id);
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
                _repository.Edit(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        //
        // GET: /Section/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var section = _repository.GetSection(id);

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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}