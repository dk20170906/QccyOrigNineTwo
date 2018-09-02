using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.Common;
using DccyOrigination.EF;
using DccyOrigination.Models;
using DccyOrigination.Models.Result;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DccyOrigination.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SecurityCode()
        {
            string oldcode = TempData["SecurityCode"] as string;
            string code = TooUnit.CreateRandomCode(4); //验证码的字符为4个
            TempData["SecurityCode"] = code; //验证码存放在TempData中
            return File(TooUnit.CreateValidateGraphic(code), "image/Jpeg");
        }
        [HttpPost]
        public ActionResult Login(string acountName, string Tel, string password, string code)
        {
            AdmUser admUser = null;
            #region 用户名验证
            if (acountName != null && acountName.Length > 0 && acountName != "")
            {
                var user = DBHandler.Db.AdmUser.FirstOrDefault(u => u.UserAccounts == acountName || u.Email == acountName || u.Tel == acountName || u.UserName == acountName || u.Tel == Tel || u.UserAccounts == Tel || u.UserName == Tel || u.Email == Tel);
                if (user != null && user.Id > 0)
                {
                    admUser = user;
                }
                else
                {
                    ViewBag.LoginMsg = "请输入合法的登录帐号或帐号不存在！！！";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMsg = "请输入合法的登录帐号！！！";
                return View("Index");
            }
            #endregion
            #region 密码验证
            if (password != null && password.Length > 0 && password != "")
            {
                var userPwdEncode = EncryptionAndDecryption.Encode(password);
                if (admUser.Password.Equals(userPwdEncode))
                {
                }
                else
                {
                    ViewBag.LoginMsg = "密码错误！！！";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMsg = "请输入合法的登录密码！！！";
                return View("Index");
            }
            #endregion
            #region 验证码
            if (code != null && code.Length > 0 && code != "")
            {
                if (code.Equals(TempData["SecurityCode"]))
                {
                    HttpContext.Session.SetString("AdmUserSession", JsonConvert.SerializeObject(admUser));
                    Logger.Info(JsonConvert.SerializeObject("用户帐号："+ admUser.UserAccounts+",用户名："+admUser.UserName+",用户Emal:"+admUser.Email+",用户电话："+admUser.Tel));
                    return RedirectToRoute(new { Controller = "SysAdm", Action = "Index" });
                }
                else
                {
                    ViewBag.LoginMsg = "验证码输入错误！！！";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMsg = "请输入合法的验证码！！！";
                return View("Index");
            }
            #endregion

        }
        /// <summary>
        /// 协议书
        /// </summary>
        /// <returns></returns>
        public ActionResult Agreement()
        {
            return View();
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public IActionResult FindPassword()
        {
            return View();
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, AdmUser admUser)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}