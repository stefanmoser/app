namespace app.web.core
{
  public interface IContainRequestInformation
  {
    InputModel map<InputModel>();
    string request_name { get; }
  }
}