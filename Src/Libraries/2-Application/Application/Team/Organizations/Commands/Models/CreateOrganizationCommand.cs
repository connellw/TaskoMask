﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Team.Organizations.Commands.Models
{
   public class CreateOrganizationCommand : OrganizationBaseCommand
    {
        public CreateOrganizationCommand(string name, string description, string ownerMemberId)
        {
            Name = name;
            Description = description;
            OwnerMemberId = ownerMemberId;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string OwnerMemberId { get; private set; }
    }
}
