using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTLayerArch.DTO
{
    public class UserToUpdateDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}