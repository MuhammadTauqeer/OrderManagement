using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("supplier")]
    public class Supplier
    {
        [Column("SupplierId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(15, ErrorMessage = "Postal Code cannot be longer than 15 characters")]
        public string PostalCode { get; set; }
        [ForeignKey(nameof(State))]
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}
