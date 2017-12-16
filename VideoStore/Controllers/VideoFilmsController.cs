using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.Models.Repositories;

namespace VideoStore.Controllers
{
    public class VideoFilmsController : Controller
    {
        //VideoStoreDbContext context = new VideoStoreDbContext();
        Repository<Videofilm> repository = new Repository<Videofilm>();
        
      public ActionResult Details(int id)
        {
            Videofilm videofilm = repository.Get(id);

            if (videofilm == null)
            {
                return HttpNotFound();
            }
            else
                return View(videofilm);
        }
                
        
        // GET: VideoFilms
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Videofilm videoFilm)
        {
            if (!ModelState.IsValid)
                return View("VideoFilms");

            repository.Add(videoFilm);
            repository.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Find(Videofilm videoFilm)
        {

            return View(repository.Get(videoFilm.Id));
        }


        public ActionResult Delete(int id)
        {
            Videofilm videofilm = repository.Get(id);

            if (videofilm == null)            
                return HttpNotFound();            
            else            
                return View(videofilm);                                        
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Videofilm videofilm = repository.Get(id);
            
            if (videofilm == null)
                return HttpNotFound();
            else
            {
                repository.Remove(videofilm);
                repository.SaveChanges();
                return RedirectToAction("index");
            }
                  
        }
        
        public ActionResult Edit(int id)
        {
            Videofilm videofilm = repository.Get(id);

            if (videofilm == null)
                return HttpNotFound();
            else
                return View(videofilm);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(Videofilm videofilm)
        {
            if (videofilm == null)
                return HttpNotFound();
            else
            {
                repository.Edit(videofilm);
                repository.SaveChanges();
                return RedirectToAction("Index");

            }
        }


    }
}