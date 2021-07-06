using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoView.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductListView()
        {
            //这里完整的View的初始化是 View("ProductListView")
            //不写，默认就是这个方法的名字
            return View();
        }

        public ActionResult NotFound() 
        {
            return View("NotFoundView");
        }

        public ActionResult ProductDetailView() 
        {
            return View();
        }

        //这种可以直接获取到值，但是这个参数不一定是基础类型，还可以自定义类型
        public ActionResult PDActionWithParams() 
        {
            return View();
        }

        public ActionResult PDFromRoute() {
            //外面是这么写的 route/params
            //如何拿到这个params
            //方法1. 使用request -----
            //                      request["filed"].toString 可以获取到表单和地址栏的值
            //                      request.queryString["filed"]  仅仅可以获取到地址栏的值
            //方法2. 使用RouteData
            Console.WriteLine("进入PDFromRoute方法，获取到url：", Request.Url);

            //var productId1 = Request["productIdInRouteConfig"].ToString();

            var productId2 = Request.QueryString["productIdInRouteConfig"];
            
            //var productId3 = RouteData.Values["productIdInRouteConfig"].ToString();

            //Console.WriteLine("------获取到id-----", productId1,"----", productId2,"----",productId3);
            //var productId3 = RouteData.Values["id"].ToString();
            Console.WriteLine("------获取到id-----", productId2);

            //好了 ，获取到了值，如何传到页面中去呢？
            //方式1， 使用Viewdata 
            //          ViewData["field"] = Value 在controller中赋值以后，然后在view中使用@ViewData["field"]获取值
            //方式2， 使用ViewBag 
            //          viewbag这个中间使用类似是字典，但是他的key是dynamic类型的
            //          ViewBag.field = value  在controller中赋值以后，然后在view中使用@ViewBag.field获取值
            // 上面两种方式的局限性在于，它们只能用在当前视图，不能用在其他的视图中。
            // 如果要用在其他的视图中，请使用 TempData，使用方式跟ViewData一样的。
            // 只不过作用域大一点，可以在其他的view中使用
            // 不过大也只能是在当前controller中使用
            // 还有跨控制器的 application
            // 个人会话 session ，因为它的数据是放在服务器上的。
            // 还有浏览器记录缓存 cookie，sessionid是放在cookie中的。
            ViewData["ProductIdInView"] = 985;
            ViewBag.bagProductId = 9999;


            return View("ProductDetailFromRouteParam"); 
        }
        public ActionResult PDFromQuery() {
            var productId2 = Request.QueryString["productId"] ?? "xProductId";
            string productTypeId = Request.QueryString["productTypeId"] ?? "xTypeId";
            ViewBag.QueryProductId = productId2;
            ViewBag.productTypeId = productTypeId;
            return View("ProductDetailFromQuery"); 
        }
        public ActionResult PDFromForm() { return View("ProductDetailFromForm"); }
    }
}