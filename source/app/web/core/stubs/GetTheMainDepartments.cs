using System.Collections.Generic;
using app.web.application;
using app.web.application.stubs;

namespace app.web.core.stubs
{
  public class GetTheMainDepartments : IRunQuery<IEnumerable<Department>>
  {
    public IEnumerable<Department> run_using(IContainRequestInformation request)
    {
      return Stub.with<StubFindInformationInTheStore>().get_the_main_departments();
    }
  }
}