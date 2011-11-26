using System;
namespace app.utility.containers
{
  public class TypeAlreadyRegisteredException : Exception
  {
    public TypeAlreadyRegisteredException(Type type):
      base(type.Name + " already registered")
    {
    }
  }
}