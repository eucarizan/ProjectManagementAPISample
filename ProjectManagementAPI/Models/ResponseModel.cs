namespace ProjectManagementAPI.Models
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }
}
