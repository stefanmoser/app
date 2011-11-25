using System;
using System.Reflection;
using System.Linq;

namespace app.utility.containers.basic
{
  public class GreedyConstructorSelectionStrategy :IPickTheConstructorForAType
  {
    public ConstructorInfo get_applicable_constructor_on(Type type)
    {
      return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
  }
}