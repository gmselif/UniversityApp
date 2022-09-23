using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class CoursePage : System.Web.UI.Page
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

            List<tCourse> courseList = entity.tCourse.ToList();

            if ( courseList.Count == 0 )
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {
                Common.adjustDropdownlist(ddl_DeleteCourseID, courseList, "courseID");
                Common.adjustDropdownlist(ddl_UpdateCourseID, courseList, "courseID");
                Common.showGridView(gv_allCourses, courseList);

                int selectedID = Int32.Parse(ddl_DeleteCourseID.SelectedValue);
                tCourse obj = entity.tCourse.Single(course => course.courseID == selectedID);

                tb_delete_courseName.Text = obj.courseName;
                tb_delete_departmentID.Text = obj.depID.ToString();
                tb_delete_instructorID.Text = obj.insID.ToString();

                tb_update_courseName.Text = obj.courseName;
                tb_update_departmentID.Text = obj.depID.ToString();
                tb_update_instructorID.Text = obj.insID.ToString();
            }
        }




        protected void ddl_DeleteCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteCourseID.SelectedValue);

            tCourse obj = entity.tCourse.Single(course => course.courseID == selectedID);

            tb_delete_courseName.Text = obj.courseName;
            tb_delete_departmentID.Text = obj.depID.ToString();
            tb_delete_instructorID.Text = obj.insID.ToString();
        }





        protected void ddl_UpdateCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateCourseID.SelectedValue);
            tCourse obj = entity.tCourse.Single(course => course.courseID == selectedID);

            tb_update_courseName.Text = obj.courseName;
            tb_update_departmentID.Text = obj.depID.ToString();
            tb_update_instructorID.Text = obj.insID.ToString();
        }




        protected void btn_InsertCourse_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_courseID.Text)
                || String.IsNullOrEmpty(tb_insert_courseName.Text)
                || String.IsNullOrEmpty(tb_insert_departmentID.Text)
                || String.IsNullOrEmpty(tb_insert_instructorID.ToString()))
            {
                Common.ErrorMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();

                tCourse obj = new tCourse
                {
                    courseID = Int32.Parse(tb_insert_courseID.Text),
                    courseName = tb_insert_courseName.Text,
                    depID = Int32.Parse(tb_insert_departmentID.Text),
                    insID = Int32.Parse(tb_insert_instructorID.Text)
                };

                entity.tCourse.Add(obj);
                entity.SaveChanges();

                List<tCourse> courseList = entity.tCourse.ToList();

                Common.adjustDropdownlist(ddl_DeleteCourseID, courseList, "courseID");
                Common.adjustDropdownlist(ddl_UpdateCourseID, courseList, "courseID");

                Common.showGridView(gv_allCourses, courseList);

                Common.ClearTextboxes(Page);
            }
        }



        protected void btn_DeleteCourse_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteCourseID.SelectedItem.Text);
            entity.tCourse.Remove(entity.tCourse.Find(selectedID));

            entity.SaveChanges();

            List<tCourse> courseList = entity.tCourse.ToList();

            Common.adjustDropdownlist(ddl_DeleteCourseID, courseList, "courseID");
            Common.adjustDropdownlist(ddl_UpdateCourseID, courseList, "courseID");

            Common.showGridView(gv_allCourses, courseList);

            Common.ClearTextboxes(Page);
        }



        protected void btn_UpdateCourse_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateCourseID.SelectedValue);
            tCourse obj = entity.tCourse.Single(course => course.courseID == selectedID);

            obj.courseName = tb_update_courseName.Text;
            obj.depID = Int32.Parse(tb_update_departmentID.Text);
            obj.insID = Int32.Parse(tb_update_instructorID.Text);

            entity.SaveChanges();

            List<tCourse> courseList = entity.tCourse.ToList();

            Common.adjustDropdownlist(ddl_DeleteCourseID, courseList, "courseID");
            Common.adjustDropdownlist(ddl_UpdateCourseID, courseList, "courseID");

            Common.showGridView(gv_allCourses, courseList);

            Common.ClearTextboxes(Page);
        }
    }
}
//Çaalışıyor