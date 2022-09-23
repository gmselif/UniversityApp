<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonPage.aspx.cs" Inherits="UniversityApp.LessonPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="hdiv">
            <h1 class="hdr">Lesson Page</h1>
        </div>

        <div>
            <h3>Insert Student Course Table</h3><br />
            <table class="center">
                <tr>
                    <th>Student ID</th>
                    <th>Course ID</th>
                    <th>Year</th>
                    <th>Semester</th>
                    <th>Midterm</th>
                    <th>Final</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_studentID" 
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_courseID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_year" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_semester" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_midterm" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_final" 
                            runat="server" />
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertLesson" 
                            runat="server" 
                            Text="Insert Lesson"
                            OnClick="btn_InsertLesson_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Delete Lesson via Course ID</h3><br />
            <table class="center">
                <tr>
                    <th>Course ID</th>
                    <th>Student ID</th>
                    <th>Year</th>
                    <th>Semester</th>
                    <th>Midterm</th>
                    <th>Final</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_DeleteCourseID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_DeleteCourseID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td> 
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_DeleteStudentID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_DeleteStudentID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td> 
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_year" 
                            runat="server" 
                            ReadOnly="true" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_semester" 
                            runat="server" 
                            ReadOnly="true" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_midterm" 
                            runat="server" 
                            ReadOnly="true" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_final" 
                            runat="server" 
                            ReadOnly="true" />
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteLesson" 
                            runat="server" 
                            Text="Delete Lesson"
                            OnClick="btn_DeleteLesson_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Update Lesson Table</h3><br />
            <table class="center">
                <tr>
                    <th>Student ID</th>
                    <th>Course ID</th>
                    <th>Year</th>
                    <th>Semester</th>
                    <th>Midterm</th>
                    <th>Final</th>
                    <th>Operation</th>
                </tr>
                <tr>                    
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_UpdateCourseID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_UpdateCourseID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_UpdateStudentID" 
                            AutoPostBack="true" 
                            runat="server"
                            OnSelectedIndexChanged="ddl_UpdateStudentID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_year"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_semester"
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_midterm"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_final"
                            runat="server" />
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_LessonUpdate" 
                            runat="server" 
                            Text="Update Lesson"
                            OnClick="btn_UpdateLesson_Click" />
                    </td>
                </tr>
            </table>
        </div>



        <div>
            <h3>All Records In The Lesson Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="6">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allLesson" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
