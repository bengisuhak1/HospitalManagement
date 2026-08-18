using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace HospitalManagement.Web;

public class ClinicDemoAccessMiddleware
{
    public const string CookieName = "ClinicDemoAccess";
    public const string ProtectorPurpose = "HospitalManagement.ClinicDemoAccess.v1";

    private static readonly string[] ProtectedPaths =
    {
        "/Patients", "/Doctors", "/Appointments", "/LabResults",
        "/Prescriptions", "/ExaminationNotes"
    };

    private readonly RequestDelegate _next;
    private readonly IDataProtector _protector;

    public ClinicDemoAccessMiddleware(RequestDelegate next, IDataProtectionProvider provider)
    {
        _next = next;
        _protector = provider.CreateProtector(ProtectorPurpose);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        var needsLogin = path == "/" || Array.Exists(
            ProtectedPaths,
            protectedPath => path.StartsWithSegments(protectedPath));

        if (needsLogin && !HasValidCookie(context.Request))
        {
            context.Response.Redirect("/ClinicLogin");
            return;
        }

        await _next(context);
    }

    private bool HasValidCookie(HttpRequest request)
    {
        if (!request.Cookies.TryGetValue(CookieName, out var protectedValue))
        {
            return false;
        }

        try
        {
            return !string.IsNullOrWhiteSpace(_protector.Unprotect(protectedValue));
        }
        catch
        {
            return false;
        }
    }
}
