﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class BoardsController : BaseMvcController
    {
        #region Fields

        private readonly IBoardService _boardService;

        #endregion

        #region Ctors

        public BoardsController(IBoardService boardService, IMapper mapper) : base(mapper)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var boardDetailQueryResult = await _boardService.GetDetailsAsync(id);
            return View(boardDetailQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string projectId)
        {
            var model = new BoardUpsertDto
            {
                ProjectId = projectId,
            };
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(BoardUpsertDto input)
        {
            var cmdResult = await _boardService.CreateAsync(input);
            return View(cmdResult, input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var boardQueryResult = await _boardService.GetByIdAsync(id);
            return View<BoardBasicInfoDto, BoardUpsertDto>(boardQueryResult);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(BoardUpsertDto input)
        {
            var cmdResult = await _boardService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
