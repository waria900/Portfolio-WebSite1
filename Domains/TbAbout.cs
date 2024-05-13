using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{

    public partial class TbAbout
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a title.")]
        [StringLength(50, ErrorMessage = "Length is 50")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Enter a title.")]
        [StringLength(300, ErrorMessage = "Length is 300")]
        public string Description { get; set; } = null!;
    }
}
