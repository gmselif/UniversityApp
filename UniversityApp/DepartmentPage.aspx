<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="UniversityApp.DepartmentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="hdiv"> 
            <h1 class="hdr">Department Page</h1>
        </div>

        <div>
            <h3>Insert Department Table</h3><br />
            <table class="center">
                <tr>
                    <th>Bölüm ID</th>
                    <th>Bölüm Adı</th>
                    <th>Fakülte ID</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_departmentID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_departmentName" 
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox 
                            class="tb"
                            id="tb_insert_facultyID" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:Button 
                            class="btn"
                            ID="btn_InsertDepartment" 
                            runat="server" 
                            Text="Insert Department"
                            OnClick="btn_InsertDepartment_Click" />
                    </td>
                </tr>
            </table>
        </div>


        <div>
            <h3>Delete Department</h3><br />
            <table class="center">
                <tr>
                    <th>Bölüm ID</th>
                    <th>Bölüm Adı</th>
                    <th>Fakülte ID</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList 
                            class="ddl" 
                            ID="ddl_DeleteDepartmentID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_DeleteDepartmentID_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>                    
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_departmentName"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td>                       
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_delete_facultyID"
                            runat="server"
                            ReadOnly="true" />            <!--to block input-->
                    </td>                  
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_DeleteDepartment" 
                            runat="server" 
                            Text="Delete Department"  
                            OnClick="btn_DeleteDepartment_Click" />
                    </td>  
                </tr> 
            </table>
        </div>

        <div>
            <h3>Update Department Table</h3><br />
            <table class="center">
                <tr>
                    <th>Bölüm ID</th>
                    <th>Bölüm Adı</th>
                    <th>Fakülte ID</th>
                    <th>Operation</th>
                </tr>
                <tr>                    
                    <td>
                        <asp:DropDownList 
                            class="ddl"
                            ID="ddl_UpdateDepartmentID" 
                            AutoPostBack="true" 
                            runat="server" 
                            OnSelectedIndexChanged="ddl_UpdateDepartmentID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_departmentName"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_update_facultyID"
                            runat="server" />
                    </td>                   
                    <td> 
                        <asp:Button 
                            class="btn"
                            ID="btn_UpdateDepartment" 
                            runat="server" 
                            Text="Update Department"  
                            OnClick="btn_UpdateDepartment_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <h3>All Records In The Department Table</h3><br />
            <table class="center">
                <tr>
                    <td colspan="4">
                        <asp:GridView 
                            class="gv"
                            ID="gv_allDepartments" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
