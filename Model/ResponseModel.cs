namespace JobApplication.Model
{
    public class ResponseModel
    {
        public bool IsSuccess
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public Object Result { get; set; }
    }
}
