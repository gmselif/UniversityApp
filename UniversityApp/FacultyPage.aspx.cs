using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class FacultyPage : System.Web.UI.Page
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

            List<tFaculty> facultyList = entity.tFaculty.ToList();

            if (facultyList.Count == 0)
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {
                Common.adjustDropdownlist(ddl_DeleteFacultyID, facultyList, "facultyID");
                Common.adjustDropdownlist(ddl_UpdateFacultyID, facultyList, "facultyID");
                Common.showGridView(gv_allFaculties, facultyList);
            }
        }


        protected void ddl_DeleteFacultyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteFacultyID.SelectedValue);
            tFaculty obj = entity.tFaculty.Single(faculty => faculty.facultyID == selectedID);
            
            tb_delete_facultyName.Text = obj.facultyName;
        }


        protected void ddl_UpdateFacultyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateFacultyID.SelectedValue);
            tFaculty obj = entity.tFaculty.Single(faculty => faculty.facultyID == selectedID);

            tb_update_facultyName.Text = obj.facultyName;
        }



        protected void btn_InsertFaculty_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_facultyID.Text)
                || String.IsNullOrEmpty(tb_insert_facultyName.Text))
            {
                Common.ErrorMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();

                tFaculty obj = new tFaculty
                {
                    facultyID = Int32.Parse(tb_insert_facultyID.Text),
                    facultyName = tb_insert_facultyName.Text
                };

                entity.tFaculty.Add(obj);
                entity.SaveChanges();

                List<tFaculty> facultyList = entity.tFaculty.ToList();

                Common.adjustDropdownlist(ddl_DeleteFacultyID, facultyList, "facultyID");
                Common.adjustDropdownlist(ddl_UpdateFacultyID, facultyList, "facultyID");

                Common.showGridView(gv_allFaculties, facultyList);

                Common.ClearTextboxes(Page);
            }
        }



        protected void btn_DeleteFaculty_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteFacultyID.SelectedItem.Text);
            entity.tFaculty.Remove(entity.tFaculty.Find(selectedID));

            entity.SaveChanges();

            List<tFaculty> facultyList = entity.tFaculty.ToList();

            Common.adjustDropdownlist(ddl_DeleteFacultyID, facultyList, "facultyID");
            Common.adjustDropdownlist(ddl_UpdateFacultyID, facultyList, "facultyID");

            Common.showGridView(gv_allFaculties, facultyList);

            Common.ClearTextboxes(Page);
        }




        protected void btn_UpdateFaculty_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateFacultyID.SelectedValue);
            tFaculty obj = entity.tFaculty.Single(faculty => faculty.facultyID == selectedID);
            obj.facultyName = tb_update_facultyName.Text;

            entity.SaveChanges();

            List<tFaculty> facultyList = entity.tFaculty.ToList();

            Common.adjustDropdownlist(ddl_DeleteFacultyID, facultyList, "facultyID");
            Common.adjustDropdownlist(ddl_UpdateFacultyID, facultyList, "facultyID");

            Common.showGridView(gv_allFaculties, facultyList);

            Common.ClearTextboxes(Page);
        }
    }
}