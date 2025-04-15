namespace OrderServices.enums
{
    public enum OrderStatus
    {
        Pending,       // Đơn mới tạo, chưa xử lý
        InProgress,    // Đang chế biến
        Completed,     // Đã hoàn thành
        Cancelled
    }
}
