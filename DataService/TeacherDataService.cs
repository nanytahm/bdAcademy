using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreTestInnovar.DataService;


    public class TeacherDataService
    {
     private Context _context;

    public TeacherDataService(Context context){
        _context = context;
    }

    public List<tTeacher> GetTeachers(){
        return _context.Teachers.ToList();
    }

    public List<tTeacher> GetTeacherByLastName(string lastName){
        return _context.Teachers.Where(teacher => teacher.LastName == lastName).ToList();
    }

    public List<tTeacher> GetTeacherByName(string name){
        return _context.Teachers.Where(teacher => teacher.Name == name).ToList();
    }

    public List<tTeacher> GetTeacherByCourseId(long idCourse){
        return _context.Teachers.Where(teacher=>teacher.IdCourse == idCourse).ToList();
    }

    public List<tStudent> GetTeachersWhitCourse(){
        return _context.Teachers.Include(teacher=>teacher.course).ToList();
    }

    public tTeacher? UpdateNameOfTeacher(long idCourse, string newName){
        var teacher = GetTeachers(idCourse);
        if(teacher == null) return null;
        teacher.NameTeacher = newName;
        _context.SaveChanges();
        return teacher;
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
