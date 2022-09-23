using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class InstructorPage : System.Web.UI.Page
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
            List<tInstructor> instructorList = entity.tInstructor.ToList();

            /*if ( instructorList.Count == 0 )
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {*/
                Common.adjustDropdownlist(ddl_DeleteInstructorID, instructorList, "insID");
                Common.adjustDropdownlist(ddl_UpdateInstructorID, instructorList, "insID");
                Common.showGridView(gv_allInstructors, instructorList);

                int selectedID = Int32.Parse(ddl_DeleteInstructorID.SelectedValue);
                tInstructor obj = entity.tInstructor.Single(instructor => instructor.insID == selectedID);

                tb_delete_instructorName.Text = obj.insName;
                tb_delete_instructorLastname.Text = obj.insLastname;

                tb_update_instructorName.Text = obj.insName;
                tb_update_instructorLastname.Text = obj.insLastname;
            //}
        }

        protected void ddl_DeleteInstructorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteInstructorID.SelectedValue);
            tInstructor obj = entity.tInstructor.Single(instructor => instructor.insID == selectedID);

            tb_delete_instructorName.Text = obj.insName;
            tb_delete_instructorLastname.Text = obj.insLastname;
        }


        protected void ddl_UpdateInstructorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateInstructorID.SelectedValue);
            tInstructor obj = entity.tInstructor.Single(instructor => instructor.insID == selectedID);

            tb_update_instructorName.Text = obj.insName;
            tb_update_instructorLastname.Text = obj.insLastname;
        }



        protected void btn_InsertInstructor_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_instructorID.Text)
                || String.IsNullOrEmpty(tb_insert_instructorName.Text)
                || String.IsNullOrEmpty(tb_insert_instructorLastname.Text))
            {
                Common.ErrorMessage();
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

                List<tInstructor> instructorList = entity.tInstructor.ToList();

                Common.adjustDropdownlist(ddl_DeleteInstructorID, instructorList, "insID");
                Common.adjustDropdownlist(ddl_UpdateInstructorID, instructorList, "insID");

                Common.showGridView(gv_allInstructors, instructorList);

                Common.ClearTextboxes(Page);
            }
        }



        protected void btn_DeleteInstructor_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteInstructorID.SelectedItem.Text);
            entity.tInstructor.Remove(entity.tInstructor.Find(selectedID));

            entity.SaveChanges();

            List<tInstructor> instructorList = entity.tInstructor.ToList();

            Common.adjustDropdownlist(ddl_DeleteInstructorID, instructorList, "insID");
            Common.adjustDropdownlist(ddl_UpdateInstructorID, instructorList, "insID");

            Common.showGridView(gv_allInstructors, instructorList);

            Common.ClearTextboxes(Page);
        }




        protected void btn_UpdateInstructor_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateInstructorID.SelectedValue);
            tInstructor obj = entity.tInstructor.Single(instructor => instructor.insID == selectedID);

            obj.insName = tb_update_instructorName.Text;
            obj.insLastname = tb_update_instructorLastname.Text;

            entity.SaveChanges();

            List<tInstructor> instructorList = entity.tInstructor.ToList();

            Common.adjustDropdownlist(ddl_DeleteInstructorID, instructorList, "insID");
            Common.adjustDropdownlist(ddl_UpdateInstructorID, instructorList, "insID");

            Common.showGridView(gv_allInstructors, instructorList);

            Common.ClearTextboxes(Page);
        }
    }
}