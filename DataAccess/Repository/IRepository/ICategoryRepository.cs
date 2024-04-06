﻿using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    // is that the same?
    //public interface ICategoryRepository<Category> : IRepository<Category> where Category : class
    public interface ICategoryRepository : IRepository<Category> 
    {
        public void Save();
        public void Update(Category category);
    }
}
