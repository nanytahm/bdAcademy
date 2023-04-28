using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreTestInnovar.DataService;

    public class AnswerStudentDataService
    {
        private Context _context;

    public AnswerStudentDataService(Context context){
        _context = context;
    }

    public List<tAnswerStudent> GetAnswerStudents(){
        return _context.AnswerStudents.ToList();
    }

    public List<tStudent> GetStudentByLastName(string lastName){
        return _context.Students.Where(student => student.LastName == lastName).ToList();
    }

    public List<tStudent> GetStudentByName(string name){
        return _context.Students.Where(student => student.Name == name).ToList();
    }

    public List<tStudent> GetStudentByCourseId(long idCourse){
        return _context.Students.Where(student=>student.IdCourse == idCourse).ToList();
    }

    public List<tStudent> GetStudentsWhitCourse(){
        return _context.Students.Include(student=>student.course).ToList();
    }

    public tStudent? UpdateNameOfStudent(long idCourse, string newName){
        var student = GetStudent(idCourse);
        if(student == null) return null;
        student.Name = newName;
        _context.SaveChanges();
        return student;
    }
    public tStudent? GetStudent(long id){
        var student = _context.Students.Find(id);
        return student;
    }

    public tStudent InsertStudent(tStudent student){
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }

    public tStudent? UpdateStudent(tStudent student){
        var studentDbo = _context.Students.Find(student.IdStudent);

        if(studentDbo == null) return null;

        studentDbo.Name= student.Name;
        studentDbo.LastName = student.LastName;
        studentDbo.IdCourse = student.IdCourse;
        _context.SaveChanges();
        return studentDbo;
    }

    public bool DeleteStudent(long id){
        var studentDbo = _context.Students.Find(id);
        if(studentDbo==null) return false;

        _context.Students.Remove(studentDbo);
        _context.SaveChanges();
        return true;
    }
    }
