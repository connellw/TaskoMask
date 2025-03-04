﻿using TaskoMask.Application.Administration.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Web.Common.Filters;
using TaskoMask.Web.Common.Extensions;
using TaskoMask.Web.Common.Enums;
using TaskoMask.Web.Common.Helpers;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{

    [Authorize]
    [Area("Administration")]
    public class RolesController : BaseMvcController
    {
        #region Fields

        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public RolesController(IRoleService roleService, IMapper mapper) : base(mapper)
        {
            _roleService = roleService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rolesListQueryResult = await _roleService.GetListAsync();
            return View(rolesListQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleUpsertDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _roleService.CreateAsync(input);
            var redirectUrl = $"/administration/roles/update/EntityId";
            return AjaxResult(cmdResult,redirectUrl: redirectUrl);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleService.GetDetailsAsync(id);
            return View(role);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoleUpsertDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _roleService.UpdateAsync(input);
            return AjaxResult(cmdResult);
        }





        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdatePermissions(string id, string[] PermissionsId)
        {
            var cmdResult = await _roleService.UpdatePermissionsAsync(id, PermissionsId);
            return AjaxResult(cmdResult);
        }



        #endregion

        #region Private Methods



        #endregion


    }
}
