using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.infrastructure.Mappers
{
    public abstract class Mapper<DTO, DOMAIN>
    {
        public abstract DTO ToDto(DOMAIN domainObject);
        public abstract DOMAIN ToDomain(DTO dtoObject);
    }
}
