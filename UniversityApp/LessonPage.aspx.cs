using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class LessonPage : System.Web.UI.Page
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
            List<tStudentCourse> uniqueCourseList = lessonList.GroupBy(x => x.courseID).Select(x => x.First()).ToList();
            List<tStudentCourse> uniqueStudentList = lessonList.GroupBy(x => x.studentID).Select(x => x.First()).ToList();

            if ( lessonList.Count == 0 )
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {
                Common.adjustDropdownlist(ddl_DeleteCourseID, uniqueCourseList, "courseID");
                Common.adjustDropdownlist(ddl_UpdateCourseID, uniqueCourseList, "courseID");

                int selectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedValue);
                List<tStudentCourse> sameCourseId_LessonList = lessonList.Where(x => x.courseID == selectedCourseID).ToList();

                Common.adjustDropdownlist(ddl_DeleteStudentID, sameCourseId_LessonList, "studentID");
                Common.adjustDropdownlist(ddl_UpdateStudentID, sameCourseId_LessonList, "studentID");

                int selectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedValue);
                List<tStudentCourse> selectedLessonList = sameCourseId_LessonList.Where(x => x.studentID == selectedStudentID).ToList();

                tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.courseID == selectedCourseID && studentCourse.studentID == selectedStudentID);
                tb_delete_final.Text = obj.final;
                tb_delete_midterm.Text = obj.midterm;
                tb_delete_semester.Text = obj.semester;
                tb_delete_year.Text = obj.year;

                tb_update_final.Text = obj.final;
                tb_update_midterm.Text = obj.midterm;
                tb_update_semester.Text = obj.semester;
                tb_update_year.Text = obj.year;
            }

            gv_allLesson.DataSource = lessonList;
            gv_allLesson.DataBind();
        }



        protected void ddl_DeleteCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedValue);

            List<tStudentCourse> studentList = entity.tStudentCourse.ToList().Where(x => x.courseID == selectedCourseID).ToList();
            Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");

            int selectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedValue);

            tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == selectedStudentID && studentCourse.courseID == selectedCourseID);

            tb_delete_midterm.Text = obj.midterm;
            tb_delete_final.Text = obj.final;
            tb_delete_semester.Text = obj.semester;
            tb_delete_year.Text = obj.year;

            //tStudentCourse obj = entity.tStudentCourse.Single(lesson => lesson.courseID == selectedID);
            /*var obj1 = from studentCourse in entity.tStudentCourse 
                      where studentCourse.courseID == selectedID 
                      select studentCourse; */
        }



        protected void ddl_DeleteStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedValue);
            int selectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedValue);

            tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == selectedStudentID && studentCourse.courseID == selectedCourseID);

            tb_delete_midterm.Text = obj.midterm;
            tb_delete_final.Text = obj.final;
            tb_delete_semester.Text = obj.semester;
            tb_delete_year.Text = obj.year;
        }



        protected void ddl_UpdateCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_UpdateCourseID.SelectedValue);

            List<tStudentCourse> studentList = entity.tStudentCourse.ToList().Where(x => x.courseID == selectedCourseID).ToList();
            Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

            int selectedStudentID = Int32.Parse(ddl_UpdateStudentID.SelectedValue);

            tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == selectedStudentID && studentCourse.courseID == selectedCourseID);

            tb_update_midterm.Text = obj.midterm;
            tb_update_final.Text = obj.final;
            tb_update_semester.Text = obj.semester;
            tb_update_year.Text = obj.year;
        }



        protected void ddl_UpdateStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_UpdateCourseID.SelectedValue);
            int selectedStudentID = Int32.Parse(ddl_UpdateStudentID.SelectedValue);

            tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == selectedStudentID && studentCourse.courseID == selectedCourseID);

            tb_update_midterm.Text = obj.midterm;
            tb_update_final.Text = obj.final;
            tb_update_semester.Text = obj.semester;
            tb_update_year.Text = obj.year;
        }



        protected void btn_InsertLesson_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_courseID.Text)
                || String.IsNullOrEmpty(tb_insert_studentID.Text)
                || String.IsNullOrEmpty(tb_insert_year.Text)
                || String.IsNullOrEmpty(tb_insert_semester.Text)
                || String.IsNullOrEmpty(tb_insert_midterm.Text)
                || String.IsNullOrEmpty(tb_insert_final.Text))
            {
                Common.ErrorMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();

                tStudentCourse obj = new tStudentCourse
                {
                    courseID = Int32.Parse(tb_insert_courseID.Text),
                    studentID = Int32.Parse(tb_insert_studentID.Text),
                    year = tb_insert_year.Text,
                    semester = tb_insert_semester.Text,
                    midterm = tb_insert_midterm.Text,
                    final = tb_insert_final.Text
                };

                entity.tStudentCourse.Add(obj);
                entity.SaveChanges();

                List<tStudentCourse> lessonList = entity.tStudentCourse.ToList();
                List<tStudentCourse> uniqueCourseList = lessonList.GroupBy(x => x.courseID).Select(x => x.First()).ToList();
                List<tStudentCourse> uniqueStudentList = lessonList.GroupBy(x => x.studentID).Select(x => x.First()).ToList();

                Common.adjustDropdownlist(ddl_DeleteCourseID, uniqueCourseList, "courseID");
                Common.adjustDropdownlist(ddl_UpdateCourseID, uniqueCourseList, "courseID");

                int newSelectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedItem.Text);

                List<tStudentCourse> studentList = entity.tStudentCourse.ToList().Where(x => x.courseID == newSelectedCourseID).ToList();
                Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
                Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

                int newSelectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedItem.Text);

                tStudentCourse obj2 = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == newSelectedStudentID && studentCourse.courseID == newSelectedCourseID);

                tb_delete_midterm.Text = obj2.midterm;
                tb_delete_final.Text = obj2.final;
                tb_delete_semester.Text = obj2.semester;
                tb_delete_year.Text = obj2.year;

                Common.showGridView(gv_allLesson, lessonList);

                //Common.ClearTextboxes(Page);
                tb_insert_courseID.Text = "";
                tb_insert_final.Text = "";
                tb_insert_midterm.Text = "";
                tb_insert_semester.Text = "";
                tb_insert_studentID.Text = "";
                tb_insert_year.Text = "";
            }
        }



        protected void btn_DeleteLesson_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedItem.Text);
            int selectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedValue);

            tStudentCourse obj1 = entity.tStudentCourse.Single(studentCourse => studentCourse.courseID == selectedCourseID && studentCourse.studentID == selectedStudentID);

            entity.tStudentCourse.Remove(obj1);
            entity.SaveChanges();

            List<tStudentCourse> lessonList = entity.tStudentCourse.ToList();
            List<tStudentCourse> uniqueLessonList = lessonList.GroupBy(x => x.courseID).Select(x => x.First()).ToList();

            Common.adjustDropdownlist(ddl_DeleteCourseID, uniqueLessonList, "courseID");
            Common.adjustDropdownlist(ddl_UpdateCourseID, uniqueLessonList, "courseID");

            int newSelectedCourseID = Int32.Parse(ddl_DeleteCourseID.SelectedItem.Text);

            List<tStudentCourse> studentList = entity.tStudentCourse.ToList().Where(x => x.courseID == newSelectedCourseID).ToList();
            Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
            Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

            int newSelectedStudentID = Int32.Parse(ddl_DeleteStudentID.SelectedItem.Text);

            tStudentCourse obj2 = entity.tStudentCourse.Single(studentCourse => studentCourse.studentID == newSelectedStudentID && studentCourse.courseID == newSelectedCourseID);

            tb_delete_midterm.Text = obj2.midterm;
            tb_delete_final.Text = obj2.final;
            tb_delete_semester.Text = obj2.semester;
            tb_delete_year.Text = obj2.year;

            Common.showGridView(gv_allLesson, lessonList);
        }



        protected void btn_UpdateLesson_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedCourseID = Int32.Parse(ddl_UpdateCourseID.SelectedValue);
            int selectedStudentID = Int32.Parse(ddl_UpdateStudentID.SelectedValue);

            tStudentCourse obj = entity.tStudentCourse.Single(studentCourse => studentCourse.courseID == selectedCourseID && studentCourse.studentID == selectedStudentID);

            obj.year = tb_update_year.Text;
            obj.semester = tb_update_semester.Text;
            obj.midterm = tb_update_midterm.Text;
            obj.final = tb_update_final.Text;

            entity.SaveChanges();

            List<tStudentCourse> lessonList = entity.tStudentCourse.ToList();
            List<tStudentCourse> uniqueLessonList = lessonList.GroupBy(x => x.courseID).Select(x => x.First()).ToList();

            Common.showGridView(gv_allLesson, lessonList);
        }
    }
}