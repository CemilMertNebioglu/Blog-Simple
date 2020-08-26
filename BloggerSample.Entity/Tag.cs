using BloggerSample.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerSample.Model
{
    public class Tag : Entity<int>
    {
        public Tag()
        {
        }
        public string Name { get; set; }

        [ForeignKey("Article")]
        public Nullable<int> ArticleId { get; set; }
        public virtual Article Article { get; set; }


    }
}
