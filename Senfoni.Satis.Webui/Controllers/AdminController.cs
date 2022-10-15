using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Senfoni.Data.Concrete.EfCore;
using Senfoni.Data.Concrete.EfCore.GenelBll;
using Senfoni.Entity;
using Senfoni.Satis.Webui.Extensions;
using Senfoni.Satis.Webui.Identity;
using Senfoni.Satis.Webui.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senfoni.Satis.Webui.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController:Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IBaseBll cariBll;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            cariBll = new CariBll();
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult CariCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CariCreate(Cari model)
        {
            var kod = ((CariBll)cariBll).YeniKodVer();
            var id = GeneralFunctions.IdOlustur();
            var cari = new Cari
            {
                Id = id,
                Kod = kod,
                CariAdi = model.CariAdi,
                Adres = model.Adres,
                Telefon1 = model.Telefon1,
                Durum = true,
            };
            if (((CariBll)cariBll).Insert(cari))
            {
                TempData["message"] = "Kayıt İşlemi Gerçekleştirildi";
                return Redirect("~/admin/cari/list");
            }
            return View(model);
        }
        public IActionResult CariList()
        {
            var list = ((CariBll)cariBll).List(null).EntityListConvert<Cari>();
            return View(list);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user =await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var selectedRoles =await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(x => x.Name);
                ViewBag.Roles = roles;
                return View(new UserDetailModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailModel model,string[] selectedRoles)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.EmailConfirmed = model.EmailConfirmed;

                var result =await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                    await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray());

                    return Redirect("/admin/user/list");
                }
            }
            return View(model);
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                    ?members
                    :nonMembers;
                list.Add(user);
            }
            var model = new RoleDetails
            {
                Role=role,
                Members=members,
                NonMembers=nonMembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            foreach (var userId in model.IdsToAdd??new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            foreach (var userId in model.IdsToDelete ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }

            return Redirect("/admin/role/edit/"+model.RoleId);
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole
            {
                Name=model.Name
            });
            if (result.Succeeded)
                return RedirectToAction("RoleList");

            return View(model);
        }
    }
}
