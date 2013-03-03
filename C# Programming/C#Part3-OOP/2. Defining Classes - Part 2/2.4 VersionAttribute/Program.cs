using System;
using System.Linq;
using System.Reflection;


namespace VersionAttribute
{
    /*Create a [Version] attribute that can be applied to structures, classes,
     * interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
     * Apply the version attribute to a sample class and display its version at runtime.
    */

    class Program
    {
        static void Main(string[] args)
        {
            SampleClass test = new SampleClass();
            Type sampleClassType = test.GetType();

            Attribute attributeInfo = sampleClassType.GetCustomAttribute(typeof(VersionAttribute));
            Console.WriteLine(attributeInfo);
        }
    }
}
