<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacultyPage.aspx.cs" Inherits="UniversityApp.FacultyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="hdiv"> 
            <h1 class="hdr">Faculty Page</h1>
        </div>

        <div>
            <h3>Insert Faculty Table</h3><br />
            <table class="center">
                <tr>
                    <th>Faculty ID</th>
                    <th>Faculty Name</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_facultyID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_facultyName" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertFaculty" 
                            runat="server" 
                            Text="Insert Faculty"
                            OnClick="btn_InsertFaculty_Click" />
                    </td>
                </tr>
            </table>
        </div>


        <div>
            <h3>Delete Faculty</h3><br />
            <table class="center">
                <tr>
                    <th>Faculty ID</th>
                    <th>Faculty Name</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList 
                            class="ddl" 
                            ID="ddl_DeleteFacultyID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_DeleteFacultyID_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>                    
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_facultyName"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td>                
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteFaculty" 
                            runat="server" 
                            Text="Delete Faculty"  
                            OnClick="btn_DeleteFaculty_Click" />
                    </td>  
                </tr> 
            </table>
        </div>

        <div>
            <h3>Update Faculty Table</h3><br />
            <table class="center">
                <tr>
                    <th>Faculty ID</th>
                    <th>Faculty Name</th>
                    <th>Operation</th>
                </tr>
                <tr>                    
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_UpdateFacultyID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_UpdateFacultyID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_facultyName"
                            runat="server" />
                    </td>                  
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_UpdateFaculty" 
                            runat="server" 
                            Text="Update Faculty"  
                            OnClick="btn_UpdateFaculty_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>All Records In The Faculty Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="4">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allFaculties" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
