#pragma checksum "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24b1c3450242d4f919cd0a8dee9af18705b18bb2"
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
#line 2 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
using BlazorClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
using BlazorClient.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/RegisterCustomer")]
    public partial class RegisterCustomer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 7 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                  _addNewCustomer

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 7 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                                   RegisterNewCustomer

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(4);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "card");
                __builder2.AddMarkupContent(10, "<h4 class=\"card-header\">Register as a Customer</h4>\r\n        ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "card-body");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "col-sm-5");
                __builder2.AddMarkupContent(15, "\r\n                CPR Number:<br>\r\n                ");
                __Blazor.BlazorClient.Pages.RegisterCustomer.TypeInference.CreateInputNumber_0(__builder2, 16, 17, 
#nullable restore
#line 15 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                          _addNewCustomer.CprNumber

#line default
#line hidden
#nullable disable
                , 18, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.CprNumber = __value, _addNewCustomer.CprNumber)), 19, () => _addNewCustomer.CprNumber);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(20, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(21, "div");
                __builder2.AddAttribute(22, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(23);
                __builder2.AddAttribute(24, "id", "Name");
                __builder2.AddAttribute(25, "class", "form-control");
                __builder2.AddAttribute(26, "placeholder", "Name");
                __builder2.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _addNewCustomer.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.Name = __value, _addNewCustomer.Name))));
                __builder2.AddAttribute(29, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _addNewCustomer.Name));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(33);
                __builder2.AddAttribute(34, "id", "StreetName");
                __builder2.AddAttribute(35, "class", "form-control");
                __builder2.AddAttribute(36, "placeholder", "Street name");
                __builder2.AddAttribute(37, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _newAddressToAdd.StreetName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(38, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newAddressToAdd.StreetName = __value, _newAddressToAdd.StreetName))));
                __builder2.AddAttribute(39, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _newAddressToAdd.StreetName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(41, "div");
                __builder2.AddAttribute(42, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(43);
                __builder2.AddAttribute(44, "id", "StreetNumber");
                __builder2.AddAttribute(45, "class", "form-control");
                __builder2.AddAttribute(46, "placeholder", "Street number");
                __builder2.AddAttribute(47, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _newAddressToAdd.StreetNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(48, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newAddressToAdd.StreetNumber = __value, _newAddressToAdd.StreetNumber))));
                __builder2.AddAttribute(49, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _newAddressToAdd.StreetNumber));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "col-sm-5");
                __builder2.AddMarkupContent(53, "\r\n                ZipCode\r\n                ");
                __Blazor.BlazorClient.Pages.RegisterCustomer.TypeInference.CreateInputNumber_1(__builder2, 54, 55, 
#nullable restore
#line 35 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                          _newCityToAdd.ZipCode

#line default
#line hidden
#nullable disable
                , 56, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newCityToAdd.ZipCode = __value, _newCityToAdd.ZipCode)), 57, () => _newCityToAdd.ZipCode);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(59, "div");
                __builder2.AddAttribute(60, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(61);
                __builder2.AddAttribute(62, "id", "CityName");
                __builder2.AddAttribute(63, "class", "form-control");
                __builder2.AddAttribute(64, "placeholder", "City name");
                __builder2.AddAttribute(65, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _newCityToAdd.CityName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(66, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newCityToAdd.CityName = __value, _newCityToAdd.CityName))));
                __builder2.AddAttribute(67, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _newCityToAdd.CityName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(68, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(69, "div");
                __builder2.AddAttribute(70, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(71);
                __builder2.AddAttribute(72, "id", "Email");
                __builder2.AddAttribute(73, "class", "form-control");
                __builder2.AddAttribute(74, "placeholder", "Email");
                __builder2.AddAttribute(75, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _addNewCustomer.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(76, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.Email = __value, _addNewCustomer.Email))));
                __builder2.AddAttribute(77, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _addNewCustomer.Email));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(78, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(79, "div");
                __builder2.AddAttribute(80, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(81);
                __builder2.AddAttribute(82, "id", "PhoneNumber");
                __builder2.AddAttribute(83, "class", "form-control");
                __builder2.AddAttribute(84, "placeholder", "PhoneNumber");
                __builder2.AddAttribute(85, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 50 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _addNewCustomer.PhoneNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(86, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.PhoneNumber = __value, _addNewCustomer.PhoneNumber))));
                __builder2.AddAttribute(87, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _addNewCustomer.PhoneNumber));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(89, "div");
                __builder2.AddAttribute(90, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(91);
                __builder2.AddAttribute(92, "id", "Nationality");
                __builder2.AddAttribute(93, "class", "form-control");
                __builder2.AddAttribute(94, "placeholder", "Nationality");
                __builder2.AddAttribute(95, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _addNewCustomer.Nationality

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(96, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.Nationality = __value, _addNewCustomer.Nationality))));
                __builder2.AddAttribute(97, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _addNewCustomer.Nationality));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(98, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(99, "div");
                __builder2.AddAttribute(100, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(101);
                __builder2.AddAttribute(102, "id", "Residence");
                __builder2.AddAttribute(103, "class", "form-control");
                __builder2.AddAttribute(104, "placeholder", "Residence");
                __builder2.AddAttribute(105, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 60 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _addNewCustomer.CountryOfResidence

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(106, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _addNewCustomer.CountryOfResidence = __value, _addNewCustomer.CountryOfResidence))));
                __builder2.AddAttribute(107, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _addNewCustomer.CountryOfResidence));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(108, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(109, "div");
                __builder2.AddAttribute(110, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(111);
                __builder2.AddAttribute(112, "id", "Username");
                __builder2.AddAttribute(113, "class", "form-control");
                __builder2.AddAttribute(114, "placeholder", "Username");
                __builder2.AddAttribute(115, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _newUserToAdd.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(116, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newUserToAdd.Username = __value, _newUserToAdd.Username))));
                __builder2.AddAttribute(117, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _newUserToAdd.Username));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(118, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(119, "div");
                __builder2.AddAttribute(120, "class", "col-sm-7");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(121);
                __builder2.AddAttribute(122, "id", "Password");
                __builder2.AddAttribute(123, "class", "form-control");
                __builder2.AddAttribute(124, "placeholder", "Password");
                __builder2.AddAttribute(125, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 70 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                        _newUserToAdd.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(126, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _newUserToAdd.Password = __value, _newUserToAdd.Password))));
                __builder2.AddAttribute(127, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _newUserToAdd.Password));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(128, "\r\n            <br>\r\n            \r\n            ");
                __builder2.OpenElement(129, "div");
                __builder2.AddAttribute(130, "style", "color:red");
                __builder2.AddContent(131, 
#nullable restore
#line 74 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                                    ErrorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(132, "\r\n            \r\n            ");
                __builder2.OpenElement(133, "button");
                __builder2.AddAttribute(134, "disabled", 
#nullable restore
#line 76 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                               _loading

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(135, "class", "btn btn-light");
                __builder2.AddAttribute(136, "type", "submit");
                __builder2.AddMarkupContent(137, "Register\r\n");
#nullable restore
#line 77 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                 if (_loading) 
                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(138, "<span class=\"spinner-border spinner-border-sm mr-1\"></span>");
#nullable restore
#line 80 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 87 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\RegisterCustomer.razor"
       
    private readonly Customer _addNewCustomer = new Customer();
    private readonly Address _newAddressToAdd = new Address();
    private readonly City _newCityToAdd = new City();
    private readonly User _newUserToAdd = new User();
    private string ErrorMessage { get; set; }
    private bool _loading;

    private async Task RegisterNewCustomer()
    {
        _loading = true;
        try
        {
            _newAddressToAdd.City = _newCityToAdd;
            _addNewCustomer.Address = _newAddressToAdd;
            _addNewCustomer.User = _newUserToAdd;
            string successMessage = await ((CustomAuthenticationStateProvider)_service).ValidateRegisterAsync(_addNewCustomer);
                ErrorMessage = successMessage;
            _loading = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            ErrorMessage = e.Message;
            _loading = false;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider _service { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
    }
}
namespace __Blazor.BlazorClient.Pages.RegisterCustomer
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
