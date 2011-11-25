using System;
using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_from(HttpContext the_context)
    {
      return new StubRequest(the_context);
    }

    class StubRequest : IContainRequestInformation
    {
      HttpContext context;

      public StubRequest(HttpContext context)
      {
        this.context = context;
      }

      public string request_name
      {
        get { return context.Request.Path.Replace(".iqmetrix", "").Replace("/views/",""); }
      }

      public ViewModel map<ViewModel>()
      {
        object val = Activator.CreateInstance<ViewModel>();
        return (ViewModel) val;
      }
    }
  }
}