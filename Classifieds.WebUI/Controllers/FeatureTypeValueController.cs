﻿using System;
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
        private readonly IUnitOfWork unitOfWork;

        public FeatureTypeValueController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /FeatureTypeValue/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo(page, unitOfWork.FeatureTypeValueRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.FeatureTypeValueRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * pagingInfo.ItemsPerPage).Take(pagingInfo.ItemsPerPage));
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
                unitOfWork.Save();
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
        public ActionResult Edit(FeatureTypeValue featureTypeValue)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FeatureTypeValueRepository.Update(featureTypeValue);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(featureTypeValue);
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
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}