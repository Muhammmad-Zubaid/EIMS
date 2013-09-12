﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

public partial class Administration_AddTeachers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void AddNewTeacher_ActiveStepChanged(object sender, EventArgs e)
    {
        //Get the UserID for the just added user
        MembershipUser newUser = Membership.GetUser(AddNewTeacher.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        // Have we JUST reached the Complete step?
        if (AddNewTeacher.ActiveStep.Title == "Complete")
        {
            //CreateUserWizardStep CustStep = AddNewStudent.FindControl("CreateUserWizardStep1") as CreateUserWizardStep;
            //TemplateControl CustStep = CreateUserWizardStep1.ContentTemplate as TemplateControl;
            TextBox FirstName = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("FirstName") as TextBox;
            TextBox Email = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Email") as TextBox;
            TextBox UserName = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("UserName") as TextBox;
            TextBox Password = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Password") as TextBox;
            // Programmatically reference the TextBox controls
            // TextBox FirstName = CreateUserWizardStep1.FindControl("FirstName") as TextBox;
            TextBox LastName = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("LastName") as TextBox;
            DropDownList Gender = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Gender") as DropDownList;
            TextBox Contact = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Contact") as TextBox;
            TextBox Education = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Education") as TextBox;
            TextBox Designation = AddNewTeacher.CreateUserStep.ContentTemplateContainer.FindControl("Designation") as TextBox;
            // Insert a new record into student profiles
            string connectionString = ConfigurationManager.ConnectionStrings["EIMSConnectionString"].ConnectionString;
            //string insertSql = "INSERT INTO StudentProfiles(FirstName, LastName, Contact, Department, Batch, RollNo) VALUES(@FirstName, @LastName, @Contact, @Department, @Batch, @RollNo)";
            string insertSql = "INSERT INTO TeacherProfiles(TeacherId, FirstName, LastName, Contact, Education, Designation, Gender) VALUES(@UserId, @FirstName, @LastName, @Contact, @Education, @Designation, @Gender)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                myCommand.Parameters.AddWithValue("@FirstName", FirstName.Text.Trim());
                myCommand.Parameters.AddWithValue("@LastName", LastName.Text.Trim());
                myCommand.Parameters.AddWithValue("@Contact", Contact.Text.Trim());
                myCommand.Parameters.AddWithValue("@Education", Education.Text.Trim());
                myCommand.Parameters.AddWithValue("@Designation", Designation.Text.Trim());
                myCommand.Parameters.AddWithValue("@Gender", Gender.SelectedItem.Text);
                myCommand.Parameters.AddWithValue("@UserId", newUserId);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }

            Roles.AddUserToRole(AddNewTeacher.UserName, "teacher");
            //Email
            string recipient = Email.Text;
            string from = "noreply@eims.com";
            string subject = "Welcome to Educational Institute Management System";
            string body = "Hi Mr." + FirstName.Text + " " + LastName.Text + ", you are now a registered user.\nUserName:" + UserName.Text + "\nPassword:" + Password.Text;
            MailMessage objMail = new MailMessage(from, recipient, subject, body);
            NetworkCredential objNC = new NetworkCredential("noreply.eims@live.com", "admin123");
            SmtpClient objsmtp = new SmtpClient("smtp.live.com", 587); // for hotmail
            objsmtp.EnableSsl = true;
            objsmtp.Credentials = objNC;
            objsmtp.Send(objMail);
        }

    }
}