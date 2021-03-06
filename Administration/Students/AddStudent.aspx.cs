﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
public partial class Administration_AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList Department = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Department") as DropDownList;
            Department.DataSource = DepartmentsDataSource;
            Department.DataValueField = "DepartmentId";
            Department.DataTextField = "DepartmentName";
            Department.DataBind();
            DropDownList Batch = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Batch") as DropDownList;
            Batch.DataSource = BatchesDataSource;
            Batch.DataValueField = "BatchId";
            Batch.DataTextField = "BatchName";
            Batch.DataBind();
        }
    }
    protected void AddNewStudent_CreatedUser(object sender, EventArgs e)
    {
        ////Get the UserID for the just added user
        //MembershipUser newUser = Membership.GetUser(AddNewStudent.UserName);
        //Guid newUserId = (Guid)newUser.ProviderUserKey;

        //TemplatedWizardStep CustStep = CreateUserWizardStep1.FindControl("ContentTemplate") as TemplatedWizardStep;
        

        //// Programmatically reference the TextBox controls
        //TextBox FirstName = CustStep.FindControl("FirstName") as TextBox;
        //TextBox LastName = CustStep.FindControl("LastName") as TextBox;
        //TextBox Contact = CustStep.FindControl("Contact") as TextBox;
        //TextBox Department = CustStep.FindControl("Department") as TextBox;
        //TextBox Batch = CustStep.FindControl("Batch") as TextBox;
        //TextBox RollNum = CustStep.FindControl("RollNum") as TextBox;
        ////Insert a new record into student profiles
        //string connectionString = ConfigurationManager.ConnectionStrings["EIMSConnectionString"].ConnectionString;
        ////string insertSql = "INSERT INTO StudentProfiles(FirstName, LastName, Contact, Department, Batch, RollNo) VALUES(@FirstName, @LastName, @Contact, @Department, @Batch, @RollNo)";
        //string updateSql = "UPDATE StudentProfiles SET FirstName = @FirstName, LastName= @LastName, Contact = @Contact, Department = @Department, Batch = @Batch, RollNo = @RollNo WHERE UserId = @UserId";

        //using (SqlConnection myConnection = new SqlConnection(connectionString))
        //{
        //    myConnection.Open();
        //    SqlCommand myCommand = new SqlCommand(updateSql, myConnection);
        //    myCommand.Parameters.AddWithValue("@FirstName", FirstName.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@LastName", LastName.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@Contact", Contact.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@Department", Department.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@Batch", Batch.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@RollNo", RollNum.Text.Trim());
        //    myCommand.Parameters.AddWithValue("@UserId", newUserId);
        //    myCommand.ExecuteNonQuery();
        //    myConnection.Close();
        //}

    }
    protected void AddNewStudent_ActiveStepChanged(object sender, EventArgs e)
    {
        //Get the UserID for the just added user
        MembershipUser newUser = Membership.GetUser(AddNewStudent.UserName);
        newUser.ChangePassword(AddNewStudent.Password, "admin123");
        Guid newUserId = (Guid)newUser.ProviderUserKey;

         // Have we JUST reached the Complete step?
        if (AddNewStudent.ActiveStep.Title == "Complete")
        {
            //CreateUserWizardStep CustStep = AddNewStudent.FindControl("CreateUserWizardStep1") as CreateUserWizardStep;
            //TemplateControl CustStep = CreateUserWizardStep1.ContentTemplate as TemplateControl;
            TextBox FirstName = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("FirstName") as TextBox;
            TextBox Email = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Email") as TextBox;
            TextBox UserName = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("UserName") as TextBox;
            //TextBox Password = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Password") as TextBox;
            // Programmatically reference the TextBox controls
            //TextBox FirstName = CreateUserWizardStep1.FindControl("FirstName") as TextBox;
            TextBox LastName = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("LastName") as TextBox;
            TextBox Contact = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Contact") as TextBox;
            DropDownList Department = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Department") as DropDownList;
            DropDownList Batch = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Batch") as DropDownList;
            DropDownList Gender = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Gender") as DropDownList;
            TextBox RollNum = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("RollNum") as TextBox;
            TextBox Address = AddNewStudent.CreateUserStep.ContentTemplateContainer.FindControl("Address") as TextBox;
            //Insert a new record into student profiles
            string connectionString = ConfigurationManager.ConnectionStrings["EIMSConnectionString"].ConnectionString;
            //string insertSql = "INSERT INTO StudentProfiles(FirstName, LastName, Contact, Department, Batch, RollNo) VALUES(@FirstName, @LastName, @Contact, @Department, @Batch, @RollNo)";
            string insertSql = "INSERT INTO StudentProfiles(StudentId, FirstName, LastName, Contact, DepartmentId, BatchId, RollNo, Gender, Address) VALUES(@UserId, @FirstName, @LastName, @Contact, @Department, @Batch, @RollNo, @Gender, @Address)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                myCommand.Parameters.AddWithValue("@FirstName", FirstName.Text.Trim());
                myCommand.Parameters.AddWithValue("@LastName", LastName.Text.Trim());
                myCommand.Parameters.AddWithValue("@Contact", Contact.Text.Trim());
                myCommand.Parameters.AddWithValue("@Department", Department.SelectedItem.Value);
                myCommand.Parameters.AddWithValue("@Batch", Batch.SelectedItem.Value);
                myCommand.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Value.ToString());
                string rollNumber="";
                DataView dvSql = (DataView)DepartmentsDataSource.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql in dvSql)
                {
                    if(drvSql["DepartmentName"].ToString()==Department.SelectedItem.Text)
                    {
                        rollNumber = drvSql["DepartmentInitials"].ToString();
                    }
                }
                rollNumber = rollNumber + "-" + Batch.SelectedItem.Text + "-" + RollNum.Text;
                myCommand.Parameters.AddWithValue("@RollNo", rollNumber);
                myCommand.Parameters.AddWithValue("@Address", Address.Text.Trim());
                myCommand.Parameters.AddWithValue("@UserId", newUserId);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }

            Roles.AddUserToRole(AddNewStudent.UserName, "student");
          //Email
            EimsHelper.SendMail(Email.Text, "EIMS Registration.", "Hi Mr." + FirstName.Text + " " + LastName.Text + ".\nYou are added as a student on Educational Institute Management System.\nYou can log in with these credentials:\nUsername: " + UserName.Text + "\nPassword: " + "admin123" + "\nWe hope to provide you a great experience.");
        }
 
    }
}