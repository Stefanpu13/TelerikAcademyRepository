using System;
using System.Collections.Generic;
using System.Linq;


namespace _3.AnimalsHierarchy
{
    class AnimalsTest
    {
        static void Main(string[] args)
        {
            Tomcat tomi = new Tomcat(5,"Tommi");
            Tomcat timi = new Tomcat(8, "Timmi");
            Tomcat tami = new Tomcat(7, "Tammi");

            Kitten kitty = new Kitten(3, "Sara");
            Kitten kotty = new Kitten(4, "Tara");
            Kitten motty = new Kitten(8, "Mara");
            Kitten katty = new Kitten(9, "Sisa");

            Dog sharo = new Dog(9, "Gogo", Sex.Male);
            Dog baro = new Dog(2, "Soko", Sex.Male);
            Dog mima = new Dog(9, "Pepa", Sex.Female);

            Frog prince = new Frog(23, "Charming", Sex.Female);
            Frog princess = new Frog(20, "Charming", Sex.Female);
            Frog king = new Frog(47, "Elderly", Sex.Male);

            // Add a few animals. Using a single list instead of multiple lists.
            List<Animal> animals = new List<Animal>() { tomi, kitty, sharo, prince };

            foreach (var creature in animals)
            {
                Console.Write(creature.GetType().Name + " produce sound: ");
                creature.ProduceSound();
                Console.WriteLine(creature.AnimalType);
            }

            foreach (var creature in animals)
            {
                Console.WriteLine();

                Console.WriteLine(creature.GetType().Name + "move 3 meters: ");
                creature.Move(3);                
            }

            Console.WriteLine("\n-------------\n");
            Console.WriteLine("Tomi wants to go hunting: ");
            tomi.Hunt(kitty);

            string unhuntable = "Can`nt be hunted";
            tomi.Hunt(unhuntable);

            Console.WriteLine("\n-------------\n");
            Console.WriteLine("Calculating average age using LINQ:");


            // Add the rest of the animals
            animals.Add(timi);
            animals.Add(tami);
            animals.Add(kotty);
            animals.Add(motty);
            animals.Add(katty);
            animals.Add(baro);
            animals.Add(mima);
            animals.Add(princess);
            animals.Add(king);

            // The query uses the readonly property "AnimalType" to group the animals by their
            // class name(type).
            var animalsBreeds = from animal in animals
                                group animal by animal.AnimalType;
            

            foreach (var animalBreed in animalsBreeds)
            {
                // Get the animal type of the group. Each group has ta least one animal,
                // otherwise it will not be returned from the query.
                Console.WriteLine("Animal breed: " + animalBreed.ElementAt(0).AnimalType);
                // Select the ages in the current group, convert them to list and calculate their average.
                Console.WriteLine("Average age: {0}", animalBreed.Select(x => x.Age).ToList().Average());
            }



            //A better decision which I saw (not using a property)
            //Creates groups of anonymous type which holds two properties - the name of the species
            //and the average age in the group
            var speciesByAverageAge =
                from animal in animals
                group animal by animal.GetType() into a
                select new { Species = a.Key.Name, AverageAge = a.Average(animal => animal.Age) };

            foreach (var item in speciesByAverageAge)
            {
                Console.WriteLine("Species: " + item.Species);
                Console.WriteLine("Average age: " + item.AverageAge);
            }


            Console.WriteLine("\n-------------\n");
            Console.WriteLine("Calculating average age using LINQ:");


        }
    }
}
