using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.Data;
using Twitter.Models;

namespace Twitter.Web.Controllers
{
    public class TweetsController : BaseController
    {

        public TweetsController(ITwitterData data) 
            : base(data)
        {
        }

        // GET: Tweets
        public ActionResult Index()
        {
            var tweets = Data.Tweet.All().Include(t => t.Author);
            return View(tweets.ToList());
        }

        // GET: Tweets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = Data.Tweet.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: Tweets/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(Data.User.All(), "Id", "Email");
            return View();
        }

        // POST: Tweets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,AuthorId,CreatedOn,Url")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                Data.Tweet.Add(tweet);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(Data.User.All(), "Id", "Email", tweet.AuthorId);
            return View(tweet);
        }

        // GET: Tweets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = Data.Tweet.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(Data.User.All(), "Id", "Email", tweet.AuthorId);
            return View(tweet);
        }

        // POST: Tweets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,AuthorId,CreatedOn,Url")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                Data.Tweet.Update(tweet);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(Data.User.All(), "Id", "Email", tweet.AuthorId);
            return View(tweet);
        }

        // GET: Tweets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = Data.Tweet.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = Data.Tweet.Find(id);
            Data.Tweet.Delete(tweet);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
