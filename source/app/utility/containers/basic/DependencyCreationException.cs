using System;

namespace app.utility.containers.basic
{
  public class DependencyCreationException : Exception
  {

	  public DependencyCreationException(string message, Type bad_type, Exception e) :base(message, e)
	  {
		this.type_that_could_not_be_created = bad_type;
	  }

	  public Type type_that_could_not_be_created { get; private set; }
  }
}