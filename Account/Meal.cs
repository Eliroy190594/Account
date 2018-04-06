using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class Breakfast : Query, Account
    {
        public override void QueryIt()
        {
            //Console.WriteLine("Breakfast");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date,this.ToString(),cost);
            }
            catch(Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "breakfast";
        }

        public Breakfast()
        {
            TypePK = 1;
        }
    }

    class Lunch : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Lunch");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date, this.ToString(), cost);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "lunch";
        }

        public Lunch()
        {
            TypePK = 2;
        }
    }

    class Dinner : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Dinner");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date, this.ToString(), cost);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "dinner";
        }

        public Dinner()
        {
            TypePK = 3;
        }
    }

    class NightMeal : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("NightMeal");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date, this.ToString(), cost);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "nightmeal";
        }

        public NightMeal()
        {
            TypePK = 4;
        }
    }

    class Drinks : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Drinks");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date, this.ToString(), cost);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "drinks";
        }

        public Drinks()
        {
            TypePK = 5;
        }
    }

    class Snack : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Snack");
            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            try
            {
                base.QueryIntoDatabase(date, this.ToString(), cost);
            }
            catch (Exception)
            {
                Console.WriteLine("Fail to saving data");
            }
        }

        public int cost { get; set; }
        public DateTime date
        {
            get
            {
                return DataDate.nowDate;
            }
        }

        public override string ToString()
        {
            return "snack";
        }

        public Snack()
        {
            TypePK = 6;
        }
    }
}
