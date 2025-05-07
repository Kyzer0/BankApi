namespace CostumeResponse
{
    /// <summary>
    /// Adding Costume Response For Api
    /// </summary>
    public class ApiResponse<T>
    {
        public bool isSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
