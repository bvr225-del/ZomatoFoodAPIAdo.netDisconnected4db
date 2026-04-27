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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DepartmentRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddDepartment(Department Dept)
        {
            using (SqlConnection con =_connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                //here to pass the values to storedprocedure parameters use the AddWithValue method of the Parameters collection of the SqlCommand object.
                //The first argument is the name of the parameter as defined in the stored procedure, and the second argument is the value you want to pass to that parameter.
                //In this case, we are passing the DepartmentName property of the Dept object to the @DeptName parameter in the stored procedure.
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //SqlDataAdapter class usage is it will open the connection and executing the query and fill the dataset and then it will close the connection automatically
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }

        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            using (SqlConnection con =_connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, DepartmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            using (SqlConnection con =_connectionFactory.Northwind_DBSqlConnectionString())
            {
                List<Department> lstdep = new List<Department>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    Department dep = new Department();
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                    lstdep.Add(dep);
                }
                return lstdep;
            }
        }

        public async Task<Department> GetDepartmentById(int DepartmentId)
        {
            Department dep = new Department();
            using (SqlConnection con =_connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartmentByDeptId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, DepartmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                }
            }
            return dep;
        }

        public async Task<bool> UpdateDepartment(Department Dept)
        {
            using (SqlConnection con =_connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, Dept.DepartmentId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }
    }
}
