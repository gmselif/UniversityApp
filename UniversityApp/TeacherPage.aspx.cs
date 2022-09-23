using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class TeacherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FirstInitialize();
            }
        }


        //Completed
        protected void FirstInitialize()
        {
            ContextDB entity = new ContextDB();

            List<tInstructor> departmentList = entity.tInstructor.ToList();

            ddl_DeleteInstructorID.DataSource = departmentList;
            ddl_DeleteInstructorID.DataValueField = "insID";
            ddl_DeleteInstructorID.DataTextField = "insID";
            ddl_DeleteInstructorID.DataBind();

            ddl_UpdateInstructorID.DataSource = departmentList;
            ddl_UpdateInstructorID.DataValueField = "insID";
            ddl_UpdateInstructorID.DataTextField = "insID";
            ddl_UpdateInstructorID.DataBind();

            gv_allInstructor.DataSource = departmentList;
            gv_allInstructor.DataBind();
        }

        //Completed
        protected void ddl_DeleteDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();
            int selectedID = Int32.Parse(ddl_DeleteInstructorID.SelectedValue);

            var query = from department
                        in entity.tDepartment
                        where department.depID == selectedID
                        select department;

            ddl_delete_instructorName.DataSource = query.ToList();
            ddl_delete_instructorName.DataValueField = "bolumAd";
            ddl_delete_instructorName.DataTextField = "bolumAd";
            ddl_delete_instructorName.DataBind();

        }


        //Completed
        protected void ddl_UpdateDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateInstructorID.SelectedValue);
            tInstructor obj = entity.tInstructor.Single(department => department.insID == selectedID);

            tb_update_instructorName.Text = obj.insName;
            tb_update_instructorLastname.Text = obj.insLastname;

            entity.SaveChanges();
        }


        //Completed
        protected void ddl_SelectFacultyID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        //Completed
        protected void btn_InsertDepartment_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_instructorID.Text)
                && String.IsNullOrEmpty(tb_insert_instructorName.Text)
                && String.IsNullOrEmpty(tb_insert_instructorLastname.Text))
            {
                FillTextboxMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();
                tInstructor obj = new tInstructor
                {
                    insID = Int32.Parse(tb_insert_instructorID.Text),
                    insName = tb_insert_instructorName.Text,
                    insLastname = tb_insert_instructorLastname.Text
                };
                entity.tInstructor.Add(obj);
                entity.SaveChanges();
            }
        }


        //Completed
        protected void btn_DeleteDepartment_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteInstructorID.SelectedItem.Text);
            entity.tInstructor.Remove(entity.tInstructor.Find(selectedID));
            entity.SaveChanges();
        }


        //Completed
        protected void btn_UpdateDepartment_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateInstructorID.SelectedValue);
            tInstructor obj = entity.tInstructor.Single(department => department.insID == selectedID);

            obj.insName = tb_update_instructorName.Text;
            obj.insLastname = tb_update_instructorLastname.Text;

            entity.SaveChanges();
        }

        protected void FillTextboxMessage()
        {
        }
    }
}