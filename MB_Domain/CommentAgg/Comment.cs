﻿using _01_Framework.Domian;
using MB_Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Domain.CommentAgg
{
    public class Comment : BaseDomian
    {
        public int ArticleId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Statuse { get; private set; }
        public Article Article { get; private set; }

        protected Comment()
        {
            
        }

        public Comment(string name, string email, string message,int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            Statuse = Statuses.New;
            ArticleId = articleId;
        }

        public void Cancell()
        {
            Statuse = Statuses.Cancell;
        }

        public void Confirm()
        {
            Statuse = Statuses.Confirm;
        }
    }
}
