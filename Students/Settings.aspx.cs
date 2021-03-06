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

public partial class Students_ProfileSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataView studentDataView = (DataView)StudentDataSource.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView dvr in studentDataView)
        {
          TxtFirstName.Text = dvr["FirstName"].ToString();
          TxtLastName.Text = dvr["LastName"].ToString();
          TxtContact.Text = dvr["Contact"].ToString();
          TxtEmail.Text = dvr["Email"].ToString();
          TxtAddress.Text = dvr["Address"].ToString();
          TxtBatch.Text = dvr["BatchName"].ToString();
          TxtDepartment.Text = dvr["DepartmentName"].ToString();
          TxtRollNum.Text = dvr["RollNo"].ToString();
          if (dvr["Gender"].ToString() == "Female")
          {
            DDGender.SelectedIndex = 1;
          }
          if (dvr["Avatar"].ToString() != "")
          {
            DisplayPicture.ImageUrl = dvr["Avatar"].ToString();
          }
        }
      }
    }
    protected void StudentDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
      MembershipUser student = Membership.GetUser(User.Identity.Name);
      Guid studentId = (Guid)student.ProviderUserKey;
      e.Command.Parameters["@StudentId"].Value = studentId;
    }
    protected void UpdateProfile_Click(object sender, EventArgs e)
    {
      MembershipUser student = Membership.GetUser(User.Identity.Name);
      Guid studentId = (Guid)student.ProviderUserKey;
      string connectionString = ConfigurationManager.ConnectionStrings["EIMSConnectionString"].ConnectionString;

      string updateSql = "UPDATE StudentProfiles SET FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Address=@Address,Gender=@Gender,Avatar=@Avatar WHERE StudentId=@StudentId";
      string fileName;
      string ext = System.IO.Path.GetExtension(this.FUDisplayPic.PostedFile.FileName);
      fileName = Server.MapPath("~/img/StudentAvatars/Display_picture_" + User.Identity.Name + ext);
      using (SqlConnection myConnection = new SqlConnection(connectionString))
      {
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(updateSql, myConnection);
        myCommand.Parameters.AddWithValue("@FirstName", TxtFirstName.Text);
        myCommand.Parameters.AddWithValue("@LastName", TxtLastName.Text);
        myCommand.Parameters.AddWithValue("@Contact", TxtContact.Text);
        myCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);
        myCommand.Parameters.AddWithValue("@Gender", DDGender.SelectedValue);
        myCommand.Parameters.AddWithValue("@StudentId", studentId);
        if (FUDisplayPic.HasFile)
        {
          myCommand.Parameters.AddWithValue("@Avatar", "~/img/StudentAvatars/Display_picture_" + User.Identity.Name + ext);
          FUDisplayPic.SaveAs(fileName);
        }
        else
        {
          myCommand.Parameters.AddWithValue("@Avatar", DisplayPicture.ImageUrl);
        }
        myCommand.ExecuteNonQuery();
      }
      student.Email = TxtEmail.Text;
      Membership.UpdateUser(student);
      EimsHelper.SendMail("sam_sarmad@hotmail.com", "EIMS Notification.", "Hi Mr./Ms." + "Sarmad" + " " + "Sabih" + ".\nYour child has updated his profile settings.\nYou can log in and see his/her profile to verify the changes.\nIn case of any misinformation you can feel free to contact the administrator." + "\nWe hope to provide you a great experience.");
      Session["Notice"] = "Your Profile has been updated! And your Parent/Guardian has been notified about the changes via an Email.";
      Response.Redirect("~/students/settings.aspx");
    }
}