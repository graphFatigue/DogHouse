
using DogHouse.DAL;
using DogHouse.Domain.Entity;
using Microsoft.EntityFrameworkCore.Design;

//int success = 0;    

//while (success != 1)
//{
//    using (var db = new ApplicationDbContext())
//    {
//        Console.WriteLine("Enter a name for a new dog <33");
//        var name = Console.ReadLine();

//        Console.WriteLine("What color is that dog?");
//        var color = Console.ReadLine();

//        Console.WriteLine("How long its tail?");
//        var tailLength = Console.ReadLine();

//        Console.WriteLine("How much does the dog weigh?");
//        var weight = Console.ReadLine();

//        try
//        {
//            var dog = new Dog()
//            {
//                Name = name,
//                Color = color,
//                TailLength = Int32.Parse(tailLength),
//                Weight = Int32.Parse(weight)
//            };

//            db.Dogs.Add(dog);
//            db.SaveChanges();

//            var query = from d in db.Dogs
//                        orderby d.Name
//                        select d;

//            foreach (var d in query)
//            {
//                Console.WriteLine(d.Name);  
//            }

//            success = 1; //break;
//        }
//        catch (Exception ex)
//        {

//            Console.WriteLine(ex.Message);
//        }

//    }
//}

//using (var db = new ApplicationDbContext())
//{

//}

Console.WriteLine("fine!!");

