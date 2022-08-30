using Domain.Models;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
