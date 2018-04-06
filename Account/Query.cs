using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections;

namespace Account
{
    interface Account
    {
        int cost { get; set; }
        DateTime date { get; }
    }

    class Query
    {
        public virtual void QueryIt() { }
        public int TypePK = 0;

        SqlserverCommand sqlserverCommand = new SqlserverCommand();

        public void QueryIntoDatabase(DateTime pDate, string pType, int pCost)
        {
            sqlserverCommand.QueryCommand(pDate, pType, pCost);
            Console.WriteLine("Success to save !!!\n");
        }
        public void QueryIntoDatabase(DateTime pDate, string pType, int pCost, int pDetail, string pRemark)
        {
            sqlserverCommand.QueryCommand(pDate, pType, pCost, pDetail, pRemark);
            Console.WriteLine("Success to save !!!\n");
        }
        public void QueryIntoDatabase(DateTime pDate,string pType,int pCost,int pDetail)
        {
            sqlserverCommand.QueryCommand(pDate, pType, pCost, pDetail);
            Console.WriteLine("Success to save !!!\n");
        }

        protected string AskForRemark()
        {
            Console.Write("Do you have any remark (press enter if not): ");
            string askRemark = Console.ReadLine();
            return askRemark;
        }

        public int ShowDetailBoard(string pType)
        {
            for (int i = 0; i < 55; i++)
                Console.Write("=");
            Console.WriteLine();
            Console.WriteLine("=== Choice :                                        ===\n");

            switch (pType)
            {
                case "necessities":
                    Console.WriteLine("=== 1. food          2. drinks         3. snacks    ===\n");
                    Console.WriteLine("=== 4. dishes        5. tools          6. toiletries===");
                    break;
                case "living":
                    Console.WriteLine("=== 1. water         2. electricity    3. gas       ===\n");
                    Console.WriteLine("=== 4. internet      5. rental         6. public    ===");
                    break;
                case "transportation":
                    Console.WriteLine("=== 1. gasoline      2. motorcycle     3. masses    ===");
                    break;
                case "clothes":
                    Console.WriteLine("=== 1. clothes       2. pants          3. shoes     ===\n");
                    Console.WriteLine("=== 4. underwear                                    ===");
                    break;
            }

            for (int i = 0; i < 55; i++)
                Console.Write("=");
            Console.WriteLine("\n");
            Console.Write("Please select the number : ");
            int choosedNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch(pType)
            {
                case "necessities":
                    if (choosedNumber < 6)
                        choosedNumber += 5;
                    else
                        choosedNumber = 24;
                    break;
                case "living":
                    choosedNumber += 10;
                    break;
                case "transportation":
                    choosedNumber += 16;
                    break;
                case "clothes":
                    choosedNumber += 19;
                    break;
            }

            return choosedNumber;
        }
    }

    class ShowData : Query
    {
        public override void QueryIt()
        {
            Console.WriteLine("ShowData");
        }
    }

    class DataDate:Query
    {
        public DataDate()//建構子預設日期為當日
        {
            _nowYear = DateTime.Now.Year;
            _nowMonth = DateTime.Now.Month;
            _nowDay = DateTime.Now.Day;
        }

        private static int _nowYear;
        private static int _nowMonth;
        private static int _nowDay;

        public override void QueryIt()//透過QueryIt可改變日期
        {
            Console.WriteLine("DataDate");
            Console.WriteLine("What Day is it : ");
            Console.Write("Please enter year : ");
            _nowYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter month : ");
            _nowMonth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter day : ");
            _nowDay = Convert.ToInt32(Console.ReadLine());
        }

        //public DateTime NowDate(){}
        private int nowYear
        {
            get
            {
                return _nowYear;
            }
            set
            {
                _nowYear = value;
            }
        }

        private int nowMonth
        {
            get { return _nowMonth; }
            set
            {
                if (value > 0 && value <= 12)
                {
                    _nowMonth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Month", value, "Month must be 1-12");
                }
            }
        }

