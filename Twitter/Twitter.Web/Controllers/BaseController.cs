using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.Data;

namespace Twitter.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        private ITwitterData data;

        protected BaseController(ITwitterData data)
        {
            this.data = data;
        }

        protected ITwitterData Data { get { return this.data; } }
    }
}