using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DccyOrigination.Common;
using DccyOrigination.EF;
using DccyOrigination.Models;
using DccyOrigination.Models.Result;
using DccyOrigination.Models.SysManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DccyOrigination.Controllers
{
    public class MenuController : Controller
    {
        #region 生成菜单树

        /// <summary>
        /// 用户所在部门Id集合
        /// </summary>
        private List<int> userDepIdList = new List<int>();
        /// <summary>
        /// 用户所在角色Id集合
        /// </summary>
        private List<int> userRoleIdList = new List<int>();
        /// <summary>
        /// 用户所在权限guid集合-》菜单guid集合
        /// </summary>
        private List<string> userJurGuidList = new List<string>();
        /// <summary>
        /// 用户根节点集合
        /// </summary>
        private List<AdmJurisdiction> RootMenu = new List<AdmJurisdiction>();
        /// <summary>
        /// 用户菜单集合
        /// </summary>
        private List<AdmJurisdiction> MenuList = new List<AdmJurisdiction>();
        /// <summary>
        ///        根节点菜单guid集合
        /// </summary>
        private List<string> rootmenuguids = new List<string>();
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 得到用户所在部门与角色中的菜单ids
        /// </summary>
        /// <param name="admUser"></param>
        /// <returns>菜单ID集合</returns>
        private List<string> GetMenuGuidByUserRoleIdORDepId(AdmUser admUser)
        {
            userDepIdList.Clear();
            userRoleIdList.Clear();
            userJurGuidList.Clear();
            RootMenu.Clear();
            MenuList.Clear();
            var userDeps = DBHandler.Db.AdmUserDepartment.Where(u => u.AdmUserId == admUser.Id && u.IsDelete == false).ToList();
            if (userDeps != null && userDeps.Count > 0)
            {
                #region 拓展Expression拼接lamada
                Expression<Func<AdmDepRole, bool>> expression = t => true;
                userDeps.ForEach(u =>
                {
                    if (!userDepIdList.Contains(u.AdmDepId))
                    {
                        userDepIdList.Add(u.AdmDepId);
                    }
                    expression = expression.And(t => t.DepId.Equals(u.AdmDepId) && t.IsDelete == false);
                });
                var admDepRoles = DBHandler.Db.AdmDepRole.AsQueryable().Where(expression).ToList();
                #endregion
                if (admDepRoles != null && admDepRoles.Count > 0)
                {
                    var roleJurs = DBHandler.Db.AdmRoleJur.Where(h => admDepRoles.Select(c1 => c1.RoleId).Any(c2 => h.AdmRoleId.Equals(c2))).ToList();
                    if (roleJurs != null && roleJurs.Count > 0)
                    {
                        roleJurs.ForEach(k =>
                        {
                            if (!userRoleIdList.Contains(k.AdmRoleId))
                            {
                                userRoleIdList.Add(k.AdmRoleId);
                            }
                            if (!userJurGuidList.Contains(k.AdmJurGuid))
                            {
                                userJurGuidList.Add(k.AdmJurGuid);
                            }
                        });
                    }
                }

            }
            #region Task测试


            //Task taskdep = DBHandler.Db.AdmDepartment.Where(u => u.Id == admUser.DepId).ForEachAsync(m =>
            //{
            //    if (m.IsDelete == false && !menuids.Contains(m.MenuGuid))
            //    {
            //        menuids.Add(m.MenuGuid);
            //    }
            //});
            //Task taskrole = DBHandler.Db.AdmRole.Where(u => u.Id == admUser.RoleId).AsQueryable().ForEachAsync(m =>
            //{
            //    if (m.IsDelete == false && !menuids.Contains(m.MenuGuid))
            //    {
            //        menuids.Add(m.MenuGuid);
            //    }
            //});
            //Task.WaitAll(taskdep, taskrole);
            #endregion
            return userJurGuidList;
        }


        /// <summary>
        /// 生成左侧菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLeftMenuTreeData()
        {

            string userSession = HttpContext.Session.GetString("AdmUserSession");
            if (!string.IsNullOrEmpty(userSession) && JsonConvert.DeserializeObject<AdmUser>(userSession).Id > 0)
            {
                AdmUser admUser = JsonConvert.DeserializeObject<AdmUser>(userSession);
                if (admUser != null && admUser.Id > 0)
                {
                    List<string> menuGuids = GetMenuGuidByUserRoleIdORDepId(admUser);
                    if (menuGuids.Count > 0)
                    {
                        //清空根节点guid集合
                        rootmenuguids.Clear();
                        //以集合做为条件查询数据库
                        var Menus = DBHandler.Db.AdmJurisdiction.Where(h => menuGuids.Select(c1 => c1).Any(c2 => h.Guid.Equals(c2))).ToList();
                        if (Menus != null && Menus.Count > 0)
                        {
                            Menus.ForEach(u =>
                            {
                                GetRootMenus(Menus, u);
                            });
                            if (RootMenu.Count > 0)
                            {
                                RootMenu.ForEach(u =>
                                {
                                    MenuList.Add(CreateMenuTree(Menus, u));
                                });
                                if (MenuList.Count > 0)
                                {
                                    return Json(new
                                    {
                                        StateCode = (int)ResultEnum.操作成功,
                                        Message = "请求成功",
                                        Data = MenuList
                                    });
                                }
                            }
                            else
                            {
                                return Json(new
                                {
                                    StateCode = (int)ResultEnum.操作失败,
                                    Message = "此用户暂无任何权限，请及时联系管理员！！！"
                                });
                            }
                        }
                    }
                }
            }
            return Json(new
            {
                StateCode = (int)ResultEnum.未登录,
                Message = "请选登录"
            });
        }

        /// <summary>
        /// 向上找根节点
        /// </summary>
        /// <param name="menulist"></param>
        /// <returns></returns>
        /// 
        private void GetRootMenus(List<AdmJurisdiction> menulist, AdmJurisdiction admJurisdiction)
        {
            if (menulist.Count > 0)
            {
                var menu = menulist.FirstOrDefault(u => u.Guid == admJurisdiction.PGuid);
                if (menu != null && menu.Id > 0)
                {
                    GetRootMenus(menulist, menu);
                }
                else
                {
                    if (!rootmenuguids.Contains(admJurisdiction.Guid))
                    {
                        rootmenuguids.Add(admJurisdiction.Guid);
                        RootMenu.Add(admJurisdiction);
                    }
                }
            }
        }
        /// <summary>
        /// 由根节点向下构建树
        /// </summary>
        /// <param name="menulist"></param>
        /// <param name="leftMenu"></param>
        /// <returns></returns>
        private AdmJurisdiction CreateMenuTree(List<AdmJurisdiction> menulist, AdmJurisdiction admJurisdiction)
        {
            if (menulist.Count > 0)
            {
                List<AdmJurisdiction> listm = menulist.Where(u => u.PGuid == admJurisdiction.Guid).ToList();
                if (listm != null && listm.Count > 0)
                {
                    admJurisdiction.Children = listm;
                    listm.ForEach(m =>
                    {
                        CreateMenuTree(menulist, m);
                    });
                }
            }
            return admJurisdiction;



        }

        #endregion


        #region 创建菜单项
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(IFormCollection collection, AdmJurisdiction admJurisdiction)
        {
            try
            {
                if (admJurisdiction != null)
                {

                    if (admJurisdiction.Id > 0)
                    {
                        DBHandler.Db.AdmJurisdiction.Update(admJurisdiction);
                        //var deprolejur = DBHandler.Db.AdmDepRole.FirstOrDefault(u => u.AdmJurGuid == admJurisdiction.Guid);
                        //if (deprolejur != null && deprolejur.Id > 0)
                        //{
                        //    if (deprolejur.DepId != admJurisdiction.AdmDepId || deprolejur.RoleId != admJurisdiction.AdmRoleId)
                        //    {
                        //        deprolejur.DepId = admJurisdiction.AdmDepId;
                        //        deprolejur.RoleId = admJurisdiction.AdmRoleId;
                        //        DBHandler.Db.AdmDepRole.Update(deprolejur);
                        //    }
                        //}
                    }
                    else
                    {
                        admJurisdiction.CreateTime = DateTime.Now;
                        DBHandler.Db.AdmJurisdiction.Add(admJurisdiction);
                        // var deprolejur = new AdmDepRoleJur() { DepId = admJurisdiction.AdmDepId, RoleId = admJurisdiction.AdmRoleId, AdmJurGuid = admJurisdiction.Guid,CreateTime=DateTime.Now };
                        // DBHandler.Db.AdmDepRole.Add(deprolejur);
                    }
                    int mint = DBHandler.DbSavaChange();
                    if (mint > 0)
                    {
                        return Json(new
                        {
                            StateCode = (int)ResultEnum.操作成功,
                            Message = "创建菜单成功",
                            Data = admJurisdiction
                        });
                    }
                }
                return Json(new
                {
                    StateCode = (int)ResultEnum.操作失败,
                    Message = "创建菜单失败"
                });

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region 删除菜单
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(string guid, IFormCollection collection)
        {
            try
            {
                if (guid != null && guid.Length > 10)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        #endregion
    }
}