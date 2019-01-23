using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain
{
    public abstract class Entity
    {
        protected Entity()
        {

        }
        public Guid Id { get; private set; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public void GenerateId()
        {
            Id = Guid.NewGuid();
        }
    }
}
