using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class ItemTypeController : Controller
    {
        private readonly IItemTypeRepository _repository;
        public int PageSize = 4;

        public ItemTypeController(IItemTypeRepository myRepository)
        {
            this._repository = myRepository;
        }

        //
        // GET: /ItemType/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
                                 {
                                     CurrentPage = page,
                                     ItemsPerPage = PageSize,
                                     TotalItems = _repository.GetItemTypes.Count()
                                 };
            ViewBag.pagingInfo = pagingInfo;
            return View(_repository.GetItemTypes.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /ItemType/Details/5

        public ActionResult Details(int id = 0)
        {
            var itemType = _repository.GetItemType(id);
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
                _repository.Create(itemType);
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        //
        // GET: /ItemType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var itemType = _repository.GetItemType(id);
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
                _repository.Edit(itemType);
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        //
        // GET: /ItemType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var itemType = _repository.GetItemType(id);

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
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}