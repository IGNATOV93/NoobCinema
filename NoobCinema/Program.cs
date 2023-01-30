using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public double discount;
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
  public int numberOFvisits { get; set; }

    public Regular(int numberOFvisits, double price, int count) : base(price, count)
    {
        discount = CalcOFtickets(numberOFvisits,price,count);
    }

    public  virtual double CalcOFtickets(int wasCountTickets,double buyCountTicket, int priceOFticket)
    {
        
        double summa = 0; 
        double price = 0;
        int  wastickets=wasCountTickets;
        while (wasCountTickets < wastickets+buyCountTicket)
        {
            int statsCount = (wasCountTickets+1)/ 10;
            if (statsCount > 20) { statsCount = 20; }

            double procent = (double)(100-statsCount) / 100;
            price = priceOFticket * procent;
            summa = summa + price;
            wasCountTickets++;
        }

        return summa;
    }
}

public class Student : Regular
{
    public Student(int numberOFvisits, int count,double price) : base(numberOFvisits, price, count)
    {
        discount = CalcOFtickets(numberOFvisits, price, count);
    }

    public override double CalcOFtickets(int wasCountTickets, double priceOFticket, int buyCountTicket)
    {
        double summa = 0;
        int wastickets = wasCountTickets;
        while (wasCountTickets < wastickets + buyCountTicket)
        {
            int statsCount = (wasCountTickets + 1) % 3;

            if (statsCount == 0 || statsCount == 1 || statsCount == 2)
            {
                summa+= price_of_ticket /2;
            }
            else
            {
                summa += priceOFticket;
            }

            wasCountTickets++;
        }

        return summa;


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
    {
        
            Console.WriteLine("Введите вид посетителя,кол-во его посещений,цену билета,сколько билетов покупает");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(" ");
            MakingOFvisitor(inputArray);
    }

    #region void MakingOFvisitor
    public static void MakingOFvisitor(string[] inputArray)
    {
        string visitor = inputArray[0];
        if (visitor == "viewer")
        {
            Viewer viewer = new Viewer(double.Parse(inputArray[2]), int.Parse(inputArray[3]));
            Print(viewer);
        }

        if (visitor == "regular")
        {
            Regular regular = new Regular(int.Parse(inputArray[1]), int.Parse(inputArray[3]), int.Parse(inputArray[2]));
            Print(regular);

        }

        if (visitor == "student")
        {
            Student student = new Student(int.Parse(inputArray[1]), int.Parse(inputArray[3]), int.Parse(inputArray[2]));
            Print(student);
        }

        if (visitor == "pensioner")
        {

        }
    } 
    #endregion

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

