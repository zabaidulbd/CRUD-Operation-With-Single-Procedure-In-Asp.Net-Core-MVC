using SatyaMvc4Crud.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SatyaMvc4Crud.DataAccess
{
    public class DataAccessLayer
    {
        private readonly IConfiguration _configuration;

        public DataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string InsertData(Customer objcust)
        {
            string connectionString = _configuration.GetConnectionString("mycon");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string result = "";
                try
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", objcust.Name);
                    cmd.Parameters.AddWithValue("@Address", objcust.Address);
                    cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                    cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                    cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                    cmd.Parameters.AddWithValue("@Query", 1);
                    con.Open();
                    result = cmd.ExecuteScalar().ToString();
                    return result;
                }
                catch
                {
                    return result = "";
                }
            }
        }

        public string UpdateData(Customer objcust)
        {
            string connectionString = _configuration.GetConnectionString("mycon");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string result = "";
                try
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                    cmd.Parameters.AddWithValue("@Name", objcust.Name);
                    cmd.Parameters.AddWithValue("@Address", objcust.Address);
                    cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                    cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                    cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                    cmd.Parameters.AddWithValue("@Query", 2);
                    con.Open();
                    result = cmd.ExecuteScalar().ToString();
                    return result;
                }
                catch
                {
                    return result = "";
                }
            }
        }

        public int DeleteData(string ID)
        {
            string connectionString = _configuration.GetConnectionString("mycon");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int result = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", ID);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobileno", null);
                    cmd.Parameters.AddWithValue("@Birthdate", null);
                    cmd.Parameters.AddWithValue("@EmailID", null);
                    cmd.Parameters.AddWithValue("@Query", 3);
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch
                {
                    return result = 0;
                }
            }
        }

        public List<Customer> Selectalldata()
        {
            string connectionString = _configuration.GetConnectionString("mycon");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet ds = null;
                List<Customer> custlist = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", null);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobileno", null);
                    cmd.Parameters.AddWithValue("@Birthdate", null);
                    cmd.Parameters.AddWithValue("@EmailID", null);
                    cmd.Parameters.AddWithValue("@Query", 4);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    custlist = new List<Customer>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Customer cobj = new Customer();
                        cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                        cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                        cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
                        cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                        cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());

                        custlist.Add(cobj);
                    }
                    return custlist;
                }
                catch
                {
                    return custlist;
                }
            }
        }

        public Customer SelectDatabyID(string CustomerID)
        {
            string connectionString = _configuration.GetConnectionString("mycon");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet ds = null;
                Customer cobj = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@Name", null);
                    cmd.Parameters.AddWithValue("@Address", null);
                    cmd.Parameters.AddWithValue("@Mobileno", null);
                    cmd.Parameters.AddWithValue("@Birthdate", null);
                    cmd.Parameters.AddWithValue("@EmailID", null);
                    cmd.Parameters.AddWithValue("@Query", 5);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        cobj = new Customer();
                        cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                        cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                        cobj.Mobileno = ds.Tables[0].Rows[i]["Mobileno"].ToString();
                        cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                        cobj.Birthdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthdate"].ToString());

                    }
                    return cobj;
                }
                catch
                {
                    return cobj;
                }
            }
        }
    }
}
