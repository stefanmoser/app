using System;

namespace app.utility.containers.basic
{
  public class DependencyCreationException : Exception
  {
    public DependencyCreationException(Type bad_type, Exception e) : base(string.Format("Could not create a {0}",bad_type.Name), e)
    {
      this.type_that_could_not_be_created = bad_type;
    }

    public Type type_that_could_not_be_created { private set; get; }
  }
}