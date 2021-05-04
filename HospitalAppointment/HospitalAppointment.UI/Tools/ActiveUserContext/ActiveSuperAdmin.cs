using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.SuperAdmin;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Tools.ActiveUserContext
{
    public class ActiveSuperAdmin
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly ISuperAdminService _superAdminService;

        public ActiveSuperAdmin(IHttpContextAccessor httpContextAccessor,IUserService userService,ISuperAdminService superAdminService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _superAdminService = superAdminService;

        }
        ActiveSuperAdminDto _activeSuperAdmin = new ActiveSuperAdminDto();

        public ActiveSuperAdminDto GetActiveSuperAdmin()
        {
            #region Deneme
            //_activeSuperAdmin.UserId = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.Tcno = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "TCNo").Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.Name = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.SurName = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Surname).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.Email = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.BirthDate = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.DateOfBirth).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.Telephone = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.MobilePhone).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.Gender = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Gender).Select(c => c.Value).SingleOrDefault();
            //_activeSuperAdmin.RolId = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Surname).Select(c => c.Value).SingleOrDefault();
            #endregion
            int userId = Convert.ToInt32( _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
            int superAdminId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "SuperAdminId").Select(c => c.Value).SingleOrDefault());
            var activeUser = _userService.GetById(userId);
            var superAdmin = _superAdminService.GetById(superAdminId);
            _activeSuperAdmin.UserId = activeUser.Id;
            _activeSuperAdmin.Tcno = activeUser.Tcno;
            _activeSuperAdmin.RolId = activeUser.RolId;
            _activeSuperAdmin.Name = activeUser.Name;
            _activeSuperAdmin.SurName = activeUser.SurName;
            _activeSuperAdmin.Email = activeUser.Email;
            _activeSuperAdmin.BirthDate = activeUser.BirthDate;
            _activeSuperAdmin.Telephone = activeUser.Telephone;
            _activeSuperAdmin.Gender = activeUser.Gender;
            _activeSuperAdmin.SuperAdminId = superAdmin.Id;
            _activeSuperAdmin.Apellation = superAdmin.Apellation;
            return _activeSuperAdmin;
        }

    }

}
