using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcademyApi.Models
{
    public class tTeacher
    {
        [Key]
        public long IdTeacher{get;set;}
        public string Name{get;set;}
        public string LastName{get;set;}
        public ICollection<tCourse>? Courses{get;set;}

    }
}