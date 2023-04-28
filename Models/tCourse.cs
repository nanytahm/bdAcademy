using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Models
{
    public class tCourse
    {
        [Key]
        public long IdCourse{get;set;}
        public string NameCourse{get;set;}
        //teacher
        public long IdTeacher{get;set;}
        
        [ForeignKey(nameof(IdTeacher))]
        public tTeacher? Teacher {get;set;}
        //exam
        public ICollection<tExamn>? Examns{get;set;}
        //student
        public ICollection<tStudent>? Students{get;set;}
    }
}