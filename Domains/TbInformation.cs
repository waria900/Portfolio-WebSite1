using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbInformation
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Write a first name.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50.")]
        public string firstName { get; set; } = null!;
        [Required(ErrorMessage = "Write a second name.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50.")]
        public string secondName { get; set; } = null!;
        [Required(ErrorMessage = "Write an email.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50.")]
        [EmailAddress(ErrorMessage = "Enter an email form. ")]
        public string Email { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50.")]
        //[RegularExpression(@"^\(?([0-11]{0})\)?[-. ]?([0-11]{3})[-. ]?([0-11]{4})$",
        //           ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; } = null!;


        [Required(ErrorMessage = "Enter linkedin link.")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500.")]
        public string Linkedin { get; set; } = null!;
        [Required(ErrorMessage = "Enter Github link.")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500.")]
        public string Github { get; set; } = null!;
        [Required(ErrorMessage = "Enter Twitter link.")]
        [MaxLength(500, ErrorMessage = "Maximum length is 500.")]
        public string Twitter { get; set; } = null!;


    }
}
