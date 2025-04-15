using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.DTO;
using UserService.DTO.Respone;
using UserService.Models;
using UserService.Repository;

namespace UserService.Service
{
    [RequiredArgsConstructor]
    public partial class RoleService : IRoleRepository
    {
        private readonly UserContext userContext;
        public async Task<ResDTO<object>> GetRoles(int page = 1, int limit = 10, string? keyword = null)
        {
            var query = userContext.roles.AsQueryable();

            // 🔍 Tìm kiếm theo từ khóa (nếu có)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(r => r.Name.Contains(keyword));
            }

            // 📊 Lấy tổng số lượng role
            int totalCount = await query.CountAsync();

            // 📝 Phân trang dữ liệu
            var roles = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(r => new RoleDTORespone
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();


            return new ResDTO<object>
            {
                Code = 200,
                Message = "Success",
                Data = new
                {
                    Role = roles,
                    TotalCount = totalCount,
                }
             
            };
        }


        // 🔹 Lấy Role theo ID
        public async Task<ResDTO<Role>> GetRoleById(string id)
        {
            var role = await userContext.roles.FindAsync(id);
            if (role == null)
            {
                return new ResDTO<Role>
                {
                    Code = 404,
                    Message = "Role not found",
                    Data = null
                };
            }

            return new ResDTO<Role>
            {
                Code = 200,
                Message = "Success",
                Data = role
            };
        }

        // 🔹 Tạo Role mới
        public async Task<ResDTO<Role>> CreateRole(string roleName)
        {
            if (await userContext.roles.AnyAsync(r => r.Name == roleName))
            {
                return new ResDTO<Role>
                {
                    Code = 400,
                    Message = "Role already exists",
                    Data = null
                };
            }

            var role = new Role { Name = roleName };
            userContext.roles.Add(role);
            await userContext.SaveChangesAsync();

            return new ResDTO<Role>
            {
                Code = 201,
                Message = "Role created successfully",
                Data = null
            };
        }

        // 🔹 Cập nhật Role theo ID
        public async Task<ResDTO<Role>> UpdateRole(string id, string roleName)
        {
            var role = await userContext.roles.FindAsync(id);
            if (role == null)
            {
                return new ResDTO<Role>
                {
                    Code = 404,
                    Message = "Role not found",
                    Data = null
                };
            }

            role.Name = roleName;
            userContext.roles.Update(role);
            await userContext.SaveChangesAsync();

            return new ResDTO<Role>
            {
                Code = 200,
                Message = "Role updated successfully",
                Data = null
            };
        }

        // 🔹 Xóa Role theo ID
        public async Task<ResDTO<Role>> DeleteRole(string id)
        {
            var role = await userContext.roles.FindAsync(id);
            if (role == null)
            {
                return new ResDTO<Role>
                {
                    Code = 404,
                    Message = "Role not found",
                    Data = null
                };
            }

            userContext.roles.Remove(role);
            await userContext.SaveChangesAsync();

            return new ResDTO<Role>
            {
                Code = 200,
                Message = "Role deleted successfully",
                Data = null
            };
        }
    }
}
