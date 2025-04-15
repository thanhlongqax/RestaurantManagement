using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using TableServices.Context;
using TableServices.DTO;
using TableServices.DTO.Request;
using TableServices.Enums;
using TableServices.Models;
using TableServices.Repository;

namespace TableServices.Service
{
    [RequiredArgsConstructor]
    public partial class TableService : ITableRepository
    {
        private readonly TableContext tableContext;
        public async Task<ResDTO<IEnumerable<Table>>> GetTables() =>
        new ResDTO<IEnumerable<Table>> { Code = 200, Message = "Success", Data = await tableContext.tables.ToListAsync() };

        public async Task<ResDTO<Table>> GetTableById(string id)
        {
            var table = await tableContext.tables.FindAsync(id);
            return table == null
                ? new ResDTO<Table> { Code = 404, Message = "Table not found" }
                : new ResDTO<Table> { Code = 200, Message = "Success", Data = table };

        }

        public async Task<ResDTO<Table>> AddTable(AddTableRequestDTO table)
        {
            Table newTable = new Table();
            newTable.Status = table.Status;
            newTable.Number = table.Number;
            newTable.Capacity = table.Capacity;
            tableContext.tables.Add(newTable);
            await tableContext.SaveChangesAsync();
            return new ResDTO<Table> { Code = 201, Message = "Table created", Data = null };
        }
        public async Task<ResDTO<Table>> UpdateTable(Table table)
        {
            tableContext.tables.Update(table);
            await tableContext.SaveChangesAsync();
            return new ResDTO<Table> { Code = 200, Message = "Table updated", Data = table };
        }

        public async Task<ResDTO<Table>> DeleteTable(string id)
        {
            var table = await tableContext.tables.FindAsync(id);
            if (table == null)
                return new ResDTO<Table> { Code = 404, Message = "Table not found" };

            tableContext.tables.Remove(table);
            await tableContext.SaveChangesAsync();
            return new ResDTO<Table> { Code = 200, Message = "Table deleted" };
        }
        public async Task<ResDTO<object>> IsTableStatusExistsAsync(string tableId)
        {
            var table = await tableContext.tables.FindAsync(tableId);
            if (table == null)
                return new ResDTO<object> { Code = 404, Message = "Table not found" };

            return new ResDTO<object>
            {
                Code = 200,
                Message = "Check trạng thái bàn thành công",
                Data = table.Status
            };
        }
        public async Task<ResDTO<object>> UpdateTableStatusAsync(string tableId, TableStatus newStatus)
        {
            var table = await tableContext.tables.FindAsync(tableId);
            if (table == null)
                return new ResDTO<object> { Code = 404, Message = "Table not found" };

            table.Status = newStatus;
            tableContext.tables.Update(table);
            await tableContext.SaveChangesAsync();

            return new ResDTO<object>
            {
                Code = 200,
                Message = "Cập nhật trạng thái bàn thành công",
                Data = true
            };
        }



    }
}
