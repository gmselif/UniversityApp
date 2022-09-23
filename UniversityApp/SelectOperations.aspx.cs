using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class SelectOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FirstInitialize();
            }
        }


        protected void FirstInitialize()
        {
            ContextDB entity = new ContextDB();

            List<tStudentCourse> lessonList = entity.tStudentCourse.ToList();
            List<tStudentCourse> uniqueLessonList = lessonList.GroupBy(x => x.courseID).Select(x => x.First()).ToList();
            List<tStudentCourse> uniqueYear_LessonList = lessonList.GroupBy(x => x.year).Select(x => x.First()).ToList();
            List<tStudentCourse> uniqueSemester_LessonList = lessonList.GroupBy(x => x.semester).Select(x => x.First()).ToList();

            List<tStudent> studentList = entity.tStudent.ToList();
            ddl_SelectStudentID.DataSource = studentList;
            ddl_SelectStudentID.DataValueField = "ogrenciID";
            ddl_SelectStudentID.DataTextField = "ogrenciID";
            ddl_SelectStudentID.DataBind();

            ddl_SelectByYear.DataSource = uniqueYear_LessonList;
            ddl_SelectByYear.DataValueField = "yil";
            ddl_SelectByYear.DataTextField = "yil";
            ddl_SelectByYear.DataBind();

            ddl_SelectBySemester.DataSource = uniqueSemester_LessonList;
            ddl_SelectBySemester.DataValueField = "yariyil";
            ddl_SelectBySemester.DataTextField = "yariyil";
            ddl_SelectBySemester.DataBind();

            ddl_SelectLessonID.DataSource = uniqueLessonList;
            ddl_SelectLessonID.DataValueField = "dersID";
            ddl_SelectLessonID.DataTextField = "dersID";
            ddl_SelectLessonID.DataBind();

            ddl_year.DataSource = uniqueYear_LessonList;
            ddl_year.DataValueField = "yil";
            ddl_year.DataTextField = "yil";
            ddl_year.DataBind();

            ddl_semester.DataSource = uniqueSemester_LessonList;
            ddl_semester.DataValueField = "yariyil";
            ddl_semester.DataTextField = "yariyil";
            ddl_semester.DataBind();

            ddl_studentID.DataSource = studentList;
            ddl_studentID.DataValueField = "ogrenciID";
            ddl_studentID.DataTextField = "ogrenciID";
            ddl_studentID.DataBind();
        }






        protected void btn_selectByStudentID_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_SelectStudentID.SelectedValue);

            var query = from lesson
                        in entity.tStudentCourse
                        where lesson.studentID == selectedID
                        select lesson;

            gv_Lesson.DataSource = query.ToList();
            gv_Lesson.DataBind();
        }



        protected void btn_selectBySemester_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            String selectedYear = ddl_SelectByYear.SelectedItem.Text;
            String selectedSemester = ddl_SelectBySemester.SelectedItem.Text;

            var Lessons = from lesson in entity.tStudentCourse
                          where lesson.year.Equals(selectedYear) && lesson.semester.Equals(selectedSemester)
                          group lesson by lesson.courseID
                          into newGroup
                          orderby newGroup.Key
                          select new { dersID = newGroup.Key, ogrenciSayisi = newGroup.Count() };


            gv_Lesson2.DataSource = Lessons.ToList();
            gv_Lesson2.DataBind();
        }


        protected void btn_selectByLessonID_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedLessonID = Int32.Parse(ddl_SelectLessonID.SelectedValue);

            var query = from lesson in entity.tStudentCourse
                        join student in entity.tStudent on lesson.studentID equals student.studentID
                        where lesson.courseID == selectedLessonID
                        select student;

            gv_students.DataSource = query.ToList();
            gv_students.DataBind();
        }


        protected void btn_assignLesson2student_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            String selectedYear = ddl_year.SelectedValue;
            String selectedSemester = ddl_semester.SelectedValue;
            int selectedStudentID = Int32.Parse(ddl_studentID.SelectedValue);

            tStudentCourse obj = new tStudentCourse
            {
                courseID = Int32.Parse(tb_lessonID.Text),
                studentID = selectedStudentID,
                year = selectedYear,
                semester = selectedSemester,
                midterm = tb_midterm.Text,
                final = tb_final.Text
            };
            entity.tStudentCourse.Add(obj);
            entity.SaveChanges();
        }
    }
}