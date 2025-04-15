using OrderServices.DTO;
using OrderServices.enums;

namespace OrderServices.Service
{
    public interface ITableService
    {

        Task<ResDTO<TableStatus?>> IsTableAvailable(string tableId ,string token);
        Task<ResDTO<bool>> SetTableStatus(string tableId, string status , string token);
    }
}
