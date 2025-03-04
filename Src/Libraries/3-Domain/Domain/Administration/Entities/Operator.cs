﻿using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;


namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
   public class Operator :User
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(string displayName,string phoneNumber, string email, string userName, string password, IEncryptionService encryptionService)
        :base(displayName, phoneNumber, email, userName, password,encryptionService)
        {
        }



        #endregion

        #region Properties

        public string[] RolesId { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public override void Update(string displayName, string email, string userName)
        {
            base.Update(displayName,email, userName);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateRoles(string[] rolesId)
        {
            RolesId = rolesId;
            base.Update();
        }



        #endregion

        #region Private Methods



        #endregion
    }
}
