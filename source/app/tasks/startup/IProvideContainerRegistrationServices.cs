using System;
using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public interface IProvideContainerRegistrationServices : IDictionary<Type, ICreateADependency>
  {
    void register<Implementation>();
    void register<Contract, Implementation>() where Implementation : Contract;
    void register_instance<RegisteredType>(RegisteredType item);
  }
}