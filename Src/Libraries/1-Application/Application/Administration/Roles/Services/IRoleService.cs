﻿using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Application.Common.Base.Services;
using System.Collections.Generic;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Application.Administration.Roles.Services
{
    public interface IRoleService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(RoleUpsertDto input);
        Task<Result<CommandResult>> UpdatePermissionsAsync(string id, string[]permissionsId);
        Task<Result<RoleDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync();
    }
}
