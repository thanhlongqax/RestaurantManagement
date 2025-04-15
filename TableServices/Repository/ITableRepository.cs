using TableServices.DTO;
using TableServices.DTO.Request;
using TableServices.Enums;
using TableServices.Models;

namespace TableServices.Repository
{
    public interface ITableRepository
    {
        Task<ResDTO<IEnumerable<Table>>> GetTables();
        Task<ResDTO<Table>> GetTableById(string id);
        Task<ResDTO<Table>> AddTable(AddTableRequestDTO table);
        Task<ResDTO<Table>> UpdateTable(Table table);
        Task<ResDTO<Table>> DeleteTable(string id);

        Task<ResDTO<object>> IsTableStatusExistsAsync(string tableId);
        Task<ResDTO<object>> UpdateTableStatusAsync(string tableId, TableStatus newStatus);
    }
}
