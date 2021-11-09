﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Members
{
    public class MemberRegisterDto
    {
        [Display(Name = nameof(ApplicationMetadata.DisplayName), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; set; }



        [Display(Name = nameof(ApplicationMetadata.Email), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Password), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = nameof(ApplicationMetadata.ConfirmPassword), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Compare(nameof(Password), ErrorMessageResourceName = nameof(ApplicationMetadata.ComparePasswords), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ConfirmPassword { get; set; }

    }
}
