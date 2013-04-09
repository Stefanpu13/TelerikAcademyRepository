using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.IEnumerableExtension
{
    public static class IEnumerableExtensions
    {
        public static T SumExt<T>(this IEnumerable<T> collection) 
        {
            T sum = default(T);

            foreach (var item in collection)
            {
                sum +=(dynamic) item;
            }

            return sum;
        }

        public static T ProductExt<T>(this IEnumerable<T> collection) where T:IComparable
        {
            if (collection != null)
            {

                if (collection.Count()>0)
                {
                    dynamic product = collection.First();

                    //If first element is zero (0, 0.0, ...) no need to multiply
                    if (product.CompareTo(default(T)) == 0)
                    {
                        return default(T);
                    }

                    foreach (var item in collection)
                    {
                        product *= item;
                    }

                    //Possible attempt to divide by zero
                    product /= collection.First();
                    return product;
                }

                else
                {
                       string message ="Collection contains no elements.";
                       throw new InvalidOperationException(message);
                }
               
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static double AverageExt<T>(this IEnumerable<T> collection)
        {
            if (collection != null)
            {
                if (collection.Count() > 0)
                {
                    double average = Convert.ToDouble(default(T));
                    double count = collection.Count();

                    T sum = collection.SumExt();
                    average = (dynamic)sum / count;
                    return average;
                }
                // Consistent with built-in "Average" method which throws exception if collection
                //contains no elements. I decided to implement it that way.
                else
                {
                    string message ="Collection contains no elements.";
                    throw new InvalidOperationException(message);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
           
        }        

        public static T MinExt<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection != null)
            {
                T min = collection.First();

                //var remainingVlues =
                //from num in collection
                //where num.CompareTo(min) < 0
                //select num;

                foreach (var item in collection)
                {
                    if (item.CompareTo(min)<0)
                    {
                        min = item;
                    }
                }

                return min;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public static T MaxExt<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (collection != null)
            {
                T max = collection.First();

                foreach (var item in collection)
                {
                    if (item.CompareTo(max) > 0)
                    {
                        max = item;
                    }
                }

                return max;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
