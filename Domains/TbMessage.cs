using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{

    public partial class TbMessage
    {
        [ValidateNever]
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Write a name.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 100.")]
        public string? Name { get; set; }
    
        [Required(ErrorMessage = "Write an email.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 100.")]
        [EmailAddress(ErrorMessage ="Enter an email form. ")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Write a subject.")]
        [MaxLength(50, ErrorMessage = "Maximum length is 100.")]
        public string? Subject { get; set; }
        
        [Required(ErrorMessage = "Write a message.")]
        public string? Message { get; set; }
        [ValidateNever]
        public DateTime? CreatedDate { get; set; }
        [ValidateNever]
        public int? CurrentState { get; set; }
    }
}
