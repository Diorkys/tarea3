using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos.Conexion;
using Comun.Atributos;

namespace AccesoDatos.Entidades
{
    public class Persona
    {

        //VARIABLES
        ConnectionBD c = new ConnectionBD();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable td = new DataTable();

        public DataTable Mostrar()
        {
            try 
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Mostrar";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                td.Load(dr);
            }
            catch (Exception ex) 
            {
                string msg = ex.ToString();    
            }
            finally 
            {
                cmd.Connection = c.CloseConnection(); 
            }
            return td;
        }


        public DataTable Buscar(String Buscar)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", Buscar);
                dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                td.Load(dr);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
            return td;
        }

        public void Insertar(AtributosPersona obj)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Insertar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.Id1);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.Fecha_nacimiento);
                cmd.Parameters.AddWithValue("@celular", obj.Celular);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

            catch(Exception ex)
            {
                string msg = ex.ToString();
            }

            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }





        public void Modificar(AtributosPersona obj)
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.Id1);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", obj.Fecha_nacimiento);
                cmd.Parameters.AddWithValue("@celular", obj.Celular);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

            catch (Exception ex)
            {
                string msg = ex.ToString();
            }

            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }



        public void Eliminar(AtributosPersona obj)

        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.Id1);
                cmd.ExecuteReader();
                cmd.Parameters.Clear();

            }

            catch (Exception ex)
            {
                string msj = ex.ToString();
            }

            finally
            { 
            
            }

        }
    }
}
