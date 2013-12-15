﻿using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class ItemTypeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public int PageSize = 4;

        public ItemTypeController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /ItemType/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
                                 {
                                     CurrentPage = page,
                                     ItemsPerPage = PageSize,
                                     TotalItems = unitOfWork.ItemTypeRepository.Get().Count()
                                 };
            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.ItemTypeRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /ItemType/Details/5

        public ActionResult Details(int id = 0)
        {
            var itemType = unitOfWork.ItemTypeRepository.GetById(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        //
        // GET: /ItemType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ItemType/Create

        [HttpPost]
        public ActionResult Create(ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ItemTypeRepository.Insert(itemType);
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        //
        // GET: /ItemType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var itemType = unitOfWork.ItemTypeRepository.GetById(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }

            return View(itemType);
        }

        //
        // POST: /ItemType/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ItemTypeRepository.Update(itemType);
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        //
        // GET: /ItemType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var itemType = unitOfWork.ItemTypeRepository.GetById(id);

            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        //
        // POST: /ItemType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.ItemTypeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}