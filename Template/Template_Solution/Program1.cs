using System;

public  class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program1
{
    public static void Main1()
    {
        // Create an instance of the Person class
        Person person = new Person();

        // Set the properties using dot notation
        person.Name = "Alice";
        person.Age = 30;

        // Access the members using the dot notation
        string name = person.Name;
        int age = person.Age;

        // Display the information
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }
}
