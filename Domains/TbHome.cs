using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{

    public partial class TbHome
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        [StringLength(50, ErrorMessage = "please enter less than 50 characters")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Enter your major.")]
        [StringLength(50, ErrorMessage = "please enter less than 50 characters")]
        public string Major { get; set; } = null!;
        [ValidateNever]
        public string ImageName { get; set; } = null!;
        [ValidateNever]
        public string FileName { get; set; } = null!;
    }
}
