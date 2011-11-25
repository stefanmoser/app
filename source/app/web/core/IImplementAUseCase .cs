using System.Security;
using System.Security.Principal;
using System.Threading;

namespace app.web.core
{
  public interface IImplementAUseCase 
  {
    void process(IContainRequestInformation request);
  }

  public interface IEncapsulateAMethodCall
  {
    void proceed();
  }

  public interface IInterceptMethods
  {
    void intercept(IEncapsulateAMethodCall method);
  }

  public interface IEnforceSecurity
  {
    bool is_happy_with(IPrincipal principal);
  }

  public class SecuredMethod : IInterceptMethods
  {
    IEnforceSecurity criteria;

    public SecuredMethod(IEnforceSecurity criteria)
    {
      this.criteria = criteria;
    }

    public void intercept(IEncapsulateAMethodCall method)
    {
      if (criteria.is_happy_with(Thread.CurrentPrincipal)) method.proceed();
      throw new SecurityException("You are not authorized");
    }
  }

  public class TimedMethod : IInterceptMethods
  {
    public void intercept(IEncapsulateAMethodCall method)
    {
      //start stopwatch
      method.proceed();
      //stop stopwatch
    }
  }
  class TimedBehaviour : IImplementAUseCase
  {
    IImplementAUseCase original;

    public TimedBehaviour(IImplementAUseCase original)
    {
      this.original = original;
    }

    public void process(IContainRequestInformation request)
    {
      //original.process();
    }
  }
}