using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controlador
{
    public class DB_Connection
    {
        public SqlDataReader reader { get; set; }
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }

        public DB_Connection()      //  conectando a base de datos
        {
            connection = new SqlConnection("Data Source = DESKTOP-B1FI7SE\\SQLEXPRESS; Initial Catalog = Handyman_DB; Integrated Security = True");
            command = new SqlCommand();
            command.Connection = connection;
        }

        public void setQuery(string query)     //   setear consulta
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void setStoreProcedure(string sp)    //  setear procedimiento almacenado
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }

        public void addParameters(string name, object value)    //agregar parámetros
        {
            command.Parameters.AddWithValue(name, value);
        }

        public void executeReader()     //ejecutar Lector
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //connection.Close();         
            }
        }

        public void closeConnection()    //cerrar conexión
        {
            connection.Close();
        }

        internal void executeAction()   //ejecutar acción
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
