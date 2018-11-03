namespace dotnet_webapp
{
    public class ViewModelBase
    {
        public string AppName
        {
            get
            {
                return "U.S. Federal Holidays";
            }
            set
            {
                AppName = value;
            }
        }
        public string Copyright
        {
            get
            {
                return "&copy; 2018 - Scott Smith";
            }
            set
            {
                Copyright = value;
            }
        }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
