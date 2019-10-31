using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        



        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int? ZipCode { get; set; }

        [Display(Name = "Pick Up Day")]
        public DateTime? PickUpDay { get; set; }

        [Display(Name = "Balance")]
        public double? Balance { get; set; }

        [Display(Name = "Monthly Charge")]
        public double? MonthlyCharge { get; set; }

        [Display(Name = "Pick Up Confirmed")]
        public bool PickUpConfirmed { get; set; }

        [Display(Name = "Start")]
        public DateTime? Start { get; set; }

        [Display(Name = "End")]
        public DateTime? End { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}