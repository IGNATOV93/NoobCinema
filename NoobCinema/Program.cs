using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

#region class Viewer
public class Viewer
{
    public Viewer(int count, double price)
    {
        price_of_ticket = price;
        count_of_ticket = count;
        Discount = discount;
    }
    public int count_of_ticket { get; set; }
    public double price_of_ticket { get; set; }
    
    public double discount;
    public double Discount
    {
        get { return discount; }
        set { discount = price_of_ticket * count_of_ticket; }
    }
}
#endregion

#region class Regular
public class Regular : Viewer
{
    public int numberOFvisits { get; set; }

    public Regular(int numberOFvisits,int count, double price) : base(count, price)
    {
        discount = CalcOFtickets(numberOFvisits, price, count);
    }


    public virtual double CalcOFtickets(int wasCountTickets, double priceOFticket, int buyCountTicket)
    {
        double summa = 0;
        double price;
        int wastickets = wasCountTickets;
        while (wasCountTickets < wastickets + buyCountTicket)
        {
            int statsCount = (wasCountTickets + 1) / 10;
            if (statsCount > 20) { statsCount = 20; }

            double procent = (double)(100 - statsCount) / 100;
            price = priceOFticket * procent;
            summa += price;
            wasCountTickets++;
        }
        return summa;
    }
}
#endregion

#region class Student
public class Student : Regular
{
    public Student(int numberOFvisits,  int count,double price) : base(numberOFvisits, count, price)
    {
        discount = CalcOFtickets(numberOFvisits, price, count);
    }


    public override double CalcOFtickets(int wasCountTickets, double priceOFticket, int buyCountTicket)
    {
        double summa = 0;
        int wastickets = wasCountTickets;
        while (wasCountTickets < wastickets + buyCountTicket)
        {
            bool checkThirdVisit = (wasCountTickets + 1) % 3 != 0;
            if (!checkThirdVisit) summa += price_of_ticket / 2;
            else summa += priceOFticket;
            wasCountTickets++;
        }
        return summa;
    }
    
}
#endregion

#region class Pensioner
public class Pensioner : Regular
{
    public Pensioner(int numberOFvisits,  int count, double price) : base(numberOFvisits, count, price)
    {
        discount = CalcOFtickets(numberOFvisits, price, count);
    }


    public override double CalcOFtickets(int wasCountTickets, double priceOFticket, int buyCountTicket)
    {
        double summa = 0;
        int wastickets = wasCountTickets;
        while (wasCountTickets < wastickets + buyCountTicket)
        {
            int statsCount = (wasCountTickets + 1) % 5;
            if (statsCount == 1 || statsCount == 2 || statsCount == 3 || statsCount == 4) summa += price_of_ticket / 2;
            else summa += 0;
            wasCountTickets++;
        }
        return summa;
    }
}
#endregion

#region class CalculationOftickets
public abstract class CalculationOftickets
{
   public  static void StartsCalculetion()
    {
        while (true)
        {
            // Console.WriteLine("Введите вид посетителя,кол-во его посещений,цену билета,сколько билетов покупает");
            string input = Console.ReadLine();
            if (input == null) break;
            string[] inputArray = input.Split(" ");
                UserIdentification(inputArray);
           
        }

    }

    #region UserIdentification
    public static void UserIdentification(string[] inputArray)
    {
        string visitor = inputArray[0];
        int wasCount = int.Parse(inputArray[1]);
        int buyCount = int.Parse(inputArray[2]);
        int priceTicket = int.Parse(inputArray[3]);
        if (visitor == "viewer")
        {
            Viewer viewer = new Viewer(buyCount, priceTicket); Print(viewer);
        }
        if (visitor == "regular")
        {
            Regular regular = new Regular(wasCount, priceTicket, buyCount); Print(regular);
        }
        if (visitor == "student")
        {
            Student student = new Student(wasCount, priceTicket, buyCount); Print(student);
        }
        if (visitor == "pensioner")
        {
            Pensioner pensioner = new Pensioner(wasCount, priceTicket, buyCount);Print(pensioner);
        }
    }
    #endregion

    public static void Print(Viewer viewer)
    {
        double a = Math.Round(viewer.Discount, 2);
        Console.WriteLine(a);
    }

}


#endregion

public class MainClass
{
    public static void Main()
    {
        CalculationOftickets.StartsCalculetion();
    }
}

