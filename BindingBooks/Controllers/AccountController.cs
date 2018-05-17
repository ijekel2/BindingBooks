using System;
using System.Linq;
using System.Security.Claims;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BindingBooks.Models;
using BindingBooks.Utilities;
using BindingBooks.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BindingBooks.Controllers
{
    public class AccountController : Controller
    {
        
        protected UserManager<ApplicationUser> UserManager { get; set; }
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            using (var db = ApplicationDbContext.Create())
            {
                RegisterViewModel newUser = new RegisterViewModel
                {
                    MembershipTypes = db.MembershipTypes.ToList(),
                    BirthDate = DateTime.Now
                };
                return View(newUser);
            }
        }
        
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = model.Email,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    LastName=model.LastName,
                    FirstName=model.FirstName,
                    PhoneNumber= model.Phone,
                    MembershipTypeId=model.MembershipTypeId,
                    Disabled = false
                };
                
              
                var result = await  UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    using (var db = ApplicationDbContext.Create())
                    {
                        model.MembershipTypes = db.MembershipTypes.ToList();
                        var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                        var roleManager = new RoleManager<IdentityRole>(roleStore);
                        var memebership = model.MembershipTypes.SingleOrDefault(m => m.Id == model.MembershipTypeId).Name;

                        if(memebership.ToLower().Contains("admin"))
                        {
                            //For Super Admin
                            await roleManager.CreateAsync(new IdentityRole(StaticDetails.AdminUserRole));
                            await UserManager.AddToRoleAsync(user.Id, StaticDetails.AdminUserRole);
                        }
                        else
                        {
                            //For Customer
                            await roleManager.CreateAsync(new IdentityRole(StaticDetails.EndUserRole));
                            await UserManager.AddToRoleAsync(user.Id, StaticDetails.EndUserRole);
                        }
                    }
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            using (var db = ApplicationDbContext.Create())
            {
                model.MembershipTypes = db.MembershipTypes.ToList();
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}