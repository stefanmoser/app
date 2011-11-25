<%@ Application Language="C#" %>
<%@ Import Namespace="app.tasks.startup" %>
<%@ Import Namespace="app.web.core" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
      Startup.run();
    }

</script>
