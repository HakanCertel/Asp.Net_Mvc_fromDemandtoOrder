using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Senfoni.Satis.Webui.EmailServices;
using Senfoni.Satis.Webui.Identity;
using Senfoni.Satis.Webui.Models;
using Senfoni.Satis.Webui.Extensions;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Senfoni.Satis.Webui.Controllers
{
    //[Authorize(Roles="Admin")]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        //[AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null)
        {
            var principal = new ClaimsPrincipal(User.Identity);
            if (_signInManager.IsSignedIn(principal))
                return Redirect("/teklifler");
            
            return View(new LoginModel
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName );
            
            //var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return View(model);
            //if(await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    TempData["message"] = "Lütfen Email Hesabınıza Gelen Link ile Üyeliğinizi Onaylayın !";
            //    return View();
            //}

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage
                {
                    Title = "Giriş İşlemi Başarılı Birşekilde Gerçekleştirilmiştir.",
                    Message = "Giriş İşlemi Başarılı Birşekilde Gerçekleştirilmiştir...",
                    AlertType = "success"
                });
                return Redirect("/teklifler");
                //return RedirectToAction(model.ReturnUrl ?? "~/");
            }
                

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage
            {
                Title = "Çıkış İşlemi Başarılı Birşekilde Gerçekleştirilmiştir.",
                Message = "Çıkış İşlemi Başarılı Birşekilde Gerçekleştirilmiştir...",
                AlertType = "warning"
            });
            return Redirect("~/");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName=model.UserName,
                Email=model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //var code = _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var url = Url.Action("ConfirmEmail", "Account", new
                //{
                //    userId=user.Id,
                //    token=code
                //});

                //await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız", $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:44394/{url}'>tıklayınız.</a>");
                TempData.Put("message", new AlertMessage
                {
                    Title = "Üyelik İşleminiz Gerçekleştirildi.",
                    //Message = "Üyelik İşleminiz Gerçekleştirildi...",
                    AlertType = "success"
                });
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId==null || token==null)
            {
                TempData.Put("message", new AlertMessage
                {
                    Title = "Geçersiz Token",
                    Message = "Geçersiz Token.",
                    AlertType = "danger"
                });
                //CreateMessage("Geçersiz Token", "danger");
                return View();
            }

            var user = await  _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData.Put("message", new AlertMessage
                {
                    Title = "Kullanıcı Bulunamdı.",
                    Message = "Kullanıcı Bulunamdı.",
                    AlertType = "warning"
                });
                //CreateMessage("Kullanıcı Bulunamdı", "warning");
                return View();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage
                {
                    Title = "Hesabınız Onaylandı.",
                    Message = "Hesabınız Onaylandı.",
                    AlertType = "success"
                });
                return View();
            }
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                return View();
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
                return View();

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            await _emailSender.SendEmailAsync(Email, "Parola Yenile", $"Lütfen Parolanızı Yenilemk için linke <a href='https://localhost:44394/{url}'>tıklayınız.</a>");
            return View();
        }
        public IActionResult ResetPassword(string userId,string token)
        {
            if(userId==null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel
            {
                Token=token
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user==null)
                return RedirectToAction("Index", "Home");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if(result.Succeeded)
                return RedirectToAction("Login", "Account");

            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        //private void CreateMessage(string message,string alertType)
        //{
        //    var msg = new AlertMessage
        //    {
        //        Message = message,
        //        AlertType = alertType
        //    };
        //    TempData["message"] = JsonConvert.SerializeObject(msg);
        //}
    }
}