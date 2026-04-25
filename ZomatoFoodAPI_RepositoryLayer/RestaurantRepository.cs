using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Interfaces;
using ZomatoFoodAPI_BusinessEntities.Models;
using ZomatoFoodAPI_BusinessEntities.Utils;

namespace ZomatoFoodAPI_RepositoryLayer
{
    public class RestaurantRepository : IRestaurantRepository
    {  //WE NEED TO INJECT THE CONNECTION FACTORY INTERFACE IN THE CONSTRUCTOR OF THE Restaurant REPOSITORY CLASS AND ASSIGN IT TO THE PRIVATE READONLY FIELD OF THE ICONNECTIONFACTORY INTERFACE TYPE.
        private readonly IConnectionFactory _connectionFactory;
        public RestaurantRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AddRestaurant(Restaurant Objres)
        {//addorder is used add the data to database by using the stored procedure and the parameters of the stored procedure are passed as the parameters of the command object and the command type is set to stored procedure and then the data adapter is used to fill the dataset with the data from the database and then the dataset is returned to the caller.
            using (SqlConnection con = _connectionFactory.RestaurantDBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddRestaurant, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.RestaurantName, Objres.RestaurantName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.RestaurantLocation, Objres.RestaurantLocation);
                //below code is used to store the stoedprocedure return value.
                SqlParameter outputParam = new SqlParameter(StoredprocedureParameters.Insertedvariable, SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;//if stooredprocedure returns any output params value.by using this process we can return
                cmd.Parameters.Add(outputParam);//need to add output parameter to sqlcommand object.this is the rule.

                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Restaurant");//dataset is filled with the data from the database and the name of the datatable is Order
                                               //you can give any name for dataset but it is better to give the name of the table as the name of the datatable in the dataset for better understanding and readability of the code.
                var restaurantCount = (int)cmd.Parameters[StoredprocedureParameters.Insertedvariable].Value;
                //return restaurantCount;

            }
            return true;

        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            using (SqlConnection con = _connectionFactory.RestaurantDBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteRestaurant, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.ID, Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);

            }
            return true;

        }

        public async Task<List<Restaurant>> GetallRestaurants()
        {
            using (SqlConnection con = _connectionFactory.RestaurantDBSqlConnectionString())
            {
                List<Restaurant> restaurantslist = new List<Restaurant>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetRestaurant, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Restaurants");
                foreach (DataRow row in ds.Tables["Restaurants"].Rows)
                {
                    Restaurant res = new Restaurant();
                    res.Id = Convert.ToInt16(row["Id"]);//HERE CONVERTTHE DATA TO INT FORMAT 
                    res.RestaurantName = Convert.ToString(row["RestaurantName"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    res.RestaurantLocation = Convert.ToString(row["RestaurantLocation"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    res.CreationDate = Convert.ToString(row["CreationDate"]);
                    restaurantslist.Add(res);
                }
                return restaurantslist;
            }

        }

        public async Task<Restaurant> GetRestaurantById(int Id)
        {
            Restaurant res = new Restaurant();
            using (SqlConnection con = _connectionFactory.RestaurantDBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetRestaurantById, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.ID, Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Restaurant");
                foreach (DataRow row in ds.Tables["Restaurant"].Rows)
                {

                    res.Id = Convert.ToInt16(row["Id"]);//HERE CONVERTTHE DATA TO INT FORMAT 
                    res.RestaurantName = Convert.ToString(row["RestaurantName"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    res.RestaurantLocation = Convert.ToString(row["RestaurantLocation"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    res.CreationDate = Convert.ToString(row["CreationDate"]);
                }
                return res;
            }

        }

        public async Task<bool> UpdateRestaurant(Restaurant Objres)
        {
            using (SqlConnection con = _connectionFactory.RestaurantDBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateRestaurant, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.ID, Objres.Id);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.RestaurantName, Objres.RestaurantName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.RestaurantLocation, Objres.RestaurantLocation);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Restaurant");
            }
            return true;

        }
    }
}
