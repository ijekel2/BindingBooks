using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BindingBooks.Models;

namespace BindingBooks.Controllers
{
    public class MembershipTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET
        public ActionResult Index()
        {
            var membershipTypes = db.MembershipTypes.ToList();
            return View(membershipTypes);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembershipType membershipType)
        {

            if (ModelState.IsValid)
            {
                db.MembershipTypes.Add(membershipType);
            }
            return View();
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var membershipType = db.MembershipTypes.Find(id);
            
            if (membershipType == null)
            {
                return HttpNotFound();
            }
            
            return View(membershipType);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MembershipType membershipType)
        {

            if (ModelState.IsValid)
            {
                db.Entry(membershipType).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            
            return View();
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var membershipType = db.MembershipTypes.Find(id);

            if (membershipType == null)
            {
                return HttpNotFound();
            }
            
            return View(membershipType);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var membershipType = db.MembershipTypes.Find(id);

            if (membershipType == null)
            {
                return HttpNotFound();
            }
            
            return View(membershipType);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var membershipType = db.MembershipTypes.Find(id);
            if (membershipType == null)
            {
                return HttpNotFound();
            }
            
            db.MembershipTypes.Remove(membershipType);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        
        
    }
}