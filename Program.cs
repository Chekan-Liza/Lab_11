using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_11 {
  class Program {
    static void Main( string[] args ) {
      string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

      Console.Write( "Введите количество букв в названии месяца: " );
      int n = Convert.ToInt32( Console.ReadLine() );
 
      var request_1 = from m in year
                      where m.Length == n
                      select m;

      foreach ( var item in request_1 )
      Console.WriteLine( item );

      IEnumerable<string> summer = year.Skip( 5 ).Take( 3 );

      Console.WriteLine( "\nЛетние месяцы:" );
      foreach ( var item in summer )
      Console.WriteLine( item );

      IEnumerable<string> winter = year.Skip( 11 ).Concat(year.Take(2));

      Console.WriteLine( "\nЗимние месяцы:" );
      foreach ( var item in winter )
      Console.WriteLine( item );

      Console.WriteLine( "\nМесяцы в алфавитном порядке:" );

      var abc = from a in year
                orderby a
                select a;

      foreach ( var item in abc )
      Console.WriteLine( item );

      Console.WriteLine( "\nМесяцы содержащие букву «u» и длиной имени не менее 4-х:" );

      var sort = from s in year
                 where s.Contains( 'u' ) == true
                 where s.Length > 4
                 select s;

      foreach ( var item in sort )
      Console.WriteLine( item );

      List<Flight> dates = new List<Flight>();

      dates.Add(new Flight("Minsk", "Wednesday", 11, 20));
      dates.Add(new Flight("Riga", "Monday", 13, 50));
      dates.Add(new Flight("Madrid", "Wednesday", 21, 35));
      dates.Add(new Flight("Minsk", "Tuesday", 6, 45));
      dates.Add(new Flight("Berlin", "Friday", 9, 10));
      dates.Add(new Flight("Rome", "Monday", 19, 30));

      var dates_1 = from t_1 in dates
                    where t_1.town == "Minsk"
                    select t_1;

      Console.WriteLine("\nСписок рейсов для города Минск:");
      foreach (var item in dates_1)
         { item.InfoOfFlight(); }

      int l = 0;
      var dates_2 = from t_2 in dates
                    where t_2.d_week == "Monday"
                    select t_2;
      foreach (var item in dates_2)
         { l = l + 1; }
      Console.WriteLine("\nКоличесвто рейсов в понедельник: "+ l);

      var minTime = from min in dates
                    where min.d_week == "Monday"
                    orderby min.hour descending, min.minut
                    select min;

      Console.WriteLine("\nСамый ранний рейс в понедельник: ");
      minTime.Last().InfoOfFlight();

      var maxTime = from max in dates
                    where max.d_week =="Friday" || max.d_week == "Wednesday"
                    orderby max.hour descending, max.minut
                    select max;

      Console.WriteLine("\nСамый поздний рейс в среду или пятницу: ");
      maxTime.First().InfoOfFlight();

      var sortTime = from st in dates
                     orderby st.hour, st.minut
                     select st;
      Console.WriteLine("\nСписок рейсов по времени: ");
      foreach (var item in sortTime)
            { item.InfoOfFlight(); }
      
      List<int> list1 = new List<int>();
      list1.AddRange( new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } );

      List<int> list2 = new List<int>();
      list2.AddRange( new int[] { 2, 4, 6, 8, 10 } );

      var selectedList = from t1 in list1
                         join t2 in list2 on t1 equals t2
                         orderby t1
                         select t1;
      Console.WriteLine();
      foreach ( var s in selectedList ) {
      Console.Write( s + " " );
      }
      Console.WriteLine();
    }
  }
class Flight
    {   private string TownValue;
        private string DayOfWeekValue;
        private int HourValue;
        private int MinValue;
public void InfoOfFlight()
    {   Console.WriteLine($"\t{this.town}-{this.d_week}-{this.hour}:{this.minut}");}
        public string town
        {
            get
            { return TownValue; }
            set
            { TownValue = value; }
        }

        public string d_week
        {
            get
            { return DayOfWeekValue; }
            set
            { DayOfWeekValue = value; }
        }

        public int hour
        {
            get
            { return HourValue;}
            set
            { HourValue = value;}
        }
     public int minut
        {
            get
            { return MinValue;}
            set
            { MinValue = value; }
        }
     public Flight(string t, string d, int h, int m)
        {   town = t;
            d_week = d;
            hour = h;
            minut = m;
        }
    }
}