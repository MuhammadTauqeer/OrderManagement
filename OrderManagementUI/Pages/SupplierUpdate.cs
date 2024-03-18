using Entities.Models;
using Microsoft.AspNetCore.Components;
using OrderManagementUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementUI.Pages
{
    public partial class SupplierUpdate
    {
        [Inject]
        public ISupplierService SuppplierService { get; set; }
        [Inject]
        public IStateService StateService { get; set; }

        [Parameter]
        public string SupplierId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string PageHeaderText { get; set; }

        public Supplier Supplier { get; set; } = new Supplier();
        public List<State> States { get; set; } = new List<State>();

        protected string StateId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            States = (await StateService.GetAllStates()).ToList();

            Guid.TryParse(SupplierId, out var supplierId);

            if (supplierId == Guid.Empty) //new supplier is being created
            {
                PageHeaderText = "Create Supplier";
                Supplier = new Supplier { StateId = new Guid("578FA54E-0197-4B12-BDB2-5443C7FE0377") };
            }
            else
            {
                PageHeaderText = "Update Supplier";
                Supplier = await SuppplierService.GetSupplierDetails(Guid.Parse(SupplierId));
            }

            StateId = Supplier.StateId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            Supplier.StateId = Guid.Parse(StateId);

            if (Supplier.Id == Guid.Empty) //new
            {
                var addedSupplier = Supplier;
                if (addedSupplier != null)
                {
                    addedSupplier = await SuppplierService.AddSupplier(Supplier);
                    StatusClass = "alert-success";
                    Message = "New supplier added successfully.";
                    Saved = true;
                }

                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new supplier. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await SuppplierService.UpdateSupplier(Supplier);
                StatusClass = "alert-success";
                Message = "Supplier updated successfully.";
                Saved = true;
            }

            //if (Saved == true)
            //{
            //    await Task.Delay(3500);
            //    //    //System.Threading.Thread.Sleep(3500);
            //    //    //NavigationManager.NavigateTo("supplierview");
            //}
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteSupplier()
        {
            await SuppplierService.DeleteSupplier(Supplier.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToMainview()
        {
            NavigationManager.NavigateTo("/SupplierView");
        }
    }
}

