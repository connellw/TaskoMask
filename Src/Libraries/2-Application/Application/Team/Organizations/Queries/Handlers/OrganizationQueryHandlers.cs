﻿using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Organizations.Queries.Models;
using TaskoMask.Application.Core.Dtos.Team.Organizations;

using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Team.Data;

namespace TaskoMask.Application.Team.Organizations.Queries.Handlers
{
    public class OrganizationQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationBasicInfoDto>,
        IRequestHandler<GetOrganizationReportQuery, OrganizationReportDto>,
        IRequestHandler<GetOrganizationsByOwnerMemberIdQuery, IEnumerable<OrganizationBasicInfoDto>>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctors

        public OrganizationQueryHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<OrganizationBasicInfoDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);

            return _mapper.Map<OrganizationBasicInfoDto>(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OrganizationBasicInfoDto>> Handle(GetOrganizationsByOwnerMemberIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByOwnerMemberIdAsync(request.OwnerMemberId);
            return _mapper.Map<IEnumerable<OrganizationBasicInfoDto>>(organizations);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<OrganizationReportDto> Handle(GetOrganizationReportQuery request, CancellationToken cancellationToken)
        {
            return new OrganizationReportDto();
        }


        #endregion

    }
}
