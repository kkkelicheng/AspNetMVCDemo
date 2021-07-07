using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoView.Models;

namespace MVCDemoView.Controllers
{
    public class MyUserController : Controller
    {
        // GET: MyUser
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View("UserLogin");
        }

        public ActionResult Register(UserInfo user) 
        {
            return View();
        }

        public ActionResult DoUserLoginAction(string account , string pwd)
        {
            //这两个属性是从 form表单中input中的name映射过来的

            //根据账号，密码查询返回一个对象
            if (account == "klc" && pwd == "123")
            {
                Session["userInfo"] = new UserInfo
                {
                    Account = "klc",
                    NickName = "niubi"
                };
                //这里还可以做一些其他的事情
                //HttpCookie cookie = new HttpCookie("userString");
                //cookie.Expires = DateTime.Now.AddMinutes(3);
                //Response.Cookies.Add(cookie);

                return View("../Home/index");
            }
            else {
                return View("UserLogin");
            }
            

        }

        //ajax触发的方法
        public string looklookUserName(string account) 
        {
            //去数据库查询一下account存在不
            //select count(1) from usertable where account = @account
            //1是存在的，0是不存在
            if (account.Length < 6)
            {
                return "1";
            }
            return "0";
        }
    }
}