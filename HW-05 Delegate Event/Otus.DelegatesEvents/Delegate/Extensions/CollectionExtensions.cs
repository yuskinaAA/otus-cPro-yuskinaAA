using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.HW.DelegatesEvents
{
    /*     
     Написать обобщённую функцию расширения, 
     находящую и возвращающую максимальный элемент коллекции.
     Функция должна принимать на вход делегат, 
     преобразующий входной тип в число для возможности поиска максимального значения.
     public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) 
     where T : class;
     */
    public static class CollectionExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            //проверка на наличие коллекции
            if(collection == null || !collection.Any())
            {
                throw new ArgumentNullException("Collection cannot be null or empty.", nameof(collection));
            }

            return collection.OrderByDescending(convertToNumber).FirstOrDefault();
            
        }
    }
}
