using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwProject
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageName { get; set; } = null!;

        public string Link { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int CurrentState { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }= null!;
    }
}
