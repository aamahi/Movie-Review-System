using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using movietest1.Contexts;
using movietest1.Models;
using movietest1.ViewModels;
using movietest1.OtherClasses;

namespace movietest1.Controllers
{
    public class AccountsController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Accounts
        //public ActionResult Index()
        //{
        //    return View(db.Accounts.ToList());
        //}

        //// GET: Accounts/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = db.Accounts.Find(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(account);
        //}

        // GET: Accounts/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel rvm)
        {

            if(find(rvm.Email)!=null)
            {
                ViewBag.Status = "Email already exists,please choose another one";
                return View(rvm);

            }

            Account recieved = new Account { FullName = rvm.FullName, Email = rvm.Email, ID = IdGenerator.Generate(10), Password = rvm.Password, Role = rvm.Role };//
            if (ModelState.IsValid)
            {
                db.Accounts.Add(recieved);
                db.SaveChanges();
                ViewBag.Status = "Account Successfully created";
                return View();
            }

            ViewBag.Status = "Can't Create account There might be some problems";
            return View(rvm);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            

            bool tag = db.Accounts.Any(acc => acc.Email.Equals(lvm.Email) && acc.Password.Equals(lvm.Password));
            if(tag==true)
            {
                ViewBag.Status = "Login Successfull,data found";
                return View();
            }

            ViewBag.Status = "Username or Password is not matched";
            return View();
        }

        // GET: Accounts/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = db.Accounts.Find(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(account);
        //}

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Email,FullName,Password,Role")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(account).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(account);
        //}

        // GET: Accounts/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = db.Accounts.Find(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(account);
        //}

        //// POST: Accounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Account account = db.Accounts.Find(id);
        //    db.Accounts.Remove(account);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Account find(string email)
        {
            //For using first or default it will either return null or the account
            return db.Accounts.Where(acc => acc.Email.Equals(email)).FirstOrDefault();
        }
    }
}
