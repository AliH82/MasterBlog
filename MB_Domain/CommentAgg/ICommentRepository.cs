﻿using _01_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<int, Comment>
    {
       
    }
}