        private int nowDay//設定日期條件
        {
            get { return nowDay; }
            set
            {
                int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                if (value > 0 && value <= daysPerMonth[nowMonth])
                {
                    _nowDay = value;
                }
                else
                {
                    if (nowMonth == 2 && value == 29 && (nowYear % 400 == 0 || (nowYear % 4 == 0 && nowYear % 100 != 0)))
                    {
                        _nowDay = value;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Day", value, "Day out of range for current month/year");
                    }
                }

            }
        }

        public static DateTime nowDate
        {
            get
            {
                DateTime d = new DateTime(_nowYear,_nowMonth,_nowDay);
                return d.Date;
            }
        }
    }

    class MainProgram
    {
        private string queryString = "";

        public void DoQuery()
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                ShowData show = new ShowData();
                Breakfast breakfast = new Breakfast();
                Lunch lunch = new Lunch();
                Dinner dinner = new Dinner();
                Drinks drinks = new Drinks();
                Snack snack = new Snack();
                NightMeal nightMeal = new NightMeal();
                DataDate dataDate = new DataDate();
                Others others = new Others();
                Necessities necessities = new Necessities();
                Transportation transportation = new Transportation();
                Clothes clothes = new Clothes();
                Living living = new Living();
                Books books = new Books();

                hashTable.Add("SHOW", show);
                hashTable.Add("BREAKFAST", breakfast);
                hashTable.Add("LUNCH", lunch);
                hashTable.Add("DINNER", dinner);
                hashTable.Add("DRINKS", drinks);
                hashTable.Add("SNACK", snack);
                hashTable.Add("NIGHTMEAL", nightMeal);
                hashTable.Add("DATADATE", dataDate);
                hashTable.Add("OTHERS", others);
                hashTable.Add("NECESSITIES", necessities);
                hashTable.Add("TRANSPORTATION", transportation);
                hashTable.Add("CLOTHES", clothes);
                hashTable.Add("BOOKS", books);
                hashTable.Add("LIVING", living);

                Query q = new Query();
                SqlserverCommand ssc = new SqlserverCommand();
                ssc.SelectCommand(1);

                ShowAskBoard();
                queryString = AskQuestion();
                while (queryString.ToUpper() != "Q")
                {
                    //NullReferenceException
                    q = (Query)hashTable[queryString.ToUpper()];
                    //if (q.TypePK > 6 && q.TypePK < 11)
                    //{
                    //    ShowDetailBoard(q.ToString());
                    //}
                    q.QueryIt();
                    ShowAskBoard();
                    AskQuestion();
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to leave .");
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Wrong syntax ...");
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Wrong date ...");
            }
            catch(Exception e)
            {
                Console.WriteLine("Something wrong ...");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (queryString.ToUpper()!="Q")
                {
                    DoQuery();
                }
            }

        }

        private string AskQuestion()
        {
            Console.Write("Please Query : ");
            this.queryString = Console.ReadLine();

            return queryString;
        }

        private void ShowAskBoard()
        {
            for (int i = 0; i < 55; i++)
                Console.Write("=");
            Console.WriteLine();
            Console.WriteLine("=== Choice :                                        ===\n");
            Console.WriteLine("=== breakfast        lunch                dinner    ===\n");
            Console.WriteLine("=== nightmeal        drinks               snack     ===\n");
            Console.WriteLine("=== others           necessities          living    ===\n");
            Console.WriteLine("=== clothes          transportation       books     ===\n");
            Console.Write("=== Enter \"Q\" or \"q\" to leave                       ===\n");
            for (int i = 0; i < 55; i++)
                Console.Write("=");
            Console.WriteLine("\n");
        }

        
    }

    class DataType
    {
        public DateTime dateTypeDate { get; set; }
        public string dateTypeType { get; set; }
        public int dateTypeCost { get; set; }
        public int dateTypeDetail { get; set; }
        public string dateTypeRemark { get; set; }
    }
}
