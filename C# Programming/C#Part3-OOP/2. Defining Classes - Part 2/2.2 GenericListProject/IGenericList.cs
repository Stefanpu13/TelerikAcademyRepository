using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    // My generic list structure will have to implement this interface in order to 
    // be a "valid" generic list.
    public interface IGenericList<T>
    {
        T this[int index] { get; set; }

        void Add(T item);

        void RemoveAt(int index);

        void Insert(int index, T item);

        void Clear();

        T Find(T item);
    }

    
}
