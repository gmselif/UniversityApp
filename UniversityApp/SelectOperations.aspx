<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectOperations.aspx.cs" Inherits="UniversityApp.SelectOperations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Lesson selection process by studentID</h3>
            Öğrenci numarası seçilerek butona tıklanması sonucu, bu öğrenciye ait dersler listelenir.
            <br /><br />
            <asp:DropDownList
                            width="10%"
                            ID="ddl_SelectStudentID" 
                            AutoPostBack="true" 
                            runat="server" />
             <asp:Button
                width="10%"
                ID="btn_selectByStudentID"
                Text="Select StudentID" 
                runat="server" 
                OnClick="btn_selectByStudentID_Click" /><br /><br />


            <table class="center">
                <tr>
                    <td colspan="6">
                        <asp:GridView 
                            class="gv"
                            ID="gv_Lesson" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>



        <div>
            <h3>Lesson selection process by year and semester</h3>
            Yıl ve dönem bilgisi seçilerek butona tıklanması sonucu, bu döneme ait derslerin listelenemesi sağlanır.
            Her dersi alan öğrenci sayısı da tabloda belirtilir.
            <br /><br />
            <asp:DropDownList
                            width="10%"
                            ID="ddl_SelectByYear" 
                            AutoPostBack="true" 
                            runat="server" />
            <asp:DropDownList
                            width="10%"
                            ID="ddl_SelectBySemester" 
                            AutoPostBack="true" 
                            runat="server" />
            <asp:Button
                width="10%"
                ID="btn_selectBySemester"
                Text="Select" 
                runat="server" 
                OnClick="btn_selectBySemester_Click" /><br /><br />

            

            <table class="center">
                <tr>
                    <td colspan="2">
                        <asp:GridView 
                            class="gv"
                            ID="gv_Lesson2" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>


        <div>
            <h3>Student selection process by lessonID</h3>
            Bir dersID seçiniz. Butona tıklanması sonucu, seçilen dersi alan öğrenciler listelenir.
            <br /><br />

            <asp:DropDownList
                            width="10%"
                            ID="ddl_SelectLessonID" 
                            AutoPostBack="true" 
                            runat="server" />
            <asp:Button
                width="10%"
                ID="btn_selectByLessonID"
                Text="Select LessonID" 
                runat="server" 
                OnClick="btn_selectByLessonID_Click" /><br /><br />

            

            <table class="center">
                <tr>
                    <td colspan="4">
                        <asp:GridView 
                            class="gv"
                            ID="gv_students" 
                            runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>


        <div>
            <h3>Student selection process by lessonID</h3>
            Yıl, yarıyıl ve öğrenci seçimi yapılarak butona tıklanması sonucu, seçilen öğrenciye ders atama işlemi.
            <br /><br />
            <table class="center">
                <tr>
                    <th>Yıl</th>
                    <th>Yarıyıl</th>
                    <th>ÖğrenciID</th>
                    <th>DersID</th>
                    <th>Vize</th>
                    <th>Final</th>
                    <th>Operation</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList
                            class="ddl"
                            ID="ddl_year" 
                            AutoPostBack="true" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList
                            class="ddl"
                            ID="ddl_semester" 
                            AutoPostBack="true" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList
                            class="ddl"
                            ID="ddl_studentID" 
                            AutoPostBack="true" 
                            runat="server" />
                    </td>
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_lessonID"
                            runat="server" />
                    </td>  
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_midterm"
                            runat="server" />
                    </td> 
                    <td>
                        <asp:TextBox
                            class="tb"
                            ID="tb_final"
                            runat="server" />
                    </td>
                    <td>
                        <asp:Button
                            class="btn"
                            ID="btn_assignLesson2student"
                            Text="Select" 
                            runat="server" 
                            OnClick="btn_assignLesson2student_Click" /><br />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label
                ID="errorMessage"
                runat="server"
                Text="" />
        </div>
    </form>
</body>
</html>
