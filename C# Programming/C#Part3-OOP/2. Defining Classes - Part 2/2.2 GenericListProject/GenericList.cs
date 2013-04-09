using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    // NOTE: This list implementation is taken from microsoft list implementation
    public class GenericList<T> : IGenericList<T> where T: IComparable
    {
        //Properties
        T[] itemsArray;
        
        /// <summary>
        /// Used to count the number of used cells in the "items" array.
        /// </summary>
        private int usedCells;
        private readonly static T[] emptyArray = new T[0];

        public GenericList() 
        {
            this.itemsArray = GenericList<T>.emptyArray;
            usedCells = 0;
        }
        
        public GenericList(int size) 
        {
            if (size < 0)
            {
                string message = "Generic list size can`t be a negative number";
                throw new ArgumentException(message);
            }

            if (size != 0)
            {
                this.itemsArray = new T[size];
                usedCells = 0;
                return;
            }

            else
            {
                this.itemsArray = GenericList<T>.emptyArray;
                return;
            }
        }


        public T[] ItemsArray
        {
            get
            {
                return this.itemsArray;
            }
            set
            {
                this.itemsArray = value;
            }
        }

        public int UsedCells
        {
            get
            {
                return this.usedCells;
            }
            set
            {
                this.usedCells = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.usedCells || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.itemsArray[index];
            }

            set
            {
                if (index >= this.usedCells || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.itemsArray[index] = value;
                }

                //TODO: See The code for list by Microsoft. Should I Create new object as below.

                //List<T> list<T>s = this;
                //list<T>s._version = list<T>s._version + 1;

            }
        }


        public void Add(T item)
        {
            // Uses "Insert" method to add an item in the last position
            int insertIndex = this.usedCells;
            this.Insert(insertIndex, item);
        }

        public void Clear()
        {
            this.itemsArray = GenericList<T>.emptyArray;
            this.usedCells = 0;
        }

        public T Find(T item)
        {
            int usedCellsCount = this.usedCells;
            for (int i = 0; i < usedCellsCount; i++)
            {
                if (item .Equals( this[i]))
                {
                    return item;
                }
            }

            T valueNotFound = default(T);
            return valueNotFound;
        }
        
        
        /// <summary>
        /// Increases the actual length of the internal array, holding the 
        /// elements of the "GenericList" object.
        /// </summary>
        private void IncreaseSize()
        {
            int initialLength = this.itemsArray.Length;

            // If no items are still added.
            if (initialLength ==0)
            {
                this.itemsArray = new T[1];
                return;
            }

            int newSize = initialLength * 2;
            T[] newItemsArray = new T[newSize];

            Array.Copy(this.itemsArray, newItemsArray, initialLength);
            this.itemsArray = newItemsArray;
        }

        public void Insert(int index, T item)
        {
            if (index>this.usedCells || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // If the array is full
            if (this.usedCells == (int)this.itemsArray.Length)
            {
                this.IncreaseSize();
            }

            int copiedRangeLength = this.usedCells - index;
            if (copiedRangeLength!=0)
            {
                Array.Copy(this.itemsArray, index, this.itemsArray, index + 1, copiedRangeLength);
            }            

            this.itemsArray[index] = item;
            // One more cell is used in the "items" array
            this.usedCells++;
        }

        public void RemoveAt(int index)
        {
            if (index>=this.usedCells || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int copiedRangeLength = this.usedCells - index;
            Array.Copy(this.itemsArray, index + 1, this.itemsArray, index, copiedRangeLength);
            this.usedCells--;
        }

        public override string ToString() 
        {
            StringBuilder genericListStringBuilder = new StringBuilder();
           
            genericListStringBuilder.Append("{");
            // Only the used cells are taken
            int usedCellsCount = this.usedCells;
            for (int i = 0; i < usedCellsCount - 1; i++)
            {
                genericListStringBuilder.Append(this[i]+", ");
            }

            if (usedCellsCount>0)
            {
                genericListStringBuilder.Append(this[usedCellsCount - 1]);
            }
            genericListStringBuilder.Append("}");

            return genericListStringBuilder.ToString();
        }
    }
}
