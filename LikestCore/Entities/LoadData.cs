using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikestCore.Entities
{
    /// <summary>
    /// Содержит информацию, возвращающуюся с метода API system.load сервиса likest
    /// </summary>
    public class LoadData
    {
        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Текущая нагрузка
        /// </summary>
        public double Current { get; set; }

        /// <summary>
        /// Максимальная нагрузка на сервер
        /// </summary>
        public double SlowDown { get; set; }
    }
}
