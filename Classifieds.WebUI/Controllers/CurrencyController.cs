using System;
using System.Linq;
using System.Web.Mvc;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyRepository repository;
        public int pageSize = 4;

        public CurrencyController(ICurrencyRepository MyRepository)
        {
            this.repository = MyRepository;
        }

        //
        // GET: /Currency/

        public ActionResult Index(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = repository.GetCurrencies.Count();
            ViewBag.pagingInfo = pagingInfo;
            return View(repository.GetCurrencies.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize));
        }

        //
        // GET: /Currency/Details/5

        public ActionResult Details(int id = 0)
        {
            Currency Currency = repository.GetCurrency(id);
            if (Currency == null)
            {
                return HttpNotFound();
            }
            return View(Currency);
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
        public ActionResult Create(Currency Currency)
        {
            if (ModelState.IsValid)
            {
                repository.Create(Currency);
                return RedirectToAction("Index");
            }

            return View(Currency);
        }

        //
        // GET: /Currency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Currency Currency = repository.GetCurrency(id);
            if (Currency == null)
            {
                return HttpNotFound();
            }

            return View(Currency);
        }

        //
        // POST: /Currency/Edit/5

        [HttpPost]
        public ActionResult Edit(Currency Currency)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(Currency);
                return RedirectToAction("Index");
            }

            return View(Currency);
        }

        //
        // GET: /Currency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Currency Currency = repository.GetCurrency(id);

            if (Currency == null)
            {
                return HttpNotFound();
            }
            return View(Currency);
        }

        //
        // POST: /Currency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}