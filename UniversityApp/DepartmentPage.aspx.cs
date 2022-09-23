using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class DepartmentPage : System.Web.UI.Page
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

            List<tDepartment> departmentList = entity.tDepartment.ToList();

            if ( departmentList.Count == 0 )
            {
                Console.WriteLine("There is no data in the table");
            }
            else
            {
                Common.adjustDropdownlist(ddl_DeleteDepartmentID, departmentList, "depID");
                Common.adjustDropdownlist(ddl_UpdateDepartmentID, departmentList, "depID");
                Common.showGridView(gv_allDepartments, departmentList);

                int selectedID = Int32.Parse(ddl_DeleteDepartmentID.SelectedValue);
                tDepartment obj = entity.tDepartment.Single(department => department.depID == selectedID);

                tb_delete_departmentName.Text = obj.depName;
                tb_delete_facultyID.Text = obj.facultyID.ToString();

                tb_update_departmentName.Text = obj.depName;
                tb_update_facultyID.Text = obj.facultyID.ToString();
            }
        }
        


        
        protected void ddl_DeleteDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteDepartmentID.SelectedValue);

            tDepartment obj = entity.tDepartment.Single(department => department.depID == selectedID);

            tb_delete_departmentName.Text = obj.depName;
            tb_delete_facultyID.Text = obj.facultyID.ToString();
        }




        
        protected void ddl_UpdateDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateDepartmentID.SelectedValue);
            tDepartment obj = entity.tDepartment.Single(department => department.depID == selectedID);

            tb_update_departmentName.Text = obj.depName;
            tb_update_facultyID.Text = obj.facultyID.ToString();
        }



        
        protected void btn_InsertDepartment_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_insert_departmentID.Text)
                || String.IsNullOrEmpty(tb_insert_departmentName.Text)
                || String.IsNullOrEmpty(tb_insert_facultyID.Text))
            {
                Common.ErrorMessage();
            }
            else
            {
                ContextDB entity = new ContextDB();
                
                tDepartment obj = new tDepartment
                {
                    depID = Int32.Parse(tb_insert_departmentID.Text),
                    depName = tb_insert_departmentName.Text,
                    facultyID = Int32.Parse(tb_insert_facultyID.Text)
                };

                entity.tDepartment.Add(obj);
                entity.SaveChanges();

                List<tDepartment> departmentList = entity.tDepartment.ToList();

                Common.adjustDropdownlist(ddl_DeleteDepartmentID, departmentList, "facultyID");
                Common.adjustDropdownlist(ddl_UpdateDepartmentID, departmentList, "facultyID");

                Common.showGridView(gv_allDepartments, departmentList);

                Common.ClearTextboxes(Page);
            }
        }


        
        protected void btn_DeleteDepartment_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_DeleteDepartmentID.SelectedItem.Text);
            entity.tDepartment.Remove(entity.tDepartment.Find(selectedID));

            entity.SaveChanges();

            List<tDepartment> departmentList = entity.tDepartment.ToList();

            Common.adjustDropdownlist(ddl_DeleteDepartmentID, departmentList, "facultyID");
            Common.adjustDropdownlist(ddl_UpdateDepartmentID, departmentList, "facultyID");

            Common.showGridView(gv_allDepartments, departmentList);

            Common.ClearTextboxes(Page);
        }


        
        protected void btn_UpdateDepartment_Click(object sender, EventArgs e)
        {
            ContextDB entity = new ContextDB();

            int selectedID = Int32.Parse(ddl_UpdateDepartmentID.SelectedValue);
            tDepartment obj = entity.tDepartment.Single(department => department.depID == selectedID);

            obj.depName = tb_update_departmentName.Text;
            obj.facultyID = Int32.Parse(tb_update_facultyID.Text);

            entity.SaveChanges();

            List<tDepartment> departmentList = entity.tDepartment.ToList();

            Common.adjustDropdownlist(ddl_DeleteDepartmentID, departmentList, "facultyID");
            Common.adjustDropdownlist(ddl_UpdateDepartmentID, departmentList, "facultyID");

            Common.showGridView(gv_allDepartments, departmentList);

            Common.ClearTextboxes(Page);
        }
    }
}