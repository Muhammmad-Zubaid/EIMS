﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyClasses.aspx.cs" Inherits="Teachers_MyClasses" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>

            <h4>Classes</h4>
            
        </HeaderTemplate>
        
        <ItemTemplate>
            <p>
                <asp:HyperLink ID="lnkMenuItem" runat="server" NavigateUrl='<%# "~/Shared/Class.aspx?id=" + Eval("ClassId") %>'><%# Eval("CourseName") + " - " + Eval("BatchName") + " - Section " + Eval("SectionName") + " - " + Eval("SemesterName") + "Semester" + " - " + Eval("DepartmentName") + "Department" + " - Teacher: " + Eval("TeacherName")  %></asp:HyperLink>
            </p>
        </ItemTemplate>
        <FooterTemplate>

            </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="ClassesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EIMSConnectionString %>" OnSelecting="ClassesDataSource_Selecting" SelectCommand="select Classes.ClassId,Courses.CourseName,Sections.SectionName,(TeacherProfiles.FirstName + ' ' + TeacherProfiles.LastName) as TeacherName, Batches.BatchName, Semesters.SemesterName,Departments.DepartmentName from Classes
INNER JOIN TeacherProfiles ON Classes.TeacherId=TeacherProfiles.TeacherId
INNER JOIN Courses ON Classes.CourseId=Courses.CourseId
INNER JOIN Sections ON Classes.SectionId=Sections.SectionId
INNER JOIN Batches ON Classes.BatchId=Batches.BatchId
INNER JOIN Semesters ON Classes.SemesterId=Semesters.SemesterId
INNER JOIN Departments ON Classes.DepartmentId=Departments.DepartmentId
WHERE TeacherProfiles.TeacherId = @TeacherId">
        <SelectParameters>
            <asp:Parameter Name="TeacherId" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

