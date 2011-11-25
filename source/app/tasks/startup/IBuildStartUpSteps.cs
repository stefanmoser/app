using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
  public class BuildStartUpSteps
  {
    List<Type> steps;

    public IEnumerable<Type> start_up_steps { get { return steps; } }

    public BuildStartUpSteps ()
    {
      this.steps = new List<Type>();
    }

    public void AddStep<T>()
    {
      this.steps.Add(typeof(T));
    }
  }
}