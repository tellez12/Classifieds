using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class FeatureTypeController : Controller
    {
        private readonly IFeatureTypeRepository _repository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IItemTypeRepository _itemTypeRepository;
        public int PageSize = 4;

        public FeatureTypeController(IFeatureTypeRepository myRepository, ISectionRepository mySectionRepository, IItemTypeRepository myItemTypeRepository)
        {
            _repository = myRepository;
            _sectionRepository = mySectionRepository;
            _itemTypeRepository = myItemTypeRepository;
        }

        //
        // GET: /FeatureType/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
                                 {
                                     CurrentPage = page,
                                     ItemsPerPage = PageSize,
                                     TotalItems = _repository.GetFeatureTypes.Count()
                                 };
            ViewBag.pagingInfo = pagingInfo;
            return View(_repository.GetFeatureTypes.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /FeatureType/Details/5

        public ActionResult Details(int id = 0)
        {
            FeatureType featureType = _repository.GetFeatureType(id);
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
            ViewBag.SectionSelect = new SelectList(_sectionRepository.GetSections.ToList(), "Id", "Name");
            ViewBag.ItemTypeList = new SelectList(_itemTypeRepository.GetItemTypes.ToList(), "Id", "Name");

            ViewBag.TypeEnumSelect = from ControlType s in Enum.GetValues(typeof(ControlType))
                                     select new { ID = (int)s, Name = s.ToString() };
            ViewData["TypeDD"] = new SelectList(ViewBag.TypeEnumSelect, "ID", "Name");
            return View();
        }

        //
        // POST: /FeatureType/Create

        [HttpPost]
        public ActionResult Create(FeatureType featureType, ControlType typeDD)
        {
            if (ModelState.IsValid)
            {
                featureType.ControlType = typeDD;
                _repository.Create(featureType);
                return RedirectToAction("Index");
            }

            return View(featureType);
        }

        //
        // GET: /FeatureType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeatureType featureType = _repository.GetFeatureType(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionSelect = new SelectList(_sectionRepository.GetSections.ToList(), "Id", "Name");
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
                _repository.Edit(featureType);
                return RedirectToAction("Index");
            }

            return View(featureType);
        }

        //
        // GET: /FeatureType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var featureType = _repository.GetFeatureType(id);

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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}