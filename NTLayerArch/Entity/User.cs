using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTLayerArch.Entity
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }
        
        public string DeletedAt { get; set; }
    }
}