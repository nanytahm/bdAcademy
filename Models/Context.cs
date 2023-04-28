using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context>options):base(options){

        }
        public DbSet<tStudent>Students{get;set;}
        public DbSet<tCourse> Courses {get;set;}
        public DbSet<tExamn>Examns{get;set;}
        public DbSet<tQuestions> Questions {get;set;}
        public DbSet<tAlternatives>Alternatives{get;set;}
        public DbSet<tAnswerStudent>AnswerStudents{get;set;}
        public DbSet<tTeacher> Teachers{get;set;}
        public DbSet<tCareer>Careers{get;set;}
        public DbSet<tProfesionalSchool>ProfesionalSchools{get;set;}
    }
}