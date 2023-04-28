using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.Models
{
    public class tQuestions
    {
        [Key]
        public long IdQuestion{get;set;}
        public string Question{get;set;}
        public string Tema{get;set;}

        public string Description{get;set;}
        public long IdExam {get;set;}

        [ForeignKey(nameof(IdExam))]
        public tExamn? Examn {get;set;}
        public ICollection<tAlternatives>? Alternatives{get;set;}
        public ICollection<tAnswerStudent>? AnswerStudents{get;set;}
    }
}