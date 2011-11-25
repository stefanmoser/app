<%@ Application Language="C#" %>
<%@ Import Namespace="app.web.core" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
      IncomingRequest.builder_factory = () => new RequestMatchBuilder();
    }

</script>
