using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class PaymentBLL
    {
        public List<Payment> GetPayments(bool? state = true)
        {
            Payment aux;
            var lista = new List<Payment>();
            var data = new DB_Connection();

            try
            {
                data.setQuery("SELECT Id, Description, Status FROM PAYMENTS" + (state ?? false ? " WHERE Status = 1" : "") + " ORDER BY Description");
                data.executeReader();

                while (data.reader.Read())
                {
                    aux = new Payment(  Convert.ToInt32(data.reader["Id"]),
                                        Convert.ToString(data.reader["Description"]),
                                        Convert.ToBoolean(data.reader["Status"])    );

                    lista.Add(aux);
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

        // AGREGAR PAGO
        public void AddPayment(string description) /*(Persona persona)*/
        {
            var data = new DB_Connection();

            try
            {
                if (ValidatePayment(description) == false) // si no existe, agregamos!
                {
                    data.setStoreProcedure("SP_InsertPayment");

                    data.addParameters("@description", description);

                    data.executeAction();
                }
                else
                {
                    data.closeConnection();
                }
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

        // EDITAR PAGO
        public void EditPayment(int id, string description, bool state)
        {
            var data = new DB_Connection();

            try
            {
                data.setStoreProcedure("SP_EditPayment");

                data.addParameters("@id", id);
                data.addParameters("@description", description);
                data.addParameters("@status", state); 

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ELIMINAR PAGO
        public bool DeletePayment(int id)
        {
            var data = new DB_Connection();

            var registrosAfectados = 0;
            try
            {
                data.setQuery("UPDATE PAYMENTS SET Status = 0 WHERE Id =" + id);
                registrosAfectados = data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registrosAfectados > 0;
        }

        //          VALIDACIONES        //

        public bool ValidatePayment(string description)
        {
            var data = new DB_Connection();

            try
            {
                string consulta = "SELECT COUNT(*) FROM PAYMENTS WHERE Description = @desc";

                data.connection.Open();

                SqlCommand cmd = new SqlCommand(consulta, data.connection);
                cmd.Parameters.AddWithValue("@desc", description);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    return false; // si count es igual 0, es porque no existe un registro con la misma descripción y devuelve un false;
                }
                else { return true; }  //caso contrario, sí existe y devuelve un true;           
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
