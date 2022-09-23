using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Faculty_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacultyPage.aspx");
        }

        protected void btn_Department_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentPage.aspx");
        }

        protected void btn_Lesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("LessonPage.aspx");
        }
        protected void btn_Instructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx");
        }
        
        protected void btn_Student_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectOperations.aspx");
        }
    }
}