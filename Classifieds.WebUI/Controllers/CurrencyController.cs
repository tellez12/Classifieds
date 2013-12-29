using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CurrencyController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Currency/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo(page, unitOfWork.CurrencyRepository.Get().Count());

            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.CurrencyRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * pagingInfo.ItemsPerPage).Take(pagingInfo.ItemsPerPage));
        }

        //
        // GET: /Currency/Details/5

        public ActionResult Details(int id = 0)
        {
            Currency currency = unitOfWork.CurrencyRepository.GetById(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // GET: /Currency/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Currency/Create

        [HttpPost]
        public ActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CurrencyRepository.Insert(currency);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        //
        // GET: /Currency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Currency currency = unitOfWork.CurrencyRepository.GetById(id);
            if (currency == null)
            {
                return HttpNotFound();
            }

            return View(currency);
        }

        //
        // POST: /Currency/Edit/5

        [HttpPost]
        public ActionResult Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CurrencyRepository.Update(currency);
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        //
        // GET: /Currency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Currency currency = unitOfWork.CurrencyRepository.GetById(id);

            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // POST: /Currency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.CurrencyRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}