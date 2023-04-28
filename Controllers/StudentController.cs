using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentController: ControllerBase
    {
        private Context _context;
        public StudentController(Context context){
            _context=context;
        }    
        //get student
        [HttpGet]
        public IEnumerable<tStudent>GetStudents(){
           return _context.Students.ToList();
        }
        [HttpPost]
    public tStudent InsertStudent(tStudent student){
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }

    //Update 
    [HttpPut]
    public tStudent? UpdateStudent(tStudent student){
        var studentDbo = _context.Students.Find(student.IdStudent);

        if(studentDbo == null) return null;

        studentDbo.Name = student.Name;
        _context.SaveChanges();
        return studentDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteStudent(long id){
        var studentDbo = _context.Students.Find(id);
        if(studentDbo==null) return false;

        _context.Students.Remove(studentDbo);
        _context.SaveChanges();
        return true;
    }
    }
}