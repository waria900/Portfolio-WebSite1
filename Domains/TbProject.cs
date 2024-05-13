using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{

    public partial class TbProject
    {
        [ValidateNever]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = null!;

        public string Description { get; set; } = null!;
        [ValidateNever]
        public string ImageName { get; set; } = null!;

        public string Link { get; set; } = null!;
        [ValidateNever]
        public string CreatedBy { get; set; } = null!;
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [ValidateNever]
        public int CurrentState { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        [Required(ErrorMessage = "Please select a Category.")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public virtual TbCategory Category { get; set; } = null!;
    }
}
