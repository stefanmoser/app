using System;
using System.Reflection;

namespace app.utility.containers.basic
{
  public interface IPickTheConstructorForAType
  {
    ConstructorInfo get_applicable_constructor_on(Type type);
  }
}