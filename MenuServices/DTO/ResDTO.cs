using Lombok.NET;

namespace MenuServices.DTO
{

    [AllArgsConstructor]
    [NoArgsConstructor]
    [With]
    public partial class ResDTO<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
