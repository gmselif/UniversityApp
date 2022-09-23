<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="UniversityApp.CoursePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="hdiv">
            <h1 class="hdr">Course Page</h1>
        </div>

        <div>
            <h3>Insert Course Table</h3><br />
            <table class="center">
                <tr>
                    <th>Course ID</th>
                    <th>Course Name</th>
                    <th>Department ID</th>
                    <th>Instructor ID</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_courseID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_courseName" 
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_departmentID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_instructorID" 
                            runat="server" />
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertCourse" 
                            runat="server" 
                            Text="Insert Course"
                            OnClick="btn_InsertCourse_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Delete Course</h3><br />
            <table class="center">
                <tr>
                    <th>Course ID</th>
                    <th>Course Name</th>
                    <th>Department ID</th>
                    <th>Instructor ID</th>
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
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_courseName"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td>                       
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_departmentID"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td>   
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_instructorID"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td> 
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteCourse" 
                            runat="server" 
                            Text="Delete Course"
                            OnClick="btn_DeleteCourse_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Update Course Table</h3><br />
            <table class="center">
                <tr>
                    <th>Course ID</th>
                    <th>Course Name</th>
                    <th>Department ID</th>
                    <th>Instructor ID</th>
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
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_courseName"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_departmentID"
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_instructorID"
                            runat="server" />
                    </td> 
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_UpdateCourse" 
                            runat="server" 
                            Text="Update Lesson"
                            OnClick="btn_UpdateCourse_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>All Records In The Course Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="6">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allCourses" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
