<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application" %>
<%@ Import Namespace="app.web.core.stubs" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <% 
               var number = 0;
              foreach (var department in this.model)
               {
                 %>
              <tr class="ListItem">
               <td><a href="<%= number++ % 2 == 0 ? typeof(ViewDepartmentsInDepartmentRequest).Name : typeof(ViewProductsRequest).Name %>.iqmetrix"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
