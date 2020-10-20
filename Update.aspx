<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style >
        .block{
    height: 35px;
    border-radius: 11px;
        width: 100%;

        }
        h2{
            text-align: center;
    font-size: 41px;
    font-family: calgiri;
    font-weight: bold;
        }
        .btn{
          
    background-color: cadetblue;
    height: 41px;
    font-size: 20px;
    font-weight: bold;
    text-align:center;
     margin-top: 11PX;
        }
        .aa h4{
          font-weight: bold;
    padding-top: 31px;  
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
      <h2>Registration Form</h2>
       <div class="row">
           <div class="col-xs-6"><div class="aa"><h4>First Name</h4><input class="block" type="text" id="TextBox1" runat="server" /></div></div>
                <div class="col-xs-6"><div class="aa"><h4>Last Name</h4><input class="block" type="text" id="TextBox2" runat="server" /></div></div>
               </div>
         <div class="row">
           <div class="col-xs-6"><div class="aa"><h4>Contact No.</h4><input class="block" type="text" id="TextBox3" runat="server"/></div></div>
                <div class="col-xs-6"><div class="aa"><h4>E-Mail</h4><input class="block" type="text" id="TextBox4" runat="server" /></div></div>
               </div>
       
    <div class="row">
           <div class="col-xs-6"><div class="aa"><h4>Password</h4><input class="block" type="text" id="TextBox5" runat="server" /></div></div>
                
               </div><br />
     
   </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
    <br />
    
    </div>
    
    
    
</asp:Content>

