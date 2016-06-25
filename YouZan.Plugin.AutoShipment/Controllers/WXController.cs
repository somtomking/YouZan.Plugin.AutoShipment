using NLog;
using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouZan.Plugin.AutoShipment.Controllers
{
    public class WXController : Controller
    {

        private string _Token = "somtomking";
        private string _EncodingAESKey = "D7VQIG7OdEgZTLK9MUGJ1OQJAbiroE8Vdq4yhR4UHTQ";
        private Logger _log = LogManager.GetCurrentClassLogger();
        // GET: WX
        public ActionResult Index()
        {
            _log.Debug("你好！微信");
            return View();
        }
        /// <summary>
        /// 微信验证
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        public ActionResult Entry(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, _Token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, _Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }

        }
    }
}
