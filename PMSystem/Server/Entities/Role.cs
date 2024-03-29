﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using PMSystem.Shared;
using PMSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 权限实体类
    /// </summary>
    public class Role:BaseEntity
    {

        /// <summary>
        /// 权限类型
        /// </summary>
        public RoleType role_type { get; set; }

        /// <summary>
        /// 对应的用户列表
        /// </summary>
        [Navigate(typeof(UserRoleMapping),nameof(UserRoleMapping.role_id),nameof(UserRoleMapping.user_id))]
        public List<User> Users { get; set; }
    }
}