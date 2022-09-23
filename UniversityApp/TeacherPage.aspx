<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPage.aspx.cs" Inherits="UniversityApp.TeacherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="hdiv"> 
            <h1 class="hdr">Instructor Page</h1>
        </div>

        <div>
            <h3>Insert Instructor Table</h3><br />
            <table class="center">
                <tr>
                    <th>Instructor ID</th>
                    <th>Instructor Name</th>
                    <th>Instructor Lastname</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_instructorID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_instructorName" 
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_instructorLastname" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertInstructor" 
                            runat="server" 
                            Text="Insert Instructor"
                            OnClick="btn_InsertInstructor_Click" />
                    </td>
                </tr>
            </table>
        </div>


        <div>
            <h3>Delete Instructor</h3><br />
            <table class="center">
                <tr>
                    <th>Instructor ID</th>
                    <th>Instructor Name</th>
                    <th>Instructor Lastname</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList 
                            class="ddl" 
                            ID="ddl_DeleteInstructorID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_DeleteInstructorID_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>                    
                    <td>
                        <asp:DropDownList  
                            class="ddl"
                            ID="ddl_delete_instructorName" 
                            runat="server" >
                        </asp:DropDownList>
                    </td>                       
                    <td>
                        <asp:DropDownList  
                            class="ddl"
                            ID="ddl_delete_instructorLastname" 
                            runat="server" >
                        </asp:DropDownList>
                    </td>                  
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteInstructor" 
                            runat="server" 
                            Text="Delete Instructor"  
                            OnClick="btn_DeleteInstructor_Click" />
                    </td>  
                </tr> 
            </table>
        </div>

        <div>
            <h3>Update Instructor Table</h3><br />
            <table class="center">
                <tr>
                    <th>Instructor ID</th>
                    <th>Instructor Name</th>
                    <th>Instructor Lastname</th>
                    <th>Operation</th>
                </tr>
                <tr>                    
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_UpdateInstructorID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_UpdateInstructorID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_instructorName"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_instructorLastname"
                            runat="server" />
                    </td>                   
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_UpdateInstructor" 
                            runat="server" 
                            Text="Update Instructor"  
                            OnClick="btn_UpdateInstructor_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>Selecting All Records In The Instructor Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="4">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allInstructor" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
