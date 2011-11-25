namespace app.tasks.startup
{
  public interface IProvideContainerRegistrationServices
  {
  	void register<Implementation>();
    void register<Contract, Implementation>() where Implementation : Contract;
    void register_instance<RegisteredType>(RegisteredType item);
  }
}