<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="UniversityApp.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="hdiv">
            <h1 class="hdr">Student Page</h1>
        </div>

        <div>
            <h3>Insert Student</h3><br />
            <table class="center">
                <tr>
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Student Lastname</th>
                    <th>Department ID</th>
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
                            id="tb_insert_studentName" 
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_studentLastname" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_departmentID" 
                            runat="server" />
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertStudent" 
                            runat="server" 
                            Text="Insert Student"
                            OnClick="btn_InsertStudent_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Delete Student</h3><br />
            <table class="center">
                <tr>
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Student Lastname</th>
                    <th>Department ID</th>
                    <th>Operation</th>
                </tr>
                <tr>
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
                            id="tb_delete_studentName" 
                            runat="server" 
                            ReadOnly="true" />            <!--to block input-->
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_studentLastname" 
                            runat="server" 
                            ReadOnly="true" />            <!--to block input-->
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_delete_departmentID" 
                            runat="server" 
                            ReadOnly="true" />            <!--to block input-->
                    </td>
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteStudent" 
                            runat="server" 
                            Text="Delete Student"
                            OnClick="btn_DeleteStudent_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Update Student Table</h3><br />
            <table class="center">
                <tr>
                    <th>Student ID</th>
                    <th>Student Name</th>
                    <th>Student Lastname</th>
                    <th>Department ID</th>
                    <th>Operation</th>
                </tr>
                <tr>                    
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
                            ID="tb_update_studentName"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_studentLastname"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_departmentID"
                            runat="server" />
                    </td>                     
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_UpdateStudent" 
                            runat="server" 
                            text="Update Student"
                            OnClick="btn_UpdateStudent_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>All Records In The Student Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="4">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allStudents" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
