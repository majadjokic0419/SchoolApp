﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Dtos.Course
{
    public class EditCourseDto
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
