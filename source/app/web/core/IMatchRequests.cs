namespace app.web.core
{
    public interface IMatchRequests
    {
        bool matches_request(IContainRequestInformation the_request);
    }
}