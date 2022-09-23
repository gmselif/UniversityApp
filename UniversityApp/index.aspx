<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UniversityApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#D6EAF8;
        }
        div{
            text-align:center;
            /*div'in tüm ekranı kaplaması için aşağıdaki 5 satır kullanılır.*/
            position:absolute;
            top:0px;
            right:0px;
            bottom:0px;
            left:0px;
        }
        .btn_main {        
            width:40%;
            margin-top:50px;
            outline: 0;
            grid-gap: 8px;
            align-items: center;
            background: 0 0;
            border: 1px solid #000;
            border-radius: 4px;
            cursor: pointer;
            display: inline-flex;
            flex-shrink: 0;
            font-size: 25px;
            gap: 8px;
            justify-content: center;
            line-height: 1.5;
            overflow: hidden;
            padding: 12px 16px;
            text-decoration: none;
            text-overflow: ellipsis;
            transition: all .14s ease-out;
            white-space: nowrap;
            :hover {
                box-shadow: 4px 4px 0 #000;
                transform: translate(-4px,-4px);
            }
            :focus-visible{
                outline-offset: 1px;
            }     
         }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button 
                class="btn_main"
                ID="btn_Faculty" 
                runat="server" 
                Text="Faculty CRUD Operations" 
                OnClick="btn_Faculty_Click" /><br />

            <asp:Button 
                class="btn_main"
                ID="btn_Department" 
                runat="server" 
                Text="Department CRUD Operations" 
                OnClick="btn_Department_Click" /><br />

            <asp:Button 
                class="btn_main"
                ID="btn_Lesson" 
                runat="server" 
                Text="Lesson CRUD Operations" 
                OnClick="btn_Lesson_Click" /><br />
            
            <asp:Button 
                class="btn_main"
                ID="btn_Instructor" 
                runat="server" 
                Text="Teacher CRUD Operations" 
                OnClick="btn_Instructor_Click" /><br />

            <asp:Button 
                class="btn_main"
                ID="btn_Student" 
                runat="server" 
                Text="Student CRUD Operations" 
                 OnClick="btn_Student_Click" /><br />

            <asp:Button 
                class="btn_main"
                ID="btn_Select" 
                runat="server" 
                Text="Select Operations" 
                OnClick="btn_Select_Click" /><br />
        </div>
    </form>
</body>
</html>
