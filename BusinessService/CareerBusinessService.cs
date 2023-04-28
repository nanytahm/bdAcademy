using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using NetCoreTestInnovar.DataService;

namespace NetCoreTestInnovar.BusinessService;

    public class CareerBusinessService
    {
        private CareerDataService _careerDataService;
    public CareerBusinessService(CareerDataService careerDataService){
        _careerDataService = careerDataService;
    }
    public List<tStudent> GetStudents(){
        var studentList = _studentDataService.GetStudents();
        return studentList;
    }

    public tStudent? GetStudent(long id){
        var student = _studentDataService.GetStudent(id);
        return student;
    }

    public tStudent InsertStudent(tStudent student){
        var studentInserted = _studentDataService.InsertStudent(student);
        return studentInserted;
    }

    public tStudent? UpdateBeer(tStudent student){
        return _studentDataService.UpdateStudent(student);
    }

    public bool DeleteStudent(long id){
        return _studentDataService.DeleteStudent(id);
    }

    public List<tStudent> GetStudentByLastName(string lastName){
        return _studentDataService.GetStudentByLastName(lastName);
    }

    public List<tStudent> GetStudentByName(string name){
        return _studentDataService.GetStudentByName(name);
    }

    public List<tStudent> GetStudentByCourseId(long idCourse){
        return _studentDataService.GetStudentByCourseId(idCourse);
    }

    public List<tStudent> GetStudentsWhitCourse(){
        return _studentDataService.GetStudentsWhitCourse();
    }
/*
    public tStudent? UpdateYearOfStudent(long IdStudent, int newYear){
        return _studentDataService.UpdateYearOfStudent(beerId, newYear);
    }*/

    public List<string> GetStudentNames(){
        //Get all 
        var studentList = _studentDataService.GetStudents();

        //Whit foreach
        List<string> studentNames = new List<string>();
        foreach(var student in studentList){
            studentNames.Add(student.Name);
        }        
        return studentNames;
    }

    public List<string> GetStudentNamesUpperCase(){
        var studentNames = GetStudentNames();
        List<string> studentNamesUpper = new List<string>();
        foreach(var studentName in studentNames){
            studentNamesUpper.Add(studentName.ToUpper());
        }
        return studentNamesUpper;
    }

    }
