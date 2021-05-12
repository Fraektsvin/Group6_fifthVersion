namespace DatabaseTier.Models
{
    public class Request
    {
        public string Header { get; set; }
        public object Obj { get; set; }

        public Request(string header, object obj)
        {
            Header = header;
            Obj= obj;
        }
    }
}