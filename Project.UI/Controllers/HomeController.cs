using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITIES.Entities;
using Project.UI.Models;
using Project.UI.Models.AppUsers;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Project.UI.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly SignInManager<AppUser> _signInManager;
        



        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Yeni kayýt
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region RolKontrolIslemi
                IdentityRole<int> appRole = await _roleManager.FindByNameAsync("Member");
                if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });
                await _userManager.AddToRoleAsync(appUser, "Member");
                #endregion

               

               
               
                return RedirectToAction("RedirectPanel");
            }

            return View();


        }

       
        public IActionResult RedirectPanel()
        {
            return View();
        }

        //Giriþ
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserRegisterModel model)
        {
            AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);
            if (result.Succeeded)
            {
                IList<string> roles = await _userManager.GetRolesAsync(appUser);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }
                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Privacy"); //todo ShoppingTool
                }
                return RedirectToAction("Panel");
            }
            else if (result.IsNotAllowed)
            {
                return RedirectToAction("MailPanel");
            }
            TempData["Message"] = "Kullanýcý bulunamadý";

            return RedirectToAction("SignIn");

        }


        public IActionResult MailPanel()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
