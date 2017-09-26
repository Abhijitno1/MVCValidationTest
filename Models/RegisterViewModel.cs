using MVCValidationTest.Customizations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCValidationTest.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType("Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} must be at least 8 and at most 20 chars long")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType("Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [Range(1, 6)]
        public int Rank { get; set; }

        [Display(Name = "Vehicle Number")]
        [RegularExpression(@"^[a-zA-Z]{2}-\d{2}-[a-zA-Z]{2}-\d{4}$", ErrorMessage = "Vehicle Number must be in format XX-**-XX-****")]
        public string VehicleNumber { get; set; }

        [ScaffoldColumn(false)]
        public string HiddenProperty { get; set; }

        [ReadOnly(true)]
        public string ReadOnlyProperty { get; set; }

        public bool CheckMark { get; set; }

        [PositiveNumber()]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Income { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString="{0:MM/dd/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime BirthDate { get; set; }

        public RoleType Role { get; set; }
    }
}