﻿// MIT License

using DnnReactModule.Utilities.FiltersAttribute;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Web.Api;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DnnReactModule.Controllers
{
    [ModuleException, ResultAuthorize, ValidateModel]
    public abstract class ModuleApiController : DnnApiController
    {
        /// <summary>
        /// Gets information about the Dnn user.
        /// </summary>
        public new virtual UserInfo UserInfo => base.UserInfo;

        /// <summary>
        /// Gets Current PortalId .
        /// </summary>
        public int PortalId => this.ActiveModule != null ? this.ActiveModule.PortalID : this.PortalSettings.PortalId;

        /// <summary>
        /// Gets or sets a value indicating whether the user can edit this module.
        /// </summary>
        public virtual bool CanEdit
        {
            get
            {
                try
                {
                    return ModulePermissionController.HasModuleAccess(DotNetNuke.Security.SecurityAccessLevel.Edit, "EDIT", this.ActiveModule);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            [ExcludeFromCodeCoverage]
            set
            {
                throw new Exception("Only override this setter for testing.");
            }
        }
    }
}
