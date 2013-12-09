using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;
        private readonly ISectionRepository _sectionRepository;
        public int PageSize = 4;

        public ItemController(IItemRepository myRepository,ISectionRepository mySectionRepository)
        {
            _repository = myRepository;
            _sectionRepository = mySectionRepository;
        }

        //
        // GET: /Item/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = _repository.GetItems.Count()
            };
            ViewBag.pagingInfo = pagingInfo;
            return View(_repository.GetItems.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id = 0)
        {
            var item = _repository.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            ViewBag.SectionSelect = new SelectList(_sectionRepository.GetSections.ToList(), "Id", "Name");
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var item = _repository.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var item = _repository.GetItem(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}