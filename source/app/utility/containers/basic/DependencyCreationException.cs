using System;

namespace app.utility.containers.basic
{
  public class DependencyCreationException : Exception
  {
    public Type type_that_could_not_be_created
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}