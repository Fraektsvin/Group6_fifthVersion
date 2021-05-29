// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 2 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
using BlazorClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
using BlazorClient.Data.AdminValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
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
        }
        #pragma warning restore 1998
#nullable restore
#line 77 "C:\Users\HP\SEP3\Group6_Git\Group6System-main\Group6System-main\BlazorClient\BlazorClient\Pages\AdminValidation.razor"
       
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
