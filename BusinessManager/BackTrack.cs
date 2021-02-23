using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class BackTrack : Transaction
    {
       

        

        public BackTrack()
        {
            initialize();
        }


        public BackTrack(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                //blnBackTrackExists = true;
            }
            catch (Exception ex)
            {
                //blnBackTrackExists = false;
            }
        }

       
        public BackTrack(int ID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj._GetBackTrackByID(ID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                   // blnTransactionsExist = true;
                }
                else
                {
                    //blnTransactionsExist = false;
                }
            }
            catch (Exception ex)
            {
                //blnTransactionsExist = false;
            }
        }







        public override Boolean Update()
        {
            Data obj = new Data();
            int iRet = 0;

            try
            {
                iRet = obj.UpdateBackTrack(this);

                if (iRet == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //General.WriteToErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.UnderlyingSystemType.ToString, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message)

                return false;
            }
            finally
            {

            }

        }


        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.()

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }




    public class BackTracks : IEnumerable<BackTrack>
    {
        List<BackTrack> infoList = new List<BackTrack>();
        public BackTracks()
        {
            infoList = new List<BackTrack>();
        }



        public BackTracks(int CustomerID)
        {
            Data objData = new Data();
            DataTable dt;
            BackTrack objInfo;

            //infoList = new ArrayList();

            dt = objData._GetTransactionsBacktrackByCustomerID(CustomerID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new BackTrack(dt.Rows[i]);
                    //if (objInfo.BackTrackExists)
                    //{
                        infoList.Add(objInfo);
                    //}
                }
            }

        }




        public void Add(BackTrack Info)
        {
            infoList.Add(Info);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<BackTrack> IEnumerable<BackTrack>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }




}
