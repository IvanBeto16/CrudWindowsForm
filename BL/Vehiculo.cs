using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vehiculo
    {
        public static ML.Result Add(ML.Vehiculo vehiculo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string cmd = "VehiculoAdd";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@Modelo", SqlDbType.VarChar);
                    param[0].Value = vehiculo.Modelo;
                    param[1] = new SqlParameter("@Marca", SqlDbType.VarChar);
                    param[1].Value = vehiculo.Marca;
                    param[2] = new SqlParameter("@AnioFabricacion", SqlDbType.Int);
                    param[2].Value = vehiculo.AnioFabricacion;
                    param[3] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                    param[3].Value = vehiculo.Tipo;

                    query.Parameters.AddRange(param);
                    query.Connection.Open();

                    int inserciones = query.ExecuteNonQuery();
                    if (inserciones > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar el vehiculo nuevo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Vehiculo vehiculo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string cmd = "VehiculoUpdate";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@IdVehiculo", SqlDbType.Int);
                    param[0].Value = vehiculo.IdVehiculo;
                    param[1] = new SqlParameter("@Modelo", SqlDbType.VarChar);
                    param[1].Value = vehiculo.Modelo;
                    param[2] = new SqlParameter("@Marca", SqlDbType.VarChar);
                    param[2].Value = vehiculo.Marca;
                    param[3] = new SqlParameter("@AnioFabricacion", SqlDbType.Int);
                    param[3].Value = vehiculo.AnioFabricacion;
                    param[4] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                    param[4].Value = vehiculo.Tipo;

                    query.Parameters.AddRange(param);
                    query.Connection.Open();

                    int inserciones = query.ExecuteNonQuery();
                    if(inserciones > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar la entidad";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Vehiculo vehiculo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string cmd = "VehiculoDelete";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IdVehiculo", SqlDbType.Int);
                    param[0].Value = vehiculo.IdVehiculo;

                    query.Parameters.AddRange(param);
                    query.Connection.Open();

                    int eliminaciones = query.ExecuteNonQuery();
                    if (eliminaciones > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el vehiculo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using(SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string cmd = "VehiculoGetAll";
                SqlCommand query = new SqlCommand(cmd, conexion);
                query.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                if(tabla.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach(DataRow row in tabla.Rows)
                    {
                        ML.Vehiculo vehiculo = new ML.Vehiculo();
                        vehiculo.IdVehiculo = int.Parse(row[0].ToString());
                        vehiculo.Modelo = row[1].ToString();
                        vehiculo.Marca = row[2].ToString();
                        vehiculo.AnioFabricacion = int.Parse(row[3].ToString());
                        vehiculo.Tipo = row[4].ToString();

                        result.Objects.Add(vehiculo);
                        result.Correct = true;
                    }
                }
                else
                {
                    result.Correct = false;
                }
            }
            return result;
        }

        public static ML.Result GetById(ML.Vehiculo vehiculo)
        {
            ML.Result result = new ML.Result();
            using(SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string cmd = "VehiculoGetById";
                SqlCommand query = new SqlCommand(cmd, conexion);
                query.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IdVehiculo", SqlDbType.Int);
                param[0].Value = vehiculo.IdVehiculo;

                query.Parameters.AddRange(param);
                query.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                if(tabla.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach(DataRow row in tabla.Rows)
                    {
                        ML.Vehiculo automovil = new ML.Vehiculo();
                        automovil.IdVehiculo = int.Parse(row[0].ToString());
                        automovil.Modelo = row[1].ToString();
                        automovil.Marca = row[2].ToString();
                        automovil.AnioFabricacion = int.Parse(row[3].ToString());
                        automovil.Tipo = row[4].ToString();

                        result.Objects.Add(automovil);
                        result.Correct = true;
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra el vehiculo seleccionado";
                }
            }
            return result;
        }
    }
}
