using System;

namespace app.utility.containers.basic
{
  public class DependencyFactoryNotRegisteredException:Exception
  {
    public DependencyFactoryNotRegisteredException(Type type):base(type.Name)
    {
      this.type_that_has_no_factory = type;
    }

    public Type type_that_has_no_factory { get; set; }
  }
}