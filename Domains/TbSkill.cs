using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbSkill
    {

        public int Id { get; set; }
        [ValidateNever]
        public string ImageName { get; set; }



    }
}
