#pragma checksum "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "123472e89632c4ff0500440fedcdb646ab90ec39"
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
#line 1 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
using BlazorClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
using BlazorClient.Data.AdminValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
           [Authorize(Policy = "AdminRole")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AdminValidation")]
    public partial class AdminValidation : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Admin Page</h3>\r\n\r\n    \r\n    ");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\r\n        Filter by active status:\r\n        ");
            __builder.OpenElement(3, "select");
            __builder.AddAttribute(4, "class", "form-control selectpicker");
            __builder.AddAttribute(5, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                                                               (arg) => FilterByValidCustomers(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "style", "width:200px");
            __builder.OpenElement(7, "option");
            __builder.AddContent(8, "True");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "option");
            __builder.AddContent(11, "False");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 19 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
     if (_customersToShow == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(12, "<p><em>Loading ...</em></p>");
#nullable restore
#line 24 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
    }
    else if (!_customersToShow.Any())
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(13, "<p><em>No customers registered!</em></p>");
#nullable restore
#line 30 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(14, "table");
            __builder.AddAttribute(15, "class", "table table-striped");
            __builder.AddMarkupContent(16, @"<thead><tr><th scope=""col"">Cpr-Number</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Phone Number</th>
            <th scope=""col"">Email</th>
            <th scope=""col"">Nationality</th>
            <th scope=""col"">Street Name</th>
            <th scope=""col"">Street Number</th>
            <th scope=""col"">Zipcode</th>
            <th scope=""col"">City</th>
            <th scope=""col"">Country of Residence</th>
            <th scope=""col"">Username</th>
            <th scope=""col"">Remove</th>
            <th scope=""col"">Is Valid</th></tr></thead>
        ");
            __builder.OpenElement(17, "tbody");
#nullable restore
#line 50 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
         foreach (var c in _customersToShow)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(18, "tr");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 53 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.CprNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 54 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 55 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.PhoneNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 56 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                ");
            __builder.OpenElement(31, "td");
            __builder.AddContent(32, 
#nullable restore
#line 57 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Nationality

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                ");
            __builder.OpenElement(34, "td");
            __builder.AddContent(35, 
#nullable restore
#line 58 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Address.StreetName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                ");
            __builder.OpenElement(37, "td");
            __builder.AddContent(38, 
#nullable restore
#line 59 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Address.StreetNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                ");
            __builder.OpenElement(40, "td");
            __builder.AddContent(41, 
#nullable restore
#line 60 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Address.City.ZipCode

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n                ");
            __builder.OpenElement(43, "td");
            __builder.AddContent(44, 
#nullable restore
#line 61 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.Address.City.CityName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                ");
            __builder.OpenElement(46, "td");
            __builder.AddContent(47, 
#nullable restore
#line 62 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.CountryOfResidence

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n                ");
            __builder.OpenElement(49, "td");
            __builder.AddContent(50, 
#nullable restore
#line 63 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                     c.User.Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n                ");
            __builder.OpenElement(52, "td");
            __builder.OpenElement(53, "button");
            __builder.AddAttribute(54, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 65 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                                        () => RemoveCustomerAsync(c.CprNumber)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(55, "<i class=\"oi oi-trash\" style=\"color: red\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n                ");
            __builder.OpenElement(57, "td");
            __builder.OpenElement(58, "input");
            __builder.AddAttribute(59, "type", "checkbox");
            __builder.AddAttribute(60, "checked", 
#nullable restore
#line 70 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                                                    c.IsValid

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(61, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 70 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
                                                                           (arg) => ValidateCustomerAsync(arg, c)

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 73 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 77 "C:\Users\fatem\Documents\GitHub\Group6_fifthVersion\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
       
    private IList<Customer> _customers = new List<Customer>();
    private IList<Customer> _customersToShow = new List<Customer>();
    private bool? _filterByValidCustomers;

    protected override async Task OnInitializedAsync()
    {
        _customers = await _service.GetAllCustomersAsync();
        _customersToShow = _customers;
    }

    private async Task RemoveCustomerAsync(int cprNumber)
    {
        await _service.RemoveCustomerAsync(cprNumber);
        var customerToRemove = _customers.First(c => c.CprNumber == cprNumber);
        _customersToShow.Remove(customerToRemove);
    }

    private async Task ValidateCustomerAsync(ChangeEventArgs evt, Customer customer)
    {
        customer.IsValid = (bool) evt.Value;
        await _service.ValidateCustomerAsync(customer);
        _navigationManager.NavigateTo($"/CreateAccount/{customer.User.Username}");
    }

    private async Task FilterByValidCustomers(ChangeEventArgs evt)
    {
        _filterByValidCustomers = null;
        try
        {
            _filterByValidCustomers = bool.Parse(evt.Value.ToString());
            ExecuteFilter();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ExecuteFilter()
    {
        _customersToShow = _customers.Where
            (c => (_filterByValidCustomers != null && c.IsValid == _filterByValidCustomers)).ToList();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdminService _service { get; set; }
    }
}
#pragma warning restore 1591
