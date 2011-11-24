using System.Web;

namespace app.web.core.aspnet
{
  public class PageFactory : ICreateAResponse
  {
      IFindPathsToViews view_path_finder;

      public PageFactory(IFindPathsToViews view_path_finder)
      {
          this.view_path_finder = view_path_finder;
      }

      public IHttpHandler create_using<ReportModel>(ReportModel model)
      {
          view_path_finder.find_path_for<ReportModel>();

          return null;
      }
  }
}