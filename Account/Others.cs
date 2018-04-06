using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Account
{
    class Others:Query,Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Others");
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
            return "others";
        }

        public Others()
        {
            TypePK = 12;
        }
    }

    class Necessities:Query,Account
    {
        public override void QueryIt()
        {
            Console.WriteLine();
            int detailNumber = base.ShowDetailBoard(this.ToString());

            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            string askRemark = AskForRemark();

            try
            {
                if (!(askRemark == ""))
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber, askRemark);
                else
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber);

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
            return "necessities";
        }

        public Necessities()
        {
            TypePK = 7;
        }
    }

    class Living:Query,Account
    {
        public override void QueryIt()
        {
            Console.WriteLine();
            int detailNumber = base.ShowDetailBoard(this.ToString());

            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            string askRemark = AskForRemark();

            try
            {
                if (!(askRemark == ""))
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber, askRemark);
                else
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber);

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
            return "living";
        }

        public Living()
        {
            TypePK = 8;
        }
    }

    class Clothes:Query,Account
    {
        public override void QueryIt()
        {
            Console.WriteLine();
            int detailNumber = base.ShowDetailBoard(this.ToString());

            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            string askRemark = AskForRemark();

            try
            {
                if (!(askRemark == ""))
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber, askRemark);
                else
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber);

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
            return "clothes";
        }

        public Clothes()
        {
            TypePK = 10;
        }
    }

    class Transportation : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine();
            int detailNumber = base.ShowDetailBoard(this.ToString());

            Console.Write("How much you paid : ");
            cost = Convert.ToInt32(Console.ReadLine());

            string askRemark = AskForRemark();

            try
            {
                if (!(askRemark == ""))
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber, askRemark);
                else
                    base.QueryIntoDatabase(date, this.ToString(), cost, detailNumber);

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
            return "transportation";
        }

        public Transportation()
        {
            TypePK = 9;
        }
    }

    class Books : Query, Account
    {
        public override void QueryIt()
        {
            Console.WriteLine("Books");
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
            return "books";
        }

        public Books()
        {
            TypePK = 11;
        }
    }
}
