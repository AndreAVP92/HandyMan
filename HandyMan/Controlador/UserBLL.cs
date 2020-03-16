using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class UserBLL
    {
        public void addPersona(string nombre, DateTime fecha, string pais, decimal credito)
        {
            DB_Connection data = new DB_Connection();

            try
            {
                int IdPais = obtenerIdPais(pais);

                data.setQuery("INSERT INTO PERSONAS(Nombre, Fecha_Nacimiento, Id_Pais, Credito_Maximo) VALUES ('" + nombre + "','" + fecha + "', '" + IdPais + "','" + credito + "');");

                //data.addParameters("@nombre" , persona.Nombre);
                //data.addParameters("@fecha"  , persona.Fecha_Nacimiento);
                //data.addParameters("@idpais" , persona.Pais.Id);
                //data.addParameters("@credito", persona.Credito_Maximo);

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void deletePersona(int id)
        {
            DB_Connection data = new DB_Connection();
            try
            {
                data.setQuery("DELETE FROM PERSONAS WHERE Id =" + id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> listarPersonas()
        {
            List<User> lista = new List<User>();
            //User aux;

            DB_Connection data = new DB_Connection();

            try
            {
                data.setQuery("SELECT *FROM View_Personas");
                data.executeReader();

                while (data.reader.Read())
                {
                    //aux = new User((int)(data.reader["Id"]),
                    //                   Convert.ToString(data.reader["Nombre"]),
                    //                   Convert.ToDateTime(data.reader["Fecha_Nacimiento"]),
                    //                        new Pais((int)data.reader["Id"],
                    //                                 (string)data.reader["Descripcion"]),
                    //                   Convert.ToDecimal(data.reader["Credito_Maximo"]));
                    //lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        //Método para obtener el Id Pais mediante nombre del país
        public Int32 obtenerIdPais(string nombrePais)
        {
            DB_Connection data = new DB_Connection();

            try
            {
                string consulta = "SELECT Id FROM PAISES WHERE Descripcion = @descripcion";
                data.connection.Open();
                SqlCommand cmd = new SqlCommand(consulta, data.connection);
                cmd.Parameters.AddWithValue("@descripcion", nombrePais);

                Int32 idPais = Convert.ToInt32(cmd.ExecuteScalar());

                return idPais;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}
