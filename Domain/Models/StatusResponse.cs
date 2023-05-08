namespace Domain.Models
{
    public class StatusResponse
    {
        public object Data { get; set; }
        public List<Error> Errors { get; set; } = new();
    }

    public class Error
    {
        public string Field { get; set; } 
        public string Message { get; set; }
    }
}
