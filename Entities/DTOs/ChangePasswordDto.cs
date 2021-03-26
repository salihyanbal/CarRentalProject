using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ChangePasswordDto : IDto
    {
        public int UserId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
