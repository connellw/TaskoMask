﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BoardsController : BaseApiController
    {
        #region Fields

        private readonly IBoardService _boardService;

        #endregion

        #region Ctors

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get board detail
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            return await _boardService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Create(BoardUpsertDto input)
        {
            return await _boardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing board
        /// </summary>
        [HttpPut]
        [Route("boards")]
        public async Task<Result<CommandResult>> Update(BoardUpsertDto input)
        {
            return await _boardService.UpdateAsync(input);
        }



        #endregion

    }
}
