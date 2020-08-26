using BloggerSample.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerSample.Model
{
    public class UserDetail : Entity<int>
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("User")]
        public int UserDetailId { get; set; }

        public string Adress { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Sex { get; set; }
        public string Vocation { get; set; }
        public virtual User User { get; set; }

    }
}
