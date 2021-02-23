using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{


    public class ExpenseDeleted : Expense
    {
        private int iDeletedBy;
        private DateTime dtmDateDeleted;
        private Boolean blnExpenseDeletedExists;



        public ExpenseDeleted(DataRow dr)
        {
            try
            {
                initialize();
                base.initialize();

                base.Load(dr);
                Load(dr);
                blnExpenseDeletedExists = true;
            }
            catch (Exception ex)
            {
                blnExpenseDeletedExists = false;
            }
        }


        public new void initialize()
        {
            base.initialize();

            iDeletedBy = 0;
            dtmDateDeleted = DateTime.MinValue;

            blnExpenseDeletedExists = false;
        }

        public new void Load(DataRow dr)
        {
            try
            {
                base.Load(dr);

                iDeletedBy = Convert.ToInt32(dr["DeletedBy"] == Convert.DBNull ? 0 : dr["DeletedBy"]);
                dtmDateDeleted = Convert.ToDateTime(dr["DateDeleted"] == Convert.DBNull ? DateTime.MinValue : dr["DateDeleted"]);
            }
            catch (Exception ex)
            {

            }
        }

        public new int DeletedBy
        {
            get { return iDeletedBy; }
            set { iDeletedBy = value; }
        }
        public DateTime DateDeleted
        {
            get { return dtmDateDeleted; }
            set { dtmDateDeleted = value; }
        }
        public Boolean ExpensesDeletedExists
        {
            get { return blnExpenseDeletedExists; }
            set { blnExpenseDeletedExists = value; }
        }
    }




    public class ExpensesDeleted : IEnumerable<ExpenseDeleted>
    {
        List<ExpenseDeleted> infoList = new List<ExpenseDeleted>();

        public ExpensesDeleted()
        {
            infoList = new List<ExpenseDeleted>();
        }


        public ExpensesDeleted(string StartDate, string EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            ExpenseDeleted objInfo;

            dt = objData.GetExpensesDeletedByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new ExpenseDeleted(dt.Rows[i]);
                    if (objInfo.ExpensesDeletedExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }


        public void Add(ExpenseDeleted Info)
        {
            infoList.Add(Info);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<ExpenseDeleted> IEnumerable<ExpenseDeleted>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }




}
