using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;                //Control'deki hatayı gidermek için
using System.Web.UI.WebControls;    //Parametrelerdeki Textbox, Label, Gridview'deki hataları gidermek için
using System.Windows;
using System.Windows.Forms;

//Control ve Textbox bileşenleri hem System.Windows.Forms
//hem de System.Web.UI bileşeni olduğu için birbiri ile çakışıyordu
//Quickfix ile aşağıdaki gibi yazınca karışıklık giderildi
using Control = System.Web.UI.Control;          
using TextBox = System.Web.UI.WebControls.TextBox;

namespace UniversityApp
{
    public class Common
    {
        public static void ErrorMessage()
        {
            MessageBox.Show("You have to fill in the text boxes.");
        }


        //This method deletes the text of all text boxes on the page.
        public static void ClearTextboxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var tb = c as TextBox;
                if (tb != null)
                {
                    tb.Text = String.Empty;
                }
                ClearTextboxes(c);
            }
        }

        public static void showGridView(GridView gv, object list)
        {
            gv.DataSource = list;
            gv.DataBind();
        }

        public static void adjustDropdownlist(DropDownList ddl, object list, String columnName)
        {
            ddl.DataSource = list;
            ddl.DataValueField = columnName;
            ddl.DataTextField = columnName;
            ddl.DataBind();
        }
    }
}