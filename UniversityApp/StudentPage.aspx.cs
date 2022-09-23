using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class StudentPage : System.Web.UI.Page
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

            List<tStudent> studentList = entity.tStudent.ToList();

            if (studentList.Count == 0)
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {
                Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
                Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");
            }
        }


        protected void ddl_DeleteStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteStudentID.SelectedValue);

            tStudent obj = entity.tStudent.Single(student => student.studentID == selectedID);

            tb_delete_studentName.Text = obj.studentFname;
            tb_delete_studentLastname.Text = obj.studentLname;
            tb_delete_departmentID.Text = obj.depID.ToString();
        }


        protected void ddl_UpdateStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateStudentID.SelectedValue);
            tStudent obj = entity.tStudent.Single(student => student.studentID == selectedID);

            tb_update_studentName.Text = obj.studentFname;
            tb_update_studentLastname.Text = obj.studentLname;
            tb_update_departmentID.Text = obj.depID.ToString();
        }


        protected void btn_InsertStudent_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_studentID.Text)
                || String.IsNullOrEmpty(tb_insert_studentName.Text)
                || String.IsNullOrEmpty(tb_insert_studentLastname.Text)
                || String.IsNullOrEmpty(tb_insert_departmentID.Text))
            {
                Common.ErrorMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();

                tStudent obj = new tStudent
                {
                    studentID = Int32.Parse(tb_insert_studentID.Text),
                    studentFname = tb_insert_studentName.Text,
                    studentLname = tb_insert_studentLastname.Text,
                    depID = Int32.Parse(tb_insert_departmentID.Text)
                };

                entity.tStudent.Add(obj);
                entity.SaveChanges();

                List<tStudent> studentList = entity.tStudent.ToList();

                Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
                Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

                Common.showGridView(gv_allStudents, studentList);

                Common.ClearTextboxes(Page);
            }
        }


        
        protected void btn_DeleteStudent_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteStudentID.SelectedItem.Text);
            entity.tStudent.Remove(entity.tStudent.Find(selectedID));

            entity.SaveChanges();

            List<tStudent> studentList = entity.tStudent.ToList();

            Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
            Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

            Common.showGridView(gv_allStudents, studentList);

            Common.ClearTextboxes(Page);
        }

        
        protected void btn_UpdateStudent_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateStudentID.SelectedValue);
            tStudent obj = entity.tStudent.Single(student => student.studentID == selectedID);

            obj.studentFname = tb_update_studentName.Text;
            obj.studentLname = tb_update_studentLastname.Text;
            obj.depID = Int32.Parse(tb_update_departmentID.Text);

            entity.SaveChanges();

            List<tStudent> studentList = entity.tStudent.ToList();

            Common.adjustDropdownlist(ddl_DeleteStudentID, studentList, "studentID");
            Common.adjustDropdownlist(ddl_UpdateStudentID, studentList, "studentID");

            Common.showGridView(gv_allStudents, studentList);

            Common.ClearTextboxes(Page);
        }
    }    
}
//Çalışıyor