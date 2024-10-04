namespace PracticeA;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
   
    static void Main(string[] args)
    {

        var people = new[] { new {Id = 1, Name = "John"}, new {Id = 2, Name = "Jane"}};
        var orders = new[] { new {Id = 1, Amount = 100}, new {Id = 3, Amount = 50}};

        var joined = people.Join(orders, p => p.Id, o => o.Id, (p,o) => new {p.Id, p.Name, o.Amount});

        foreach (var item in joined)
        {
            Console.WriteLine($"Name:{item.Name}, Amount:{item.Amount}");
        }
    }
}

