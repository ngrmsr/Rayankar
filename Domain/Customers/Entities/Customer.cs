using Domain.Customers.Events;
using Framework.Domain;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Entities
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public ulong PhoneNumber { get; set; }
        [MaxLength(300)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        public string BankAccountNumber { get; set; }
        public Customer()
        {

        }
    }
}
