using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validate.Models;

namespace Validate.Controllers
{
    public class HomeController : Controller
    {
        #region 手工验证绑定的参数
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            Validate(person);
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }

        private void Validate(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                ModelState.AddModelError("Name", "'Name'是必须字段");
            }

            if (string.IsNullOrEmpty(person.Gender))
            {
                ModelState.AddModelError("Gender", "'Gender'是必须字段");
            }
            else if (!new string[] { "M", "F" }.Any(g => string.Compare(person.Gender, g, true) == 0))
            {
                ModelState.AddModelError("Gender", "有效'Gender'必须是'M','F'之一");
            }

            if (null == person.Age)
            {
                ModelState.AddModelError("Age", "'Age'是必须字段");
            }
            else if (person.Age > 25 || person.Age < 18)
            {
                ModelState.AddModelError("Age", "有效'Age'必须在18到25岁之间");
            }
        } 
        #endregion

        #region 使用ValidationAttribute特性 
        [HttpGet]
        public ActionResult Index2()
        {
            return View(new Person2());
        }

        [HttpPost]
        public ActionResult Index2(Person2 person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        } 
        #endregion

        #region 让数据类型实现IValidatableObject接口

        public ActionResult Index3()
        {
            return View(new Person3());
        }

        [HttpPost]
        public ActionResult Index3(Person3 person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }
        #endregion

        #region 让数据类型实现IDataErrorInfo接口

        public ActionResult Index4()
        {
            return View(new Person4());
        }

        [HttpPost]
        public ActionResult Index4(Person4 person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }
        #endregion
    }
}
