using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcademyApi.Models
{
    public class tExamn
    {
        [Key]
        public long IdExam{get;set;}
        public string NroPreguntas{get;set;}
        public string Nota{get;set;}
        public long IdCourse {get;set;}

        [ForeignKey(nameof(IdCourse))]
        public tCourse? Courses {get;set;}
        public ICollection<tQuestions>? Questions{get;set;}

    }
}