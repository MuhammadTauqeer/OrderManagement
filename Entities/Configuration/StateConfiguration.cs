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
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData
                (
                new State
                {
                    Id = new Guid("739561C4-8BA5-4B56-AA11-9891882668F6"),
                    Name = "Alabama",
                    AbbAbreviaton = "AL",
                },
                new State
                {
                    Id = new Guid("1FBDC0FA-D3CB-47B0-86F8-BB11A46CBFBA"),
                    Name = "Alaska",
                    AbbAbreviaton = "AK",
                },
                new State
                {
                    Id = new Guid("2D715FC3-1687-4723-A3D6-BB1E2B9FCB37"),
                    Name = "Arizona",
                    AbbAbreviaton = "AZ",
                },
                new State
                {
                    Id = new Guid("13C1D98A-9420-4B20-AD16-105D73B9DD69"),
                    Name = "Arkansas",
                    AbbAbreviaton = "AR",
                },
                 new State
                 {
                     Id = new Guid("32331D91-5B4E-4B20-8EA4-14062BCF1517"),
                     Name = "California",
                     AbbAbreviaton = "CA",
                 },
                 new State
                 {
                     Id = new Guid("9A4AA09B-CE6E-4CC5-82DC-6928E4645DF7"),
                     Name = "Colorado",
                     AbbAbreviaton = "CO",
                 }
                );
        }
    }
}
