using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.DTO.DTOs
{
    public class UsertDetailsDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
    public class UsertDetailsUpdateDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
