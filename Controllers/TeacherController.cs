using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController:ControllerBase
    {
        private Context _context;
        public TeacherController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tTeacher>GetTeachers(){
           return _context.Teachers.ToList();
        }
        [HttpPost]
    public tTeacher InsertTeacher(tTeacher teacher){
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return teacher;
    }

    //Update beer
    [HttpPut]
    public tTeacher? UpdateTeacher(tTeacher teacher){
        var teacherDbo = _context.Teachers.Find(teacher.IdTeacher);

        if(teacherDbo == null) return null;

        teacherDbo.Name = teacher.Name;
        _context.SaveChanges();
        return teacherDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteTeacher(long id){
        var teacherDbo = _context.Teachers.Find(id);
        if(teacherDbo==null) return false;

        _context.Teachers.Remove(teacherDbo);
        _context.SaveChanges();
        return true;
    }
    }
}