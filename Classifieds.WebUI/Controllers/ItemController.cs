using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.WebUI.ViewModels;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ItemController(IUnitOfWork myUnitOfWork)
        {
            unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Item/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo(page, unitOfWork.ItemRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.ItemRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * pagingInfo.ItemsPerPage).Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id = 0)
        {
            var item = unitOfWork.ItemRepository.GetById(id);
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
            return View(new ItemViewModel(unitOfWork));
        }

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                item.SetRepositories(unitOfWork);
                unitOfWork.ItemRepository.Insert(item.ToModel());
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var item = unitOfWork.ItemRepository.GetById(id);
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
                unitOfWork.ItemRepository.Update(item);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var item = unitOfWork.ItemRepository.GetById(id);

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
            unitOfWork.ItemRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult GetFeatureTypePartial(int itemTypeId)
        {
            var model = new ItemTypeFeatureViewModel(itemTypeId, unitOfWork);
            return PartialView("_ItemTypeFeatures", model);
        }
    }
}