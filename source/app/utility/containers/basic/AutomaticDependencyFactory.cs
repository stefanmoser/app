using System;
using System.Linq;

namespace app.utility.containers.basic
{
  public class AutomaticDependencyFactory : ICreateADependency
  {
    IFetchDependencies fetcher;
    IPickTheConstructorForAType picker;
    Type type;

    public AutomaticDependencyFactory(IFetchDependencies fetcher, IPickTheConstructorForAType picker, Type type)
    {
      this.fetcher = fetcher;
      this.picker = picker;
      this.type = type;
    }

    public object create()
    {
      var ctor = picker.get_applicable_constructor_on(type);
      var args = ctor.GetParameters().Select(x => x.ParameterType)
        .Select(x => fetcher.an(x));
      return ctor.Invoke(args.ToArray());
    }
  }
}