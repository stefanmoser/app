using app.web.core;

namespace app.web.application
{
  public class ViewReport<TResponse,Query> : IImplementAUseCase where Query : IRunQuery<TResponse>
  {
    Query query;
    IDisplayReportModels response_gateway;

    public ViewReport(Query query, IDisplayReportModels response_gateway)
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