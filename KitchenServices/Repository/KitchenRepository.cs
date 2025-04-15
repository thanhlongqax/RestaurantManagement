using KitchenServices.Context;
using KitchenServices.DTO;
using KitchenServices.Models;
using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace KitchenServices.Repository
{
    [RequiredArgsConstructor]
    public partial class KitchenRepository : IKitchenRepository
    {
        private readonly KitchenContext kitchenContext;


        public async Task<ResDTO<IEnumerable<KitchenOrder>>> GetPendingOrders()
        {
            DateTime today = DateTime.UtcNow.Date; // Lấy ngày hiện tại (UTC)

            var orders = await kitchenContext.kitchenOrders
                .Include(o => o.Items)
                .Where(o => !o.IsCompleted && o.CreatedAt >= today && o.CreatedAt < today.AddDays(1)) // Lọc theo ngày
                .OrderBy(o => o.CreatedAt) // Ưu tiên xử lý đơn hàng cũ trước
                .ToListAsync();

            return new ResDTO<IEnumerable<KitchenOrder>>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Danh sách đơn hàng chờ xử lý trong ngày",
                Data = orders
            };
        }


        public async Task<ResDTO<KitchenOrder>> GetOrderById(string id)
        {
            var order = await kitchenContext.kitchenOrders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return new ResDTO<KitchenOrder>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đơn hàng",
                    Data = null
                };
            }

            return new ResDTO<KitchenOrder>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Lấy thông tin đơn hàng thành công",
                Data = order
            };
        }

        public async Task<ResDTO<KitchenOrder>> CreateKitchenOrder(KitchenOrder order)
        {
            kitchenContext.kitchenOrders.Add(order);
            await kitchenContext.SaveChangesAsync();

            return new ResDTO<KitchenOrder>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Tạo đơn hàng cho bếp thành công",
                Data = order
            };
        }

        public async Task<ResDTO<KitchenOrder>> MarkOrderCompleted(string id)
        {
            var order = await kitchenContext.kitchenOrders
                .Include(o => o.Items) // Load danh sách món ăn
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return new ResDTO<KitchenOrder>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đơn hàng",
                    Data = null
                };
            }

            if (order.IsCompleted)
            {
                return new ResDTO<KitchenOrder>
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = "Đơn hàng đã hoàn thành trước đó",
                    Data = order
                };
            }

            // ✅ Tính tổng thời gian chuẩn bị món ăn
            order.totalPreparationTime = order.Items.Sum(i => i.PreparationTime ?? 0);

            // Đánh dấu hoàn thành
            order.IsCompleted = true;

            await kitchenContext.SaveChangesAsync();

            return new ResDTO<KitchenOrder>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Đã cập nhật trạng thái hoàn thành cho đơn hàng",
                Data = order
            };
        }


        public async Task<ResDTO<KitchenOrderItem>> MarkItemCompleted(string itemId)
        {
            var item = await kitchenContext.kitchenOrderItems.FindAsync(itemId);

            if (item == null)
            {
                return new ResDTO<KitchenOrderItem>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Không tìm thấy món ăn trong đơn hàng",
                    Data = null
                };
            }

            if (item.IsCompleted)
            {
                return new ResDTO<KitchenOrderItem>
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = "Món ăn đã hoàn thành trước đó",
                    Data = item
                };
            }

            // 🔥 Lấy CreatedAt từ KitchenOrder
            var kitchenOrder = await kitchenContext.kitchenOrders
                .Where(o => o.Items.Any(i => i.Id == item.Id))
                .Select(o => o.CreatedAt)
                .FirstOrDefaultAsync();

            if (kitchenOrder == DateTime.MinValue) // ✅ Sửa điều kiện kiểm tra null
            {
                return new ResDTO<KitchenOrderItem>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Không tìm thấy đơn hàng bếp",
                    Data = null
                };
            }


            // Đánh dấu hoàn thành
            item.IsCompleted = true;

            // ✅ Tính thời gian chế biến chính xác
            item.PreparationTime = (int)(DateTime.UtcNow - kitchenOrder).TotalMinutes;

            try
            {
                await kitchenContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ResDTO<KitchenOrderItem>
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = $"Lỗi khi cập nhật món ăn: {ex.Message}",
                    Data = null
                };
            }

            return new ResDTO<KitchenOrderItem>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Đã cập nhật trạng thái hoàn thành cho món ăn",
                Data = item
            };
        }



    }
}
