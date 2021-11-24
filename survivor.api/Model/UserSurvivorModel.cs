﻿using survivor.api.Manager;
using System;

namespace survivor.api.Model
{
    public class UserSurvivorModel : IModel<Guid>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get ; set;}
        public int Role { get; set;}

    }
}
