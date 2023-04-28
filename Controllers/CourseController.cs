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
    public class CourseController: ControllerBase
    {
        private Context _context;
        public CourseController(Context context){
            _context=context;
        }    
        //get 
        [HttpGet]
        public IEnumerable<tCourse>GetCourses(){
           return _context.Courses.ToList();
        }
        [HttpPost]
    public tCourse InsertCourses(tCourse course){
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }

    //Update 
    [HttpPut]
    public tCourse? UpdateCourse(tCourse course){
        var courseDbo = _context.Courses.Find(course.IdCourse);

        if(courseDbo == null) return null;

        courseDbo.NameCourse = course.NameCourse;
        _context.SaveChanges();
        return courseDbo;
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteCourse(long id){
        var courseDbo = _context.Courses.Find(id);
        if(courseDbo==null) return false;

        _context.Courses.Remove(courseDbo);
        _context.SaveChanges();
        return true;
    }
    }
}