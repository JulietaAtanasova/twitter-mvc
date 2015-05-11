using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.Data;

namespace Twitter.Web.Controllers
{
    public class BaseController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private ITwitterData data;

        protected BaseController()
        {
        }

        protected BaseController(ITwitterData data)
        {
            this.data = data;
        }

        private ITwitterData Data { get { return this.data; } }
        public ApplicationDbContext Db { get { return this.db; } }
    }
}