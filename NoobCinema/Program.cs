using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


public  class Viewer
{

    public Viewer(double price, int count)
    {
        price_of_ticket= price;
        count_of_ticket= count;
        Discount = discount;
    }
    public double price_of_ticket { get; set; }
    public int count_of_ticket { get; set; }
    private double discount;
    public double Discount
    {
        get { return discount;}
        set
        {
            discount = price_of_ticket*count_of_ticket;
        }
    }
}

public class Regular : Viewer
{
    public Regular(double price, int count, double discount) : base(price, count)
    {
    }
}

public class Student : Viewer
{
    public Student(double price, int count, double discount) : base(price, count)
    {
    }
}

public class Pensioner : Viewer
{
    public Pensioner(double price, int count, double discount) : base(price, count)
    {
    }
}


public abstract class calculationOftickets
{
    public static void Spliting()
    {
        
            Console.WriteLine("Введите вид посетителя,кол-во его посещений,цену билета,сколько билетов покупает");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(" ");
            MakingOFvisitor(inputArray);
    }

    public static void MakingOFvisitor(string[] inputArray)
    {
        string visitor = inputArray[0];
        if (visitor == "viewer")
        {
            Viewer viewer = new Viewer(double.Parse(inputArray[2]), int.Parse(inputArray[3]));
           // Console.WriteLine(viewer.discount);
           Print(viewer);

        }
        //
        if (visitor == "regular")
        {
            //       Regular regular = new Regular();


        }

        if (visitor == "student")
        {
            //        Student student= new Student();
        }

        if (visitor == "pensioner")
        {
            //       Pensioner pensioner= new Pensioner();
        }
    }

    public static void Print(Viewer viewer)
    {
        Console.WriteLine(viewer.Discount);
    }

}


public class MainClass
{
    



    public static void Main()
    {
        while (true)
        {
            calculationOftickets.Spliting();
        }
    }
}

