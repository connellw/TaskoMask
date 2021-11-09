﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Team.Organizations.Commands.Validations
{
   public class CreateOrganizationCommandValidation:OrganizationValidation<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidation()
        {
            ValidateDescription();
        }

    }
}
