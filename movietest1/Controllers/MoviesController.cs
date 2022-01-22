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
using movietest1.OtherClasses;
using System.Diagnostics;

namespace movietest1.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        //// GET: Movies
        //public ActionResult Index()
        //{
        //    return View(db.Movies.ToList());
        //}

        public ActionResult MoviesIndex(string industry, string genreOrname, int i)//its for public
        {

            if (i == 0)
            {
                var posts = db.Movies.Where(a => a.Industry.Equals(industry) && a.Genre.Equals(genreOrname));
                ViewBag.head = industry+" Movies with "+genreOrname+" Category";
                return View(posts.ToList());
            }
            if (i == 1)
            {
                var posts2 = db.Movies.Where(a => a.Industry.Equals(industry) && a.NamePosition.Equals(genreOrname));
                ViewBag.head = industry + " Movies from " + genreOrname ;
                return View(posts2.ToList());
            }
            ViewBag.head = "All Movies";
            return View(db.Movies.ToList());
        }
        
        
        public ActionResult ShowList(string message)//its for admin,he will see the list and update or delete the data from it
        {
            //return View();
            ViewBag.message = message;
            return View(db.Movies.ToList());
        }

        //// GET: Movies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        public ActionResult MovieDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
            //return View();
        }

        // GET: Movies/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Description,Casts,Genre")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Movies.Add(movie);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(movie);
        //}

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Movie movie, HttpPostedFileBase file)
        {
            //code for image
            string filepathtosave;
            try
            {
                if (file != null)
                {
                    int byteCount = file.ContentLength;
                    if (byteCount > 200000)
                    {
                        ViewBag.Error = "Can't Upload images more than 200KB";
                        return View(movie);
                    }
                }

                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                //removing whitespaces
                filename = filename.ToCharArray()
                 .Where(c => !Char.IsWhiteSpace(c))
                 .Select(c => c.ToString())
                 .Aggregate((a, b) => a + b);

                //checking directory is there or not if not create it
                string subPath = "~/Images/Movies/"; // your code goes here

                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                //finishing of directory creating


                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/Movies/" + filename));
                filepathtosave = "/Images/Movies/" + filename;
                /*Storing image path to show preview*/
                // ViewBag.ImageURL = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                //ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Status = "Error in uploading image,please try again";
                return View(movie);
            }

            //ending of code for image

            //adding name position
            movie.NamePosition = SetNamePosition.Set(movie.Title);

            if (ModelState.IsValid)
            {
                movie.image = filepathtosave;
                db.Movies.Add(movie);
                db.SaveChanges();
                ViewBag.Status = "Movie was added successfully";
                return View();
            }
            ViewBag.Status = "Can't create the movie there might be some problems";
            return View(movie);
        }
        // GET: Movies/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(Movie movie, HttpPostedFileBase file)
        {
            //code for image
            string filepathtosave;
            try
            {
                if (file != null)
                {
                    int byteCount = file.ContentLength;
                    if (byteCount > 200000)
                    {
                        ViewBag.Status = "Can't Upload images more than 200KB,Try again please";
                        return View(movie);
                    }
                }
                else
                {
                    //ViewBag.Status = "Image upload hoy nai";
                    //return View(movie);
                    goto noedit;
                }

                /*Geting the file name*/
                string filename = System.IO.Path.GetFileName(file.FileName);
                //removing whitespaces
                filename = filename.ToCharArray()
                 .Where(c => !Char.IsWhiteSpace(c))
                 .Select(c => c.ToString())
                 .Aggregate((a, b) => a + b);

                //checking directory is there or not if not create it
                string subPath = "~/Images/Movies/"; // your code goes here

                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                //finishing of directory creating


                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Images/Movies/" + filename));
                filepathtosave = "/Images/Movies/" + filename;
                /*Storing image path to show preview*/
                // ViewBag.ImageURL = filepathtosave;
                /*
                 * HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE
                 *
                 */

                //ViewBag.Message = "File Uploaded successfully.";
            }
            catch
            {
                ViewBag.Status = "Error in uploading image,please try again";
                return View(movie);
            }

            //ending of code for image
            //now setting image path
            movie.image = filepathtosave;

            noedit://for the GOTO statement
            //adding name position
            movie.NamePosition = SetNamePosition.Set(movie.Title);

            if (ModelState.IsValid)
           {
                
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowList", new { message = "addSuccess" });
           }
            ViewBag.Status = "Editing failed,please try again";
            return View(movie);
        }

        public ActionResult EditMovie(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
            
        }

        // GET: Movies/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try // log all exceptions
            {
                Movie movie = db.Movies.Find(id);
                string fullPath = Request.MapPath("~"+movie.image);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                db.Movies.Remove(movie);
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            catch (Exception x)
            {
                // All exceptions are written into Debug.
                //click show output from debug to see it
                Debug.WriteLine(x.ToString());
                ViewBag.Error = "Couldn't remove data";
                return RedirectToAction("ShowList");
               
            }
            
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
