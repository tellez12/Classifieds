using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.UOW;
using Classifieds.WebUI.ViewModels.Shared;

namespace Classifieds.WebUI.Controllers
{
    public class SectionController : Controller
    {
        private IUnitOfWork unitOfWork;
        public int PageSize = 4;

        public SectionController(IUnitOfWork myUnitOfWork)
        {
            this.unitOfWork = myUnitOfWork;
        }

        //
        // GET: /Section/

        public ActionResult Index(int page = 1)
        {
            var pagingInfo = new PagingInfo(page, unitOfWork.SectionRepository.Get().Count());
            ViewBag.pagingInfo = pagingInfo;
            return View(unitOfWork.SectionRepository.Get().OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }

        //
        // GET: /Section/Details/5

        public ActionResult Details(int id = 0)
        {
            var section = unitOfWork.SectionRepository.GetById(id);
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
                unitOfWork.SectionRepository.Insert(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        //
        // GET: /Section/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var section = unitOfWork.SectionRepository.GetById(id);
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
                unitOfWork.SectionRepository.Update(section);
                return RedirectToAction("Index");
            }

            return View(section);
        }

        //
        // GET: /Section/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var section = unitOfWork.SectionRepository.GetById(id);

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
            unitOfWork.SectionRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}