using System;
using System.Collections.Generic;
using app.web.application;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToViews
  {
    public string find_path_for<ViewModel>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<Department>), path_to("departmentbrowser")},
        {typeof(IEnumerable<Product>), path_to("productbrowser")}
      };

      return paths[typeof(ViewModel)];
    }

    string path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}