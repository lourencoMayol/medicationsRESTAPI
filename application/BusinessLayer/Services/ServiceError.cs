namespace Application.BusinessLayer.Services
{
    public class ServiceError
    {
        public string Error { get; }
        public string Location { get; }
        public string ExceptionType { get; }

        public ServiceError(Exception ex)
        {
            Error = ex.Message;
            ExceptionType = ex.GetType().Name;

            var st = new System.Diagnostics.StackTrace(ex, true);
            var frame = st.GetFrames()?.FirstOrDefault(f => f.GetFileLineNumber() > 0);

            if (frame != null)
            {
                Location = $"{frame.GetFileName()} (line {frame.GetFileLineNumber()})";
            }
            else
            {
                Location = "Unknown location";
            }
        }
    }
}
