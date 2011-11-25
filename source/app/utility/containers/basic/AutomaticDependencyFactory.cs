using System;
using System.Collections.Generic;

namespace app.utility.containers.basic
{
  public class AutomaticDependencyFactory : ICreateADependency
  {
	  readonly IFetchDependencies fetcher;
	  readonly IPickTheConstructorForAType picker;
	  readonly Type type;

	  public AutomaticDependencyFactory(IFetchDependencies fetcher, IPickTheConstructorForAType picker, Type type)
	  {
		  this.fetcher = fetcher;
		  this.picker = picker;
		  this.type = type;
	  }

	  public object create()
	  {
		  var constructor_info = picker.get_applicable_constructor_on(type);
		  var parameters = new List<object>();

		  foreach (var required_param in constructor_info.GetParameters())
		  {
			  parameters.Add(fetcher.an(required_param.ParameterType));
		  }
		  return Activator.CreateInstance(this.type, parameters.ToArray());
	  }
  }
}