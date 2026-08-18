using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Web.Pages;

public class ClinicLoginModel : PageModel
{
    private readonly IDataProtector _protector;

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }

    public ClinicLoginModel(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector(ClinicDemoAccessMiddleware.ProtectorPurpose);
    }

    public IActionResult OnPost()
    {
        Username = Username.Trim();

        if (Username.Length == 0 || Password != "1")
        {
            ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
            return Page();
        }

        Response.Cookies.Append(
            ClinicDemoAccessMiddleware.CookieName,
            _protector.Protect(Username),
            new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                Secure = Request.IsHttps,
                Expires = DateTimeOffset.Now.AddHours(8)
            });

        return RedirectToPage("/Index");
    }
}
