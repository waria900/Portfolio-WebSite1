using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{

    public partial class TbService
    {
        [ValidateNever]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Enter service name.")]
        [StringLength(50, ErrorMessage = "Length is 50")]
        public string ServiceName { get; set; } = null!;

        [Required(ErrorMessage = "Enter a description.")]
        [StringLength(200, ErrorMessage = "Length is 50")]
        public string Description { get; set; } = null!;
        [ValidateNever]
        public string ImageName { get; set; } = null!;

        [ValidateNever]
        public string CreatedBy { get; set; } = null!;
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [ValidateNever]
        public int CurrentState { get; set; }
        [ValidateNever]
        public DateTime? UpdatedDate { get; set; }
        [ValidateNever]
        public string? UpdatedBy { get; set; }
    }
}
