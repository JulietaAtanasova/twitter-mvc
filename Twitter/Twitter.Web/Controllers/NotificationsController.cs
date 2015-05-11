using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data.Data;

namespace Twitter.Web.Controllers
{
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            :base(data)
        {
            
        }
    }
}