using Lombok.NET;

namespace TableServices.DTO
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
