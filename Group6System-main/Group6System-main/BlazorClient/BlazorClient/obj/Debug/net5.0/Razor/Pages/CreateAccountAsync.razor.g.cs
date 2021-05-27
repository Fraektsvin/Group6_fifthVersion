#pragma checksum "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23e99fd82d8463b4f3b4825e9b3b8460ad22c63d"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
using BlazorClient.Data.AdminValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
using BlazorClient.Data.NotificationService;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/CreateAccount/{Username}")]
    public partial class CreateAccountAsync : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h1");
            __builder.AddContent(1, " Create Account for : ");
            __builder.AddContent(2, 
#nullable restore
#line 7 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
                           Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "disabled", 
#nullable restore
#line 8 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
                   _loading

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(6, "class", "btn btn-light");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
                                                             CreateAccountFor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(8, "Create Account\r\n");
#nullable restore
#line 9 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
     if (_loading) 
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "<span class=\"spinner-border spinner-border-sm mr-1\"></span>");
#nullable restore
#line 12 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "C:\Users\const\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\CreateAccountAsync.razor"
       
    [Parameter] public string  Username { get; set; }
    private bool _loading;
    private bool _loading1;
    private string _errorMessage;


    private async Task CreateAccountFor()
    {
        _loading = true;
        try
        {
          String successMessage = await _service.CreateAccountAsync(Username);
          _errorMessage = successMessage;
            //await _notification.SendNotificationToUserAsync(Username);
            _loading = false;
        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
        }
    }

  /*  private async Task SendNotificationAsync()
    {
        _loading1 = true;
        try
        {
             await _notification.SendNotificationToUserAsync(Username);
            _loading1 = false;
        }
        catch (Exception e)
        {
            _errorMessage = e.Message;
            _loading1 = false;
        }
    }*/


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdminService _service { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private INotificationService _notification { get; set; }
    }
}
#pragma warning restore 1591