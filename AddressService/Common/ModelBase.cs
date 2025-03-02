using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Common
{
    /// <summary>
    /// Содержит свойство Id - общее для всех классов сущностей и моделей
    /// </summary>
    public abstract class ModelBase
    {
        public int Id { get; set; }
    }
}
