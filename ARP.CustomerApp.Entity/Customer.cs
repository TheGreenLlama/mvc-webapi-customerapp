using System.ComponentModel.DataAnnotations;

namespace ARP.CustomerApp.Entity
{
    public class Customer
    {
        [Display(Name = "ID")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        [Display(Name = "Address Line 3")]
        public string Address3 { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        public string Town { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        public string County { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(8, ErrorMessage = "{0} exceeds the max length of {1} characters")]
        public string Postcode { get; set; }
    }
}
