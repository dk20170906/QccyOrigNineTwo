using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.Common;
using DccyOrigination.EF;
using DccyOrigination.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DccyOrigination.Controllers.SystemAdm
{
    public class AdmUserController : Controller
    {
        // GET: AdmUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdmUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmUser/Create
        public ActionResult Create()
        {
            AdmUser admUser = new AdmUser() {
                UserName = "123456",
                UserAccounts="123456",
                Password = "123456",
                Guid = Guid.NewGuid().ToString().ToUpper(),
                DepId = 2,
                RoleId = 1,
                LastLoginTime = DateTime.Now,
                Sex = 1,
                NumOfLogins = 1

            };
            admUser.CreateTime = DateTime.Now;
            admUser.Password = EncryptionAndDecryption.Encode(admUser.Password);
            // _DccyDbContext.AdmUser.Add(admUser);
            DBHandler.Db.AdmUser.Add(admUser);
          int m=  DBHandler.DbSavaChange();
            return View();
        }

        // POST: AdmUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection, AdmUser admUser)
        {




            try
            {
                // TODO: Add insert logic here
                if (admUser.Id > 0)
                {
                    admUser.Password = EncryptionAndDecryption.Encode(admUser.Password);
                    DBHandler.Db.AdmUser.Update(admUser);
                }
                else
                {
                    admUser.CreateTime = DateTime.Now;
                    admUser.Password = EncryptionAndDecryption.Encode(admUser.Password);
                    // _DccyDbContext.AdmUser.Add(admUser);
                    DBHandler.Db.AdmUser.Add(admUser);
                }
                int m = DBHandler.DbSavaChange();
                if (m>0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return null;
                }
           
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error","Home",new ErrorViewModel { RequestId =ex.Message});
            }
        }

        // GET: AdmUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmUser/Edit/5
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

        // GET: AdmUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmUser/Delete/5
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