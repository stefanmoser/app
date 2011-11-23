namespace app.web.core
{
    public class Command : IProcessOneRequest
    {
        public void process(IContainRequestInformation request)
        {
            throw new System.NotImplementedException();
        }

        public bool can_handle(IContainRequestInformation request)
        {
            throw new System.NotImplementedException();
        }
    }
}