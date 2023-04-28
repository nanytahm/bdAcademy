using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreTestInnovar.BusinessService;

namespace AcademyApi.Controllers;
    [ApiController]
    [Route("[controller]")]

    public class AlternativesController: ControllerBase
    {
         private StudentBusinessService _studentBusinessService;
        public StudentController(StudentBusinessService studentBusinessService){
            _studentBusinessService=studentBusinessService;
        }    
        //get student
        [HttpGet]
    public List<tStudent> GetStudents(){
        return _studentBusinessService.GetStudents();
    }

     //Get one student
    [HttpGet("{id}")]
    public tStudent? GetStudent(long id){
        return _studentBusinessService.GetStudent(id);
    }

    //Insert Beer
    [HttpPost]
    public tStudent InsertStudent(tStudent student){
        return _studentBusinessService.InsertStudent(student);
    }

    //Update 
    [HttpPut]
    public tStudent? UpdateStudent(tStudent student){
        return _studentBusinessService.UpdateBeer(student);
    }

    //Delete 
    [HttpDelete("{id}")]
    public bool DeleteStudent(long id){
        return _studentBusinessService.DeleteStudent(id);
    }
/*
    [HttpGet("[action]")]
    public List<tStudent> GetStudentsByYearBefore(int year){
        return _studentBusinessService.GetStudentsByYearBefore(year);
    }
*/
    [HttpPost("[action]")]
    public List<tStudent> GetStudentByName(string name){
        return _studentBusinessService.GetStudentByName(name);
    }

    [HttpPost("[action]")]
    public List<tStudent> GetStudentByCourseId(long idCourse){
        return _studentBusinessService.GetStudentByCourseId(idCourse);
    }

    [HttpPost("[action]")]
    public List<tStudent> GetStudentsWhitCourse(){
        return _studentBusinessService.GetStudentsWhitCourse();
    }
/*
    //Update Year
    [HttpPost("[action]")]
    public tStudent? UpdateYearOfBeer(long beerId, int newYear){
        return _studentBusinessService.UpdateYearOfBeer(beerId, newYear);
    }
*/
    //Get student names
    [HttpPost("[action]")]
    public List<string> GetStudentNames(){
        return _studentBusinessService.GetStudentNames();
    }
    
    //Get student names upper case
    [HttpPost("[action]")]
    public List<string> GetStudentNamesUpperCase(){
        return _studentBusinessService.GetStudentNamesUpperCase();
    }
}
