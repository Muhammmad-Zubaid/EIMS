﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Administration_Classes_Class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
        if (Request.QueryString["id"] != null)
        {
          DataView dvSql = (DataView)ClassDataSource.Select(DataSourceSelectArguments.Empty);
          foreach (DataRowView drvSql in dvSql)
          {
            Course.Text = drvSql["CourseName"].ToString();
            Teacher.Text = drvSql["TeacherName"].ToString();
            Batch.Text = drvSql["BatchName"].ToString();
            Department.Text = drvSql["DepartmentName"].ToString();
            Section.Text = drvSql["SectionName"].ToString();
            Semester.Text = drvSql["SemesterName"].ToString();
            CreditHours.Text = drvSql["CreditHours"].ToString();
          }
          AddStudents.DataSource = StudentsDataSource;
          AddStudents.DataBind();
          ClassStudentsGridview.DataSource = ClassStudentsDataSource;
          ClassStudentsGridview.DataBind();
        }
      }
        
    }


    protected void ClassDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@ClassId"].Value = Request.QueryString["id"];
    }
    protected void StudentsDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
      DataView dvSql = (DataView)ClassDataSource.Select(DataSourceSelectArguments.Empty);
      foreach (DataRowView drvSql in dvSql)
      {
        e.Command.Parameters["@BatchId"].Value = drvSql["BatchId"];
        e.Command.Parameters["@DepartmentId"].Value = drvSql["DepartmentId"];
      }


      
      e.Command.Parameters["@ClassId"].Value = Request.QueryString["id"];
    }
    protected void AddStudentsButton_Click(object sender, EventArgs e)
    {
      // Select the checkboxes from the GridView control
      for (int i = 0; i < AddStudents.Rows.Count; i++)
      {
        GridViewRow row = AddStudents.Rows[i];
        bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

        if (isChecked)
        {
          // Column 2 is the name column
          DataView dvSql = (DataView)StudentsDataSource.Select(DataSourceSelectArguments.Empty);
          foreach (DataRowView drvSql in dvSql)
          {
            if (drvSql["Roll Number"].ToString()==AddStudents.Rows[i].Cells[2].Text.ToString())
            {
              string studentId = drvSql["StudentId"].ToString();

              string connectionString = ConfigurationManager.ConnectionStrings["EIMSConnectionString"].ConnectionString;
              //string insertSql = "INSERT INTO StudentProfiles(FirstName, LastName, Contact, Department, Batch, RollNo) VALUES(@FirstName, @LastName, @Contact, @Department, @Batch, @RollNo)";
              string insertSql = "insert into ClassStudents values (@StudentId, @ClassId)";

              using (SqlConnection myConnection = new SqlConnection(connectionString))
              {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                myCommand.Parameters.AddWithValue("@StudentId", studentId);
                myCommand.Parameters.AddWithValue("@ClassId", Request.QueryString["id"]);
                myCommand.ExecuteNonQuery();
              }
            }
          }
          //Label1.Text+=AddStudents.Rows[i].Cells[2].Text.ToString();
          
        }
      }
      Session["Notice"] = "Selected students have been added to the class";
      Response.Redirect("~/Shared/Class.aspx?id=" + Request.QueryString["id"]);
    }
    protected void ClassStudentsDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
      e.Command.Parameters["@ClassId"].Value = Request.QueryString["id"];
    }
}