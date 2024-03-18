using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OrderManagementUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementUI.Pages
{
    public partial class SupplierView
    {
        [Inject]
        public ISupplierService SupplierService { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Suppliers = (await SupplierService.GetAllSuppliers()).ToList();
        }
    }
}
