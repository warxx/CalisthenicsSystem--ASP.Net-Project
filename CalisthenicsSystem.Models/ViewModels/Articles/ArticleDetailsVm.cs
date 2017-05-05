﻿using System;

namespace CalisthenicsSystem.Models.ViewModels.Articles
{
    public class ArticleDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorName { get; set; }
    }
}
