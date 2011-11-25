using System.Collections.Generic;
using app.web.application;
using app.web.application.stubs;

namespace app.web.core.stubs
{
  public class GetProductsInADepartment : IRunQuery<IEnumerable<Product>>
  {
    public IEnumerable<Product> run_using(IContainRequestInformation request)
    {
      return Stub.with<StubFindInformationInTheStore>().get_the_products_in_a_department(request.map<Department>());
    }
  }
}