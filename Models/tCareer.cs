using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyApi.Models
{
    public class tCareer
    {
        [Key]
        public long IdCareer{get;set;}
        public string NameCareer{get;set;}
        public long IdProfesionalSchool {get;set;}

        [ForeignKey(nameof(IdProfesionalSchool))]
        public tProfesionalSchool? ProfesionalSchool {get;set;}
        //course
        public ICollection<tCourse>? Courses{get;set;}

    }
}