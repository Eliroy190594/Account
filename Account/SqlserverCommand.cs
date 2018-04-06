using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Account
{
    class SqlserverCommand
    {
        public void QueryCommand(DateTime pDate, string pType, int pCost)
        {
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=Accountant;Trusted_Connection=True;"))
            {
                cn.Query("insert into Account(Date_Time,Type,Cost,Detail,Remark) values(@tDate,@tType,@tCost,null,null)",
                    new
                    {
                        tDate = pDate,
                        tType = pType,
                        tCost = pCost
                    });
            }
        }

        public void QueryCommand(DateTime pDate, string pType, int pCost, int pDetail, string pRemark)
        {
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=Accountant;Trusted_Connection=True;"))
            {
                cn.Query("insert into Account(Date_Time,Type,Cost,Detail,Remark) values(@tDate,@tType,@tCost,@tDetail,@tRemark)",
                    new
                    {
                        tDate = pDate,
                        tType = pType,
                        tCost = pCost,
                        tDetail = pDetail,
                        tRemark = pRemark
                    });
            }
        }

        public void QueryCommand(DateTime pDate, string pType, int pCost, int pDetail)
        {
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=Accountant;Trusted_Connection=True;"))
            {
                cn.Query("insert into Account(Date_Time,Type,Cost,Detail,Remark) values(@tDate,@tType,@tCost,@tDetail,null)",
                    new
                    {
                        tDate = pDate,
                        tType = pType,
                        tCost = pCost,
                        tDetail = pDetail
                    });
            }
        }

        public SqlserverCommand(string con)
        {
            connectionStr = con;
        }

        public SqlserverCommand()
        { }

        private string connectionStr { get; set; }

        public DataType SelectCommand(int pAccount_PK)
        {
            DataType data = new DataType();
            
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=Accountant;Trusted_Connection=True;"))
            {

                //data.dateTypeDate = (DateTime)cn.ExecuteScalar("select Date_Time from Account where Account_PK=@tAccount_PK",
                //    new// 從sql 撈資料轉換為字串問題
                //    {
                //        tAccount_PK = pAccount_PK
                //    });
                //data.dateTypeCost=(int)cn.ExecuteScalar("select Cost from Account where Account_PK=@tAccount_PK",
                //    new// 從sql 撈資料轉換為字串問題
                //    {
                //        tAccount_PK = pAccount_PK
                //    });

            }

            return data;
        }

    }
}
