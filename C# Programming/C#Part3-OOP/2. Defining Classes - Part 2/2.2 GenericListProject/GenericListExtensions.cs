using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace GenericListProject
{
    static class  GenericListExtensions
    {
        public static T Min<T>(this GenericList<T> list) where T : IComparable
        {
            int usedCellsCount = list.UsedCells;
            T minElement = default(T);

            // If there are some used cells in the generic list, then a minimum element will be found,
            // otherwise, the defalt value of the type, making the list, will be returned. 

            if (usedCellsCount > 0)
            {
                minElement = list.ItemsArray[0];
                for (int i = 1; i < usedCellsCount; i++)
                {
                    if (list.ItemsArray[i].CompareTo(minElement) < 0)
                    {
                        minElement = list.ItemsArray[i];
                    }
                }
            }

            return minElement;
        }

        public static T Max<T>(this GenericList<T> list) where T : IComparable
        {
            int usedCellsCount = list.UsedCells;
            T maxElement = default(T);

            // If there are some used cells in the generic list, then a maximum element will be found,
            // otherwise, the defalt value of the type, making the list, will be returned. 
            if (usedCellsCount > 0)
            {
                maxElement = list.ItemsArray[0];
                for (int i = 1; i < usedCellsCount; i++)
                {
                    if (list.ItemsArray[i].CompareTo(maxElement) > 0)
                    {
                        maxElement = list.ItemsArray[i];
                    }
                }
            }

            return maxElement;
        }
    }
}
