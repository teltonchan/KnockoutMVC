﻿using KnockoutMVC.EntityDataModel;
using System.Collections.Generic;
using System.Linq;

namespace KnockoutMVC.Models
{
    /// <summary>
    /// Student data repository
    /// </summary>
    public class StudentRepository
    {
        private static STUDENTDATABASEEntities _studentDb;

        private static STUDENTDATABASEEntities StudentDb
        {
            get { return _studentDb ?? (_studentDb = new STUDENTDATABASEEntities()); }
        }

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns>IEnumerable Student List</returns>
        public static IEnumerable<Student> GetStudents()
        {
            var query = from students in StudentDb.Students select students;
            return query.ToList();
        }

        /// <summary>
        /// Inserts the student to database.
        /// </summary>
        /// <param name="student">The student object to insert.</param>
        public static void InsertStudent(Student student)
        {
            StudentDb.Students.Add(student);
            StudentDb.SaveChanges();
        }

        /// <summary>
        /// Deletes student from database.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        public static void DeleteStudent(int studentId)
        {
            var deleteItem = StudentDb.Students.FirstOrDefault(c => c.Id == studentId);

            if (deleteItem != null)
            {
                StudentDb.Students.Remove(deleteItem);
                StudentDb.SaveChanges();
            }
        }
    }
}