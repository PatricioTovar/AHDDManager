using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class Data
    {
        private string ConnString = "";

        public string Connectionstring { get; set; }

        public Data()
        {
            try
            { ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            catch
            { }
        }

        public DataTable LoginAssociate(string UserName, string Password)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("LoginAssociate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@UserName", UserName));
                selectCMD.Parameters.Add(new SqlParameter("@Password", Password));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.LoginAssociate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        //public void CheckClockIns(int AssociateID, DateTime CheckDate)
        //{
        //    SqlConnection Conn = new SqlConnection(this.ConnString);
        //    try
        //    {
        //        SqlCommand selectCMD = new SqlCommand("CheckClockIns", Conn);

        //        selectCMD.CommandTimeout = 30;

        //        selectCMD.CommandType = CommandType.StoredProcedure;

        //        selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));
        //        selectCMD.Parameters.Add(new SqlParameter("@CheckDate", CheckDate));

        //        Conn.Open();

        //        selectCMD.ExecuteNonQuery();

        //        Conn.Close();
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //    finally
        //    {
        //        if (Conn.State != ConnectionState.Closed)
        //        {
        //            Conn.Close();
        //        }
        //    }
        //}


        public DataTable GetAssociateByID(int AssociateID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociateByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociateByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetAssociatesByBusinessID(int BusinessID, bool? Active)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociatesByBusinessID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@Active", Active));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociatesByBusinessID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetAsociateClockInHistoryByID(int AssociateClockInHistoryID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAsociateClockInHistoryByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@AssociateClockInHistoryID", AssociateClockInHistoryID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAsociateClockInHistoryByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetAssociateClockInsByDateRange(string StartDate, string EndDate, int AssociateID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociateClockInsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociateClockInsByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetAssociateClockInsAllByDateRange(string StartDate, string EndDate, int AssociateID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociateClockInsAllByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociateClockInsAllByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetAssociatesAllClockInsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociatesAllClockInsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociatesAllClockInsByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }




        public DataTable GetColorsAvailable()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetColorsAvailable", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetColorsAvailable error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }




        public DataTable GetBusinessByID(int BusinessID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetBusinessByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", BusinessID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetBusinessByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetCustomerByID(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable SearchCustomers(string SearchCriteria)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("SearchCustomers", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@SearchCriteria", SearchCriteria));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.SearchCustomers error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetCustomerByTransactionID(int TransactionID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerByTransactionID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerByTransactionID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetCustomerInfoByPaymentID(int PaymentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerInfoByPaymentID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", PaymentID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerInfoByPaymentID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetTransactionByPaymentID(int PaymentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionByPaymentID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", PaymentID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionByPaymentID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransactionDetailsByPaymentID(int PaymentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionDetailsByPaymentID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", PaymentID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionDetailsByPaymentID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable SearchForms(string SearchCriteria)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("SearchForms", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@SearchCriteria", SearchCriteria));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.SearchForms error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        //*****************************************************************************************************************************
        //**************** MANHIEM STUFF ************************************************
        public DataTable SearchManhiemPresale(ManhiemPreSale objManhiemPreSale)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_SearchPreSale", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PreSaleDate", objManhiemPreSale.PreSaleDate == DateTime.MinValue ? (object)System.DBNull.Value : objManhiemPreSale.PreSaleDate));
                selectCMD.Parameters.Add(new SqlParameter("@Location", (objManhiemPreSale.Location == string.Empty | objManhiemPreSale.Location == null) ? (object)System.DBNull.Value : objManhiemPreSale.Location));
                selectCMD.Parameters.Add(new SqlParameter("@Lane", (objManhiemPreSale.Lane == 0) ? (object)System.DBNull.Value : objManhiemPreSale.Lane));
                selectCMD.Parameters.Add(new SqlParameter("@Run", (objManhiemPreSale.Run == 0) ? (object)System.DBNull.Value : objManhiemPreSale.Run));
                selectCMD.Parameters.Add(new SqlParameter("@startyear", (objManhiemPreSale.YearSearchStart == 0) ? (object)System.DBNull.Value : objManhiemPreSale.YearSearchStart));
                selectCMD.Parameters.Add(new SqlParameter("@endyear", (objManhiemPreSale.YearSearchEnd == 0) ? (object)System.DBNull.Value : objManhiemPreSale.YearSearchEnd));
                selectCMD.Parameters.Add(new SqlParameter("@Make", (objManhiemPreSale.Make == string.Empty | objManhiemPreSale.Make == null) ? (object)System.DBNull.Value : objManhiemPreSale.Make));
                selectCMD.Parameters.Add(new SqlParameter("@Model", (objManhiemPreSale.Model == string.Empty | objManhiemPreSale.Model == null) ? (object)System.DBNull.Value : objManhiemPreSale.Model));
                selectCMD.Parameters.Add(new SqlParameter("@odometer", (objManhiemPreSale.Odometer == 0) ? (object)System.DBNull.Value : objManhiemPreSale.Odometer));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.SearchForms error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable SearchManhiemPostsale(ManhiemPostSale objManhiemPostSale)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_SearchPostSale", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PostSaleDate", objManhiemPostSale.PostSaleDate == DateTime.MinValue ? (object)System.DBNull.Value : objManhiemPostSale.PostSaleDate));
                selectCMD.Parameters.Add(new SqlParameter("@Location", (objManhiemPostSale.Location == string.Empty | objManhiemPostSale.Location == null) ? (object)System.DBNull.Value : objManhiemPostSale.Location));
                selectCMD.Parameters.Add(new SqlParameter("@startyear", (objManhiemPostSale.YearSearchStart == 0) ? (object)System.DBNull.Value : objManhiemPostSale.YearSearchStart));
                selectCMD.Parameters.Add(new SqlParameter("@endyear", (objManhiemPostSale.YearSearchEnd == 0) ? (object)System.DBNull.Value : objManhiemPostSale.YearSearchEnd));
                selectCMD.Parameters.Add(new SqlParameter("@Make", (objManhiemPostSale.Make == string.Empty | objManhiemPostSale.Make == null) ? (object)System.DBNull.Value : objManhiemPostSale.Make));
                selectCMD.Parameters.Add(new SqlParameter("@Model", (objManhiemPostSale.Model == string.Empty | objManhiemPostSale.Model == null) ? (object)System.DBNull.Value : objManhiemPostSale.Model));
                selectCMD.Parameters.Add(new SqlParameter("@SubSeries", (objManhiemPostSale.SubSeries == string.Empty | objManhiemPostSale.SubSeries == null) ? (object)System.DBNull.Value : objManhiemPostSale.SubSeries));
                selectCMD.Parameters.Add(new SqlParameter("@odometer", (objManhiemPostSale.Odometer == 0) ? (object)System.DBNull.Value : objManhiemPostSale.Odometer));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.SearchForms error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable Man_Pre_GetLocationsALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetLocationsALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetLocationsALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_GetSaleDatesALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetSaleDatesALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetSaleDatesALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_GetYearsALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetYearsALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetYearsALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_GetMakesAll()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetMakesAll", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetMakesAll error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable Man_Post_GetLocationsALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetLocationsALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetLocationsALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Post_GetSaleDatesALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetSaleDatesALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetSaleDatesALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Post_GetYearsALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetYearsALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetYearsALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Post_GetMakesAll()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetMakesAll", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetMakesAll error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable Man_Post_GetSubseriesByMakeModel(string Make, string Model)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetSubseriesByMakeModel", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@Make", Make));
                selectCMD.Parameters.Add(new SqlParameter("@Model", Model));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetSubseriesByMakeModel error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Post_GetSalesByOdometer(Int32 Odometer)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetSalesByOdometer", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@Odometer", Odometer));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetSalesByOdometer error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_GetRunsByLocDate(String Location, DateTime PreSaleDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetRunsByLocDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@Location", Location));
                selectCMD.Parameters.Add(new SqlParameter("@SaleDate", PreSaleDate));


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetRunsByLocDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_GetSelected()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_GetSelected", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_GetSelected error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_InsertSelected(Int32 PresaleID, string Low, string Average, string High)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_InsertSelected", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PreSaleID", PresaleID));

                selectCMD.Parameters.Add(new SqlParameter("@Low", Low == string.Empty ? (object)System.DBNull.Value : Low));
                selectCMD.Parameters.Add(new SqlParameter("@Average", Average == string.Empty ? (object)System.DBNull.Value : Average));
                selectCMD.Parameters.Add(new SqlParameter("@High", High == string.Empty ? (object)System.DBNull.Value : High));


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_InsertSelected error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Pre_DeleteSelected(Int32 PresaleID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_DeleteSelected", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PreSaleID", PresaleID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_DeleteSelected error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable Man_Post_GetHighMileage()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Post_GetHighMileage", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Post_GetHighMileage error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public void Man_Pre_DeleteSelectedALL()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("Man_Pre_DeleteSelectedALL", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;


                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Data.Man_Pre_DeleteSelectedALL error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        //*****************************************************************************************************************************
        //*****************************************************************************************************************************




        public DataTable GetCustomerNotesByCustomerID(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerNotesByCustomerID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerNotesByCustomerID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetCustomerAccountReceivables()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerAccountReceivables", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerAccountReceivables error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }




        public DataTable GetExpenseByID(int ExpenseID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetExpenseByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@ExpenseID", ExpenseID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetExpenseByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetExpensesByBusinessID(int BusinessID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetExpensesByBusinessID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", BusinessID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetExpensesByBusinessID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetExpensesByDateRange(string StartDate, string EndDate, bool Refunded)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetExpensesByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));
                selectCMD.Parameters.Add(new SqlParameter("@Refunded", Refunded));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetExpensesByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetExpensesDeletedByDateRange(string StartDate, string EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetExpensesDeletedByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetExpensesDeletedByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetAssociateIdsWithHoursByDate(string StartDate, string EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAssociateIdsWithHoursByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAssociateIdsWithHoursByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }





        public DataTable GetTransactionByID(int TransactionID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransactionBtwDates(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionBtwDates", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionBtwDates error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetTransactionsReport(DateTime StartDate, DateTime EndDate, bool ReceivablesOnly)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionsReport", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));
                selectCMD.Parameters.Add(new SqlParameter("@ReceivablesOnly", ReceivablesOnly));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionBtwDates error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransactionPaymentsReport(DateTime StartDate, DateTime EndDate, int AssociateID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionPaymentsReport", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionPaymentsReport error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetTransactionsByBusinessID(int BusinessID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionsByBusinessID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", BusinessID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionsByBusinessID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransactionsByCustomerID(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionsByCustomerID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionsByCustomerID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable _GetTransactionsBacktrackByCustomerID(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("_GetTransactionsBacktrackByCustomerID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data._GetTransactionsBacktrackByCustomerID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable _GetBackTrackByID(int Transaction)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("_GetBackTrackByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", Transaction));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data._GetBackTrackByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }




        public DataTable GetTransactionsByDateRange(DateTime TransactionDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionDate", TransactionDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionsByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }






        public DataTable GetPaymentDetailsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentDetailsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentDetailsByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetTransactionsWithPaymentsByDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionsWithPaymentsByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionsWithPaymentsByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransCancelledWORefundByDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransCancelledWORefundByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransCancelledWORefundByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransCancelledWRefundByDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransCancelledWRefundByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransCancelledWRefundByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetTransCompletedWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransCompletedWOPaymentByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransCompletedWOPaymentByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransOpenWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransOpenWOPaymentByDate", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransOpenWOPaymentByDate error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }




        public DataTable GetTransactionDetailByID(int TransactionDetailID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionDetailByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionDetailID", TransactionDetailID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionDetailByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetTransactionDetailsByTransactionID(int TransactionID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionDetailsByTransactionID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionDetailsByTransactionID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetTransactionDetailsReport(DateTime StartDate, DateTime EndDate, int AssociateID, int CustomerID, string FormSearch)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetTransactionDetailsReport", Conn);
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@FormSearch", FormSearch));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetTransactionDetailsReport error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetPaymentByID(int PaymentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", PaymentID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetRefundByID(int RefundID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetRefundByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@RefundID", RefundID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetRefundsByTransactionID(int TransactionID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetRefundsByTransactionID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetRefundsByTransactionID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetPaymentsCollectedByDateRange(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentsCollectedByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate.ToShortDateString() + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentsCollectedByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetPayMethodCountsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPayMethodCountsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate.ToShortDateString() + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentsCollectedByDateRange error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetPayMethodCountsByDateRangeAssocID(DateTime StartDate, DateTime EndDate, int AssociateID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPayMethodCountsByDateRangeAssocID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate.ToShortDateString() + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPayMethodCountsByDateRangeAssocID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }





        public DataTable GetPaymentsCollectedByAsscociateID(int AssociateID, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentsCollectedByAsscociateID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                DateTime dtStart = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
                DateTime dtEnd = Convert.ToDateTime(EndDate.ToShortDateString() + " 23:59:59");

                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@StartDate", dtStart));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", dtEnd));


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.AssociateID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetPaymentsByTransactionID(int TransactionID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentsByTransactionID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", TransactionID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentsByTransactionID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable GetPaymentsByCustomerID(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetPaymentsByCustomerID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetPaymentsByCustomerID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public DataTable GetAppointmentByID(int AppointmentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAppointmentByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@AppointmentID", AppointmentID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAppointmentByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetAppointmentsByMonthYear(int Month, int Year)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAppointmentsByMonthYear", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@Month", Month));
                selectCMD.Parameters.Add(new SqlParameter("@Year", Year));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAppointmentsByMonthYear error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetAppointmentsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetAppointmentsByDateRange", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetAppointmentsByMonthYear error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }
        public DataTable GetCustomerNoteByID(int CustomerNoteID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetCustomerNoteByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerNoteID", CustomerNoteID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetCustomerNoteByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }





        public DataTable GetFormByID(int FormID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetFormByID", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;

                selectCMD.Parameters.Add(new SqlParameter("@FormID", FormID));

                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetFormByID error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public DataTable GetFormsAllActive()
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);

            try
            {
                SqlCommand selectCMD = new SqlCommand("GetFormsAllActive", Conn);
                selectCMD.CommandTimeout = 30;
                selectCMD.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = selectCMD;


                Conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                Conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.GetFormsAllActive error :" + ex.Message);

                //return new DataTable();
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }



        public Boolean DeleteAppointment(int AppointmentID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteAppointment", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@AppointmentID", AppointmentID));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public Boolean DeleteForm(int FormID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteForm", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@FormID", FormID));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public Boolean DeleteCustomer(int CustomerID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteCustomer", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public Boolean DeleteTransactionDetail(int TransactionDetailID, int DeletedBy)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteTransactionDetail", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionDetailID", TransactionDetailID));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", DeletedBy));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public Boolean DeletePayment(int PaymentID, int DeletedBy)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeletePayment", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", PaymentID));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", DeletedBy));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public Boolean DeleteExpense(int ExpenseID, int DeletedBy)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteExpense", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@ExpenseID", ExpenseID));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", DeletedBy));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public Boolean UpdateAppointmentTimes(int AppointmentID, DateTime StartDate, DateTime EndDate)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateAppointmentTimes", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@AppointmentID", AppointmentID));
                selectCMD.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", EndDate));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateAssociate(Associate objAssociate)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateAssociate", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objAssociate.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objAssociate.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@FirstName", objAssociate.FirstName));
                selectCMD.Parameters.Add(new SqlParameter("@LastName", objAssociate.LastName));
                selectCMD.Parameters.Add(new SqlParameter("@Address", objAssociate.Address));
                selectCMD.Parameters.Add(new SqlParameter("@City", objAssociate.City));
                selectCMD.Parameters.Add(new SqlParameter("@State", objAssociate.State));
                selectCMD.Parameters.Add(new SqlParameter("@Zip", objAssociate.Zip));
                selectCMD.Parameters.Add(new SqlParameter("@Phone", objAssociate.Phone));
                selectCMD.Parameters.Add(new SqlParameter("@AltPhone", objAssociate.AltPhone == null ? (object)System.DBNull.Value : objAssociate.AltPhone));
                selectCMD.Parameters.Add(new SqlParameter("@Email", objAssociate.Email == null ? (object)System.DBNull.Value : objAssociate.Email));
                selectCMD.Parameters.Add(new SqlParameter("@UserName", objAssociate.UserName));
                selectCMD.Parameters.Add(new SqlParameter("@Password", objAssociate.Password));
                selectCMD.Parameters.Add(new SqlParameter("@DateCreated", objAssociate.DateCreated == DateTime.MinValue ? (object)System.DBNull.Value : objAssociate.DateCreated));
                selectCMD.Parameters.Add(new SqlParameter("@Active", objAssociate.Active ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@BackgroundColor", objAssociate.BackgroundColor == null ? (object)System.DBNull.Value : objAssociate.BackgroundColor));
                selectCMD.Parameters.Add(new SqlParameter("@TextColor", objAssociate.TextColor == null ? (object)System.DBNull.Value : objAssociate.TextColor));
                selectCMD.Parameters.Add(new SqlParameter("@IsAdmin", objAssociate.IsAdmin ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@ClockedIn", objAssociate.ClockedIn ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@TrackHours", objAssociate.TrackHours ? 1 : 0));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();


                foreach (SqlParameter item in selectCMD.Parameters)
                {
                    Debug.WriteLine(item.ParameterName + " : " + item.Value);
                }



                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateAssociate error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public int UpdateBusiness(Business objBusiness)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateBusiness", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objBusiness.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessName", objBusiness.BusinessName));
                selectCMD.Parameters.Add(new SqlParameter("@Address", objBusiness.Address));
                selectCMD.Parameters.Add(new SqlParameter("@City", objBusiness.City));
                selectCMD.Parameters.Add(new SqlParameter("@State", objBusiness.State));
                selectCMD.Parameters.Add(new SqlParameter("@Zip", objBusiness.Zip));
                selectCMD.Parameters.Add(new SqlParameter("@DateCreated", objBusiness.DateCreated == DateTime.MinValue ? (object)System.DBNull.Value : objBusiness.DateCreated));
                selectCMD.Parameters.Add(new SqlParameter("@DatePaidThru", objBusiness.DatePaidThru == DateTime.MinValue ? (object)System.DBNull.Value : objBusiness.DatePaidThru));
                selectCMD.Parameters.Add(new SqlParameter("@Active", objBusiness.Active ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@ConatctFirstName", objBusiness.ConatctFirstName));
                selectCMD.Parameters.Add(new SqlParameter("@ContactLastName", objBusiness.ContactLastName));
                selectCMD.Parameters.Add(new SqlParameter("@ContactMobile", objBusiness.ContactMobile));
                selectCMD.Parameters.Add(new SqlParameter("@Phone", objBusiness.Phone));
                selectCMD.Parameters.Add(new SqlParameter("@Fax", objBusiness.Fax));
                selectCMD.Parameters.Add(new SqlParameter("@Password", objBusiness.Password));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateBusiness error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateCustomer(Customer objCustomer)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateCustomer", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objCustomer.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@FirstName", objCustomer.FirstName));
                selectCMD.Parameters.Add(new SqlParameter("@LastName", objCustomer.LastName));
                selectCMD.Parameters.Add(new SqlParameter("@SecondaryFirstName", objCustomer.SecondaryFirstName == null | objCustomer.SecondaryFirstName == string.Empty ? (object)System.DBNull.Value : objCustomer.SecondaryFirstName));
                selectCMD.Parameters.Add(new SqlParameter("@SecondaryLastName", objCustomer.SecondaryLastName == null | objCustomer.SecondaryLastName == string.Empty ? (object)System.DBNull.Value : objCustomer.SecondaryLastName));
                selectCMD.Parameters.Add(new SqlParameter("@Address", objCustomer.Address));
                selectCMD.Parameters.Add(new SqlParameter("@City", objCustomer.City));
                selectCMD.Parameters.Add(new SqlParameter("@State", objCustomer.State));
                selectCMD.Parameters.Add(new SqlParameter("@Zip", objCustomer.Zip));
                selectCMD.Parameters.Add(new SqlParameter("@DateCreated", objCustomer.DateCreated == DateTime.MinValue ? (object)System.DBNull.Value : objCustomer.DateCreated));
                selectCMD.Parameters.Add(new SqlParameter("@Phone", objCustomer.Phone == null | objCustomer.Phone == string.Empty ? (object)System.DBNull.Value : CleanPhoneNumber(objCustomer.Phone)));
                selectCMD.Parameters.Add(new SqlParameter("@Mobile", objCustomer.Mobile == null | objCustomer.Mobile == string.Empty ? (object)System.DBNull.Value : CleanPhoneNumber(objCustomer.Mobile)));
                selectCMD.Parameters.Add(new SqlParameter("@Fax", objCustomer.Fax == null | objCustomer.Fax == string.Empty ? (object)System.DBNull.Value : CleanPhoneNumber(objCustomer.Fax)));
                selectCMD.Parameters.Add(new SqlParameter("@Email", objCustomer.Email == null | objCustomer.Email == string.Empty ? (object)System.DBNull.Value : objCustomer.Email));
                selectCMD.Parameters.Add(new SqlParameter("@Active", objCustomer.Active ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@Citizen", objCustomer.Citizen ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@AssignedTo", objCustomer.AssignedTo));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateCustomer error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdatePayment(Payment objPayment)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdatePayment", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@PaymentID", objPayment.PaymentID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objPayment.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objPayment.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objPayment.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@PaymentAmount", objPayment.PaymentAmount));
                selectCMD.Parameters.Add(new SqlParameter("@PaymentDate", objPayment.PaymentDate == DateTime.MinValue ? (object)System.DBNull.Value : objPayment.PaymentDate));
                selectCMD.Parameters.Add(new SqlParameter("@PaymentMethod", objPayment.PaymentMethod));
                selectCMD.Parameters.Add(new SqlParameter("@CheckNumber", objPayment.CheckNumber == 0 ? (object)System.DBNull.Value : objPayment.CheckNumber));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", objPayment.DeletedBy == 0 ? (object)System.DBNull.Value : objPayment.DeletedBy));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdatePayment error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public int UpdateTransaction(Transaction objTransaction)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateTransaction", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objTransaction.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objTransaction.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objTransaction.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objTransaction.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionDate", objTransaction.TransactionDate == DateTime.MinValue ? (object)System.DBNull.Value : objTransaction.TransactionDate));
                //selectCMD.Parameters.Add(new SqlParameter("@TotalAmount", objTransaction.TotalAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatusID", objTransaction.TransactionStatusID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatus", objTransaction.TransactionStatus));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedBy", objTransaction.ModifiedBy));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedDate", objTransaction.ModifiedDate == DateTime.MinValue ? (object)System.DBNull.Value : objTransaction.ModifiedDate));
                selectCMD.Parameters.Add(new SqlParameter("@RefundedAmount", objTransaction.RefundedAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TotalCollected", objTransaction.TotalCollected));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateTransaction error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public int UpdateTransactionDetail(TransactionDetail objTransactionDetail)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateTransactionDetail", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionDetailID", objTransactionDetail.TransactionDetailID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objTransactionDetail.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@FormID", objTransactionDetail.FormID));
                selectCMD.Parameters.Add(new SqlParameter("@FormTitle", objTransactionDetail.FormTitle));
                selectCMD.Parameters.Add(new SqlParameter("@UnitPrice", objTransactionDetail.UnitPrice));
                selectCMD.Parameters.Add(new SqlParameter("@DiscountPrice", objTransactionDetail.DiscountPrice));
                selectCMD.Parameters.Add(new SqlParameter("@Quantity", objTransactionDetail.Quantity));
                selectCMD.Parameters.Add(new SqlParameter("@Notes", objTransactionDetail.Notes == string.Empty || objTransactionDetail.Notes == null ? (object)System.DBNull.Value : objTransactionDetail.Notes));
                selectCMD.Parameters.Add(new SqlParameter("@Total", objTransactionDetail.Total));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", objTransactionDetail.DeletedBy == 0 ? (object)System.DBNull.Value : objTransactionDetail.DeletedBy));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateTransactionDetail error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateAppointment(Appointment objAppointment)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateAppointment", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@AppointmentID", objAppointment.AppointmentID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objAppointment.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@StartDate", objAppointment.StartDate == DateTime.MinValue ? (object)System.DBNull.Value : objAppointment.StartDate));
                selectCMD.Parameters.Add(new SqlParameter("@EndDate", objAppointment.EndDate == DateTime.MinValue ? (object)System.DBNull.Value : objAppointment.EndDate));
                selectCMD.Parameters.Add(new SqlParameter("@AppointmentName", objAppointment.AppointmentName));
                selectCMD.Parameters.Add(new SqlParameter("@AssignedTo", objAppointment.AssignedTo));
                selectCMD.Parameters.Add(new SqlParameter("@Active", objAppointment.Active ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@Description", objAppointment.Description));
                selectCMD.Parameters.Add(new SqlParameter("@CreatedDate", objAppointment.CreatedDate == DateTime.MinValue ? (object)System.DBNull.Value : objAppointment.CreatedDate));
                selectCMD.Parameters.Add(new SqlParameter("@CreatedBy", objAppointment.CreatedBy));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateAppointment error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateForm(Form objForm)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateForm", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@FormID", objForm.FormID));
                selectCMD.Parameters.Add(new SqlParameter("@Title", objForm.Title));
                selectCMD.Parameters.Add(new SqlParameter("@FormName", objForm.FormName));
                selectCMD.Parameters.Add(new SqlParameter("@Active", objForm.Active ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@Price", objForm.Price));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateForm error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateCustomerNote(CustomerNote objCustomerNote)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateCustomerNote", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerNoteID", objCustomerNote.CustomerNoteID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objCustomerNote.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@Note", objCustomerNote.Note));
                selectCMD.Parameters.Add(new SqlParameter("@AddedBy", objCustomerNote.AddedBy));
                selectCMD.Parameters.Add(new SqlParameter("@DateAdded", objCustomerNote.DateAdded == DateTime.MinValue ? (object)System.DBNull.Value : objCustomerNote.DateAdded));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateCustomerNote error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public Boolean DeleteCustomerNote(int CustomerNoteID)
        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("DeleteCustomerNote", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@CustomerNoteID", CustomerNoteID));

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateExpense(Expense objExpense)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateExpense", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@ExpenseID", objExpense.ExpenseID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objExpense.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@PaidTo", objExpense.PaidTo));
                selectCMD.Parameters.Add(new SqlParameter("@Description", objExpense.Description));
                selectCMD.Parameters.Add(new SqlParameter("@ExpenseDate", objExpense.ExpenseDate == DateTime.MinValue ? (object)System.DBNull.Value : objExpense.ExpenseDate));
                selectCMD.Parameters.Add(new SqlParameter("@DateEntered", objExpense.DateEntered == DateTime.MinValue ? (object)System.DBNull.Value : objExpense.DateEntered));
                selectCMD.Parameters.Add(new SqlParameter("@Refunded", objExpense.Refunded ? 1 : 0));
                selectCMD.Parameters.Add(new SqlParameter("@TakenBy", objExpense.TakenBy));
                selectCMD.Parameters.Add(new SqlParameter("@ExpenseAmount", objExpense.ExpenseAmount));
                selectCMD.Parameters.Add(new SqlParameter("@RefundedBy", objExpense.RefundedBy));
                selectCMD.Parameters.Add(new SqlParameter("@DeletedBy", objExpense.DeletedBy));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateExpense error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateRefund(Refund objRefund)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateRefund", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@RefundID", objRefund.RefundID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objRefund.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@RefundAmount", objRefund.RefundAmount));
                selectCMD.Parameters.Add(new SqlParameter("@RefundDate", objRefund.RefundDate == DateTime.MinValue ? (object)System.DBNull.Value : objRefund.RefundDate));
                selectCMD.Parameters.Add(new SqlParameter("@RefundedBy", objRefund.RefundedBy));
                selectCMD.Parameters.Add(new SqlParameter("@Note", objRefund.Note));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateRefund error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public int UpdateAssociateClockInHistory(AssociateClockInHistory objAssociateClockInHistory)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateAssociateClockInHistory", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@AssociateClockInHistoryID", objAssociateClockInHistory.AssociateClockInHistoryID));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objAssociateClockInHistory.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@LoginDatetime", objAssociateClockInHistory.LoginDatetime == DateTime.MinValue ? (object)System.DBNull.Value : objAssociateClockInHistory.LoginDatetime));
                selectCMD.Parameters.Add(new SqlParameter("@LogoutDatetime", objAssociateClockInHistory.LogoutDatetime == DateTime.MinValue ? (object)System.DBNull.Value : objAssociateClockInHistory.LogoutDatetime));
                selectCMD.Parameters.Add(new SqlParameter("@IsLunch", objAssociateClockInHistory.IsLunch ? 1 : 0));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateAssociateClockInHistory error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public int Update_Transactions(BackTrack objBackTrack)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("Update_Transactions", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objBackTrack.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objBackTrack.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objBackTrack.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objBackTrack.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionDate", objBackTrack.TransactionDate == DateTime.MinValue ? (object)System.DBNull.Value : objBackTrack.TransactionDate));
                //selectCMD.Parameters.Add(new SqlParameter("@TotalAmount", objBackTrack.TotalAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatusID", objBackTrack.TransactionStatusID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatus", objBackTrack.TransactionStatus));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedBy", objBackTrack.ModifiedBy));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedDate", objBackTrack.ModifiedDate == DateTime.MinValue ? (object)System.DBNull.Value : objBackTrack.ModifiedDate));
                selectCMD.Parameters.Add(new SqlParameter("@RefundedAmount", objBackTrack.RefundedAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TotalCollected", objBackTrack.TotalCollected));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return (int)retValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateReminder error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }


        public int UpdateBackTrack(BackTrack objBackTrack)

        {
            SqlConnection Conn = new SqlConnection(this.ConnString);
            try
            {
                SqlCommand selectCMD = new SqlCommand("UpdateBackTrack", Conn);

                selectCMD.CommandTimeout = 30;

                selectCMD.CommandType = CommandType.StoredProcedure;

                selectCMD.Parameters.Add(new SqlParameter("@TransactionID", objBackTrack.TransactionID));
                selectCMD.Parameters.Add(new SqlParameter("@BusinessID", objBackTrack.BusinessID));
                selectCMD.Parameters.Add(new SqlParameter("@CustomerID", objBackTrack.CustomerID));
                selectCMD.Parameters.Add(new SqlParameter("@AssociateID", objBackTrack.AssociateID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionDate", objBackTrack.TransactionDate == DateTime.MinValue ? (object)System.DBNull.Value : objBackTrack.TransactionDate));
                //selectCMD.Parameters.Add(new SqlParameter("@TotalAmount", objBackTrack.TotalAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatusID", objBackTrack.TransactionStatusID));
                selectCMD.Parameters.Add(new SqlParameter("@TransactionStatus", objBackTrack.TransactionStatus));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedBy", objBackTrack.ModifiedBy));
                selectCMD.Parameters.Add(new SqlParameter("@ModifiedDate", objBackTrack.ModifiedDate == DateTime.MinValue ? (object)System.DBNull.Value : objBackTrack.ModifiedDate));
                selectCMD.Parameters.Add(new SqlParameter("@RefundedAmount", objBackTrack.RefundedAmount));
                selectCMD.Parameters.Add(new SqlParameter("@TotalCollected", objBackTrack.TotalCollected));

                SqlParameter retValue = selectCMD.Parameters.Add("@Ret", SqlDbType.Int);

                retValue.Direction = ParameterDirection.Output;

                Conn.Open();

                selectCMD.ExecuteNonQuery();

                Conn.Close();

                return objBackTrack.TransactionID;
            }
            catch (Exception ex)
            {
                throw new Exception("Data.UpdateBackTrack error :" + ex.Message);
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }





        private string CleanPhoneNumber(string PhoneNumber)
        {
            string strRet = string.Empty;

            try
            {
                strRet = PhoneNumber.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "");
            }
            catch
            {
                strRet = PhoneNumber;
            }

            return strRet;
        }



    }


}
