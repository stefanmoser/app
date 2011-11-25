using System;

namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessOneRequest
  {
    public void process(IContainRequestInformation request)
    {
      throw new NotImplementedException(string.Format("Could not process a request with the name {0}",request.request_name));

    }

    public bool can_handle(IContainRequestInformation request)
    {
      return false;
    }
  }
}