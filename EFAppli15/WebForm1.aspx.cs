using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EFAppli15
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();

            GridView1.DataSource = (from student in employeeDBContext.Students
                                    from studentCourse in student.StudentCourses
                                    select new
                                    {
                                        StudentName = student.StudentName,
                                        CourseName = studentCourse.Cours.CourseName,
                                        EnrolledDate = studentCourse.EnrolledDate
                                    }).ToList();

            // The above query can also be written as shown below
            //GridView1.DataSource = (from course in employeeDBContext.Courses


            //                        from studentCourse in course.StudentCourses
            //                        select new
            //                        {
            //                            StudentName = studentCourse.Student.StudentName,
            //                            CourseName = course.CourseName,
            //                            EnrolledDate = studentCourse.EnrolledDate
            //                        }).ToList();

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            employeeDBContext.StudentCourses.Add
                (new StudentCourse
                {
                    StudentID = 1,
                    CourseID = 4,
                    EnrolledDate = DateTime.Now
                });
            employeeDBContext.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            StudentCourse studentCourseToRemove = employeeDBContext.StudentCourses
                .FirstOrDefault(x => x.StudentID == 2 && x.CourseID == 3);
            employeeDBContext.StudentCourses.Remove(studentCourseToRemove);
            employeeDBContext.SaveChanges();
        }
    }
}