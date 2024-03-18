using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("state")]
    public class State
    {
        [Column("StateId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string Name { get; set; }
        [StringLength(2, ErrorMessage = "AbbAbreviaton cannot be longer than 2 characters")]
        public string AbbAbreviaton { get; set; }
    }
}
