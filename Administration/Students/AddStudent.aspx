﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="Administration_AddStudent" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="container" id="wrap">
	  <div class="row">
      <div class="col-md-6 col-md-offset-1">
  <asp:CreateUserWizard ID="AddNewStudent" runat="server" LoginCreatedUser="False" OnCreatedUser="AddNewStudent_CreatedUser" Question="What's your mother first name?" OnActiveStepChanged="AddNewStudent_ActiveStepChanged" CreateUserButtonText="Create Account" AutoGeneratePassword="True" ContinueDestinationPageUrl="~/Administration/Students/AddStudent.aspx">    
    <CreateUserButtonStyle CssClass="btn btn-lg btn-primary btn-block signup-btn" />
    <WizardSteps>
      <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
        <ContentTemplate>
        <!-- -->
          <legend>Students Registraion</legend>
          <h4>Educational Institute Management System</h4>
          <div class="row">
            <div class="col-xs-6 col-md-6">
              <asp:TextBox ID="FirstName" runat="server" CssClass="form-control input-lg" placeholder="First Name"></asp:TextBox>
              <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName" ErrorMessage="First Name is required." ToolTip="First Name is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-6 col-md-6">
              <asp:TextBox ID="LastName" runat="server" required="true" CssClass="form-control input-lg" placeholder="Last Name"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LastName" ErrorMessage="Last Name is required." ToolTip="Last Name is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-xs-6 col-md-6">
              <asp:TextBox ID="UserName" runat="server" CssClass="form-control input-lg" placeholder="Username"></asp:TextBox>
              <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-6 col-md-6">
              <asp:TextBox ID="RollNum" runat="server" CssClass="form-control input-lg" placeholder="Roll No"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RollNum" ErrorMessage="Roll No. is required." ToolTip="Roll No. is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:TextBox ID="Email" runat="server" CssClass="form-control input-lg" placeholder="Email"></asp:TextBox>
              <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:TextBox ID="Address" runat="server" CssClass="form-control input-lg" placeholder="Address"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Address" ErrorMessage="Address is required." ToolTip="Address is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-xs-6 col-md-6">
              <asp:TextBox ID="Contact" runat="server" CssClass="form-control input-lg" placeholder="Contact No"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Contact" ErrorMessage="Contact No. is required." ToolTip="Contact No. is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-6 col-md-6">
              <asp:DropDownList ID="Department" runat="server" CssClass="form-control input-lg"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Department" ErrorMessage="Department is required." ToolTip="Department is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-xs-6 col-md-6">
              <asp:DropDownList ID="Gender" runat="server" CssClass="form-control input-lg">
                <asp:ListItem Selected="True">Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Gender" ErrorMessage="Gender is required." ToolTip="Gender is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-6 col-md-6">
              <asp:DropDownList ID="Batch" runat="server" CssClass="form-control input-lg"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Batch" ErrorMessage="Batch is required." ToolTip="Batch is required." ValidationGroup="AddNewStudent">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
            </div>
          </div>
        <!-- -->
        </ContentTemplate>
      </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
        </asp:CompleteWizardStep>
    </WizardSteps>
  </asp:CreateUserWizard>
      </div>
    </div>            
  </div>
  <asp:SqlDataSource ID="DepartmentsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EIMSConnectionString %>" SelectCommand="SELECT [DepartmentId], [DepartmentName], [DepartmentInitials] FROM [Departments]"></asp:SqlDataSource>
  <asp:SqlDataSource ID="BatchesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EIMSConnectionString %>" SelectCommand="SELECT [BatchId], [BatchName] FROM [Batches]"></asp:SqlDataSource>
</asp:Content>

