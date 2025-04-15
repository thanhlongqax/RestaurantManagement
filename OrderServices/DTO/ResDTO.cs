using Lombok.NET;

namespace OrderServices.DTO
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class ResDTO<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
