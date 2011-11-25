using app.web.core;

namespace app.web.application
{
  public class ViewReport<TResponse> : IImplementAUseCase
  {
    IRunQuery<TResponse> query;
    IDisplayReportModels response_gateway;

    public ViewReport(IRunQuery<TResponse> query, IDisplayReportModels response_gateway)
    {
      this.query = query;
      this.response_gateway = response_gateway;
    }

    public void process(IContainRequestInformation request)
    {
      response_gateway.display(query.run_using(request));
    }
  }
}