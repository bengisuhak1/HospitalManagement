using Microsoft.AspNetCore.Builder;
using HospitalManagement;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("HospitalManagement.Web.csproj");
await builder.RunAbpModuleAsync<HospitalManagementWebTestModule>(applicationName: "HospitalManagement.Web" );

public partial class Program
{
}
