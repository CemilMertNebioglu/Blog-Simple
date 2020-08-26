using BloggerSample.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerSample.Model
{
    public class Role : Entity<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
