namespace app.web.core
{
    public interface IQueryReportModels<ReportModel>
    {
        ReportModel query_for_report_model(IContainRequestInformation request);
    }
}