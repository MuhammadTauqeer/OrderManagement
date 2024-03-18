using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OrderManagementUI.Services;
using System;
using System.Threading.Tasks;

namespace OrderManagementUI.Pages
{
    public partial class SupplierDetails
    {
        [Parameter]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        [Inject]
        public ISupplierService SupplierService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        [Inject]
        public IJSRuntime Js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Supplier = await SupplierService.GetSupplierDetails(Guid.Parse(SupplierId));
        }

        protected void NavigateToMainview()
        {
            NavigationManager.NavigateTo("/SupplierView");
        }

        protected async Task DeleteSupplier()
        {
            await SupplierService.DeleteSupplier(Supplier.Id);
            StatusClass = "alert-success";
            Message = "Supplier updated successfully.";
            Saved = true;
            NavigationManager.NavigateTo("/SupplierView");
        }

        //private async Task Delete(Guid Id)
        //{
        //    var supplier = Suppliers.FirstOrDefault(p => p.Id.Equals(Id));

        //    var confirmed = await Js.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {supplier.Name} suppllier?");
        //    if (confirmed)
        //    {
        //        await DeleteSupplier(Id);
        //    }
        //}
    }
}
