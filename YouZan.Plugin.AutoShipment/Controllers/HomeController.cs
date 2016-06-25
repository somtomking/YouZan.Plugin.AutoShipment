using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouZan.SDK;
namespace YouZan.Plugin.AutoShipment.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
           
            return View();
        }
       
        //获取所有支付的商品
        public ActionResult GetPayedOrders(string appID,string appSecert)
        {
            var api = new KDTApiKit(appID, appSecert);
            var parames = new Dictionary<string, string>();
            var data = api.get("kdt.trades.sold.get", parames);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //获取指定订单的详细信息
        public ActionResult GetOrderInfo(string orderId, string appID, string appSecert)
        {
            var api = new KDTApiKit(appID, appSecert);
            var parames = new Dictionary<string, string>();
            parames.Add("code", orderId);
            var data = api.get("kdt.trade.virtualcode.get", parames);
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        //核销虚拟商品订单
        public ActionResult UseOrderInfo(string orderId, string appID, string appSecert)
        {
            var api = new KDTApiKit(appID, appSecert);
            var parames = new Dictionary<string, string>();
            parames.Add("code", orderId);
            var data = api.get("kdt.trade.virtualcode.apply", parames);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //根据粉丝ID，给粉丝授权优惠码
        public ActionResult GetCouponWithWechatId(string couponGroupId, string wechatId, string appID, string appSecert)
        {
            var api = new KDTApiKit(appID, appSecert);
            var parames = new Dictionary<string, string>();
            parames.Add("coupon_group_id", couponGroupId);
            parames.Add("fans_id", wechatId);
            
            var data = api.get("kdt.ump.coupon.take", parames);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取所有未结束的优惠列表（包含未开始的、进行中的）
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="appSecert"></param>
        /// <returns></returns>
        public ActionResult GetUnfinishedCoupons( string appID, string appSecert)
        {
            var api = new KDTApiKit(appID, appSecert);
            var parames = new Dictionary<string, string>();
            var data = api.get("kdt.ump.coupons.unfinished.all", parames);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
