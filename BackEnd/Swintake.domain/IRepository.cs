﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain
{
    public interface IRepository<T> where T : Entity
    {
        T Save(T entity);
        T Update(T entity);
        IList<T> GetAll();
        T Get(Guid entityId);
    }
}
