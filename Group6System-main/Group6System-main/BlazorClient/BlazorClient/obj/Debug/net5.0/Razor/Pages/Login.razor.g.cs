#pragma checksum "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18221e1a9294bf1abe386033a24285daf7053e05"
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
#line 1 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
using BlazorClient.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "card");
                __builder2.AddMarkupContent(4, "<h4 class=\"card-header\">Login</h4>\r\n            ");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "card-body");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "form-group row");
                __builder2.AddMarkupContent(9, "<label class=\"col-form-label\">Username:</label>\r\n                ");
                __builder2.OpenElement(10, "input");
                __builder2.AddAttribute(11, "type", "text");
                __builder2.AddAttribute(12, "placeholder", "username");
                __builder2.AddAttribute(13, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 16 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                                                       _username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _username = __value, _username));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\r\n                ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "form-group row");
                __builder2.AddMarkupContent(18, "<label class=\"col-form-label\">Password:</label>\r\n                    ");
                __builder2.OpenElement(19, "input");
                __builder2.AddAttribute(20, "type", "password");
                __builder2.AddAttribute(21, "placeholder", "password");
                __builder2.AddAttribute(22, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 20 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                                                               _password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _password = __value, _password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n                ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "style", "color:red");
                __builder2.AddContent(27, 
#nullable restore
#line 22 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                        ErrorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n                ");
                __builder2.OpenElement(29, "button");
                __builder2.AddAttribute(30, "disabled", 
#nullable restore
#line 23 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                   _loading

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(31, "class", "btn btn-light");
                __builder2.AddAttribute(32, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                                                             PerformLoginAsync

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(33, "Login\r\n");
#nullable restore
#line 24 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                    if (_loading) 
                    {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(34, "<span class=\"spinner-border spinner-border-sm mr-1\"></span>");
#nullable restore
#line 27 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                   }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(35, "\r\n                \r\n                ");
                __builder2.OpenElement(36, "div");
                __builder2.AddMarkupContent(37, "<label>Don\'t have an account?</label>\r\n                    ");
                __builder2.OpenElement(38, "button");
                __builder2.AddAttribute(39, "class", "btn btn-light");
                __builder2.OpenElement(40, "a");
                __builder2.AddAttribute(41, "href", "");
                __builder2.AddAttribute(42, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                                             Signup

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(43, " Register here");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(44, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(45, "a");
                __builder2.AddAttribute(46, "href", "");
                __builder2.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
                             PerformLogoutAsync

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(48, "\r\n            Logout\r\n        ");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\Login.razor"
       
    private string _username;
    private string _password;
    private string ErrorMessage { get; set; }
    private bool _loading;

    public async Task PerformLoginAsync()
    {
        _loading = true;
        try
        {
            await ((CustomAuthenticationStateProvider) _authenticationStateProvider).ValidateLoginAsync(_username, _password);
            _navMgr.NavigateTo($"/NotificationPage");
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            _loading = false;
            Console.WriteLine(ErrorMessage);
        }
        
    }

    public async Task PerformLogoutAsync()
    {
        ErrorMessage = "";
        _username = "";
        _password = "";
        try
        {
            ((CustomAuthenticationStateProvider) _authenticationStateProvider).Logout();
            _navMgr.NavigateTo("/Login");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void Signup()
    {
        _navMgr.NavigateTo("/Customers");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navMgr { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
