using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData
                  (
              new Supplier
              {
                  Id = new Guid("391F8F7D-5F1D-46E1-BCFD-1148422342B1"),
                  Name = "ABC_Solutions Ltd",
                  AddressLine1 = "990 ABC XYZ, AdressLine1 ",
                  AddressLine2 = "USA",
                  City = "Huntsville",
                  PostalCode = "87474",
                  StateId = new Guid("739561C4-8BA5-4B56-AA11-9891882668F6")
              },
              new Supplier
              {
                  Id = new Guid("679C685E-2E9C-4C01-A786-D19E7FD10B48"),
                  Name = "XYZ_Solutions Ltd",
                  AddressLine1 = "120 ABC XYZ, AdressLine1 ",
                  AddressLine2 = "USA",
                  City = "Los Angeles",
                  PostalCode = "94992",
                  StateId = new Guid("32331D91-5B4E-4B20-8EA4-14062BCF1517")
              },
               new Supplier
               {
                   Id = new Guid("B4D1F629-0218-4629-9648-AA11451E64E3"),
                   Name = "GHJ_Solutions Ltd",
                   AddressLine1 = "120 ABC XYZ, AdressLine1 ",
                   AddressLine2 = "USA",
                   City = "Denver",
                   PostalCode = "80014",
                   StateId = new Guid("9A4AA09B-CE6E-4CC5-82DC-6928E4645DF7")
               },
               new Supplier
               {
                   Id = new Guid("87E1244C-01F6-45F5-A080-2BAB9E0319BB"),
                   Name = "New_Solutions Ltd",
                   AddressLine1 = "120 ABC XYZ, AdressLine1 ",
                   AddressLine2 = "USA",
                   City = "Little Rock",
                   PostalCode = "80014",
                   StateId = new Guid("13C1D98A-9420-4B20-AD16-105D73B9DD69")
               }
              );
        }
    }
}
