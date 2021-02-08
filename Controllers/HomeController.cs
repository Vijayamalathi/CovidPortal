using CovidPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidPortal.Controllers
{
    public class HomeController : Controller
    {

        private CovidDBEntities _db = new CovidDBEntities();
        // GET: Home
        public ActionResult Index ()
        {
           
            return View(_db.Covids.ToList());
        }

       // GET: Home/Details/5
        //public ActionResult Details(List<CovidTable> orig)//(CovidTable c)
        //{
        //    return View(orig);
        //}
        public ActionResult Details(CovidTable c)
            //(CovidTable cities)
        {
            ViewBag.Message = "Result List";
            //var data = new List<CovidTable>(from m in _db.Covids
            //                                where m.AgeGroup == c.AgeGroup ||
            //                                m.Gender == c.Gender ||
            //                                m.DateOfConfirmedCase == c.DateOfConfirmedCase
            //                                select m).ToList();
           
            
                var data = new List<CovidTable>(from m in _db.Covids
                                                where m.AgeGroup == c.AgeGroup &&
                                                m.Gender == c.Gender &&
                                                m.DateOfConfirmedCase == c.DateOfConfirmedCase
                                                select m).ToList();
            

            List < CovidTable > coviddat = new List<CovidTable>();
            foreach (var row in data)
            {
                coviddat.Add(new CovidTable
                {
                    AgeGroup = row.AgeGroup,
                    DateOfConfirmedCase = row.DateOfConfirmedCase,
                    Gender = row.Gender

                });

            }

            ///
            //var orig = new List<CovidTable> (from m in _db.Covids
            //                         where m.AgeGroup == c.AgeGroup
            //                         select m).ToList();

            if (!ModelState.IsValid)
                return View(coviddat);//new System.Collections.Generic.Mscorlib_CollectionDebugView<CovidPortal.Models.CovidTable>(orig).Items[0]

            return View();
            //return RedirectToAction("Details", coviddat);
           
        }
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(CovidTable c)
        {
            Details(c);
            return null;
            
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
