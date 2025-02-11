using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Virus : ICloneable
    {
        public string Name { get; private set; }
        public string Species { get; private set; }
        public double Weight { get; private set; }
        public int Age { get; private set; }
        public IReadOnlyList<Virus> Children => children;

        private readonly List<Virus> children;

        public Virus(string name, string species, double weight, int age)
        {
            ValidateParameters(name, species, weight, age);

            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
            children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            children.Add(child);
        }

        public object Clone()
        {
            var clone = new Virus(Name, Species, Weight, Age);
            foreach (var child in children)
            {
                clone.AddChild((Virus)child.Clone());
            }
            return clone;
        }

        public void PrintFamilyTree(string indent = "")
        {
            Console.WriteLine($"{indent}{this}");
            foreach (var child in Children)
            {
                child.PrintFamilyTree(indent + "    ");
            }
        }

        public override string ToString() =>
            $"Вірус: {Name}, Вид: {Species}, Вага: {Weight:F2}г, Вік: {Age} днів, Кількість дітей: {Children.Count}";

        private static void ValidateParameters(string name, string species, double weight, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я вірусу не може бути порожнім", nameof(name));

            if (string.IsNullOrWhiteSpace(species))
                throw new ArgumentException("Вид вірусу не може бути порожнім", nameof(species));

            if (weight <= 0)
                throw new ArgumentException("Вага повинна бути більше 0", nameof(weight));

            if (age < 0)
                throw new ArgumentException("Вік не може бути від'ємним", nameof(age));
        }
    }
}