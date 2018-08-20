using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikestCore.Abstract
{
    /// <summary>
    /// Интерфейс API сервиса Likest
    /// </summary>
    public interface ILikestApi
    {
        /// <summary>
        /// Загрузка системы
        /// </summary>
        IObservable<(double current, double slowdown)> Load { get; }
    }
}
