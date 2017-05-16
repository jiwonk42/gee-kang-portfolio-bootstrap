using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeeKang.Models;

namespace GeeKang.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            var projectList = Project.GetProjects();
            return View(projectList);
        }
    }
}