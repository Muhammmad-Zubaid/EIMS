﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EventCalendar.aspx.cs" Inherits="Students_EventCalendar" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="row">
    <div class="span10 offset1">
      <asp:Calendar ID="EventCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="450px" NextPrevFormat="FullMonth" Width="900px" OnDayRender="EventCalendar_DayRender" SelectionMode="None">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <DayStyle BorderColor="Black" BorderStyle="None" BorderWidth="1px" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
      </asp:Calendar>
      <asp:SqlDataSource ID="AssignmentsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EIMSConnectionString %>" SelectCommand="SELECT * FROM [Assignments]"></asp:SqlDataSource>
      <asp:SqlDataSource ID="QuizzesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EIMSConnectionString %>" SelectCommand="SELECT * FROM [Quizzes]"></asp:SqlDataSource>
    </div>
  </div>
  <!-- Modal -->
<div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h3 id="myModalLabel">Modal header</h3>
  </div>
  <div class="modal-body">
    <b>Quiz Date: </b>
    <p id="date-modal"></p>
    <b>Total Marks: </b>
    <p id="marks-modal"></p>
    <b>Description: </b>
    <p id="body-modal">One fine body…</p>
  </div>
  <div class="modal-footer">
    <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
  </div>
</div>
  <script type="text/javascript">
    $(document).ready(function () {
      $('.event').click(function () {
        var linkId = $(this).attr("id");
        
        var title=$('#' + linkId + 'Title').val();
        $('#myModalLabel').text(title);
        var description = $('#' + linkId + 'Description').val();
        $('#body-modal').text(description);
        var date = $('#' + linkId + 'Date').val();
        $('#date-modal').text(date);
        var marks = $('#' + linkId + 'Marks').val();
        $('#marks-modal').text(marks);
      });
    });
  </script>
</asp:Content>
