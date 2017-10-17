namespace Multibank.Autorizador.Services
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = false;
        public string Error { get; set; }
    }
}

