﻿using BloggerSample.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace BloggerSample.Model
{
    public class Category : Entity<int>
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
