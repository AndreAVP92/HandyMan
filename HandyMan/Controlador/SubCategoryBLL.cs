using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class SubCategoryBLL
    {
        //LISTAR CATEGORÍAS
        public List<SubCategory> GetSubCategories(bool? state = true)
        {
            SubCategory aux;
            var lista = new List<SubCategory>();
            var data = new DB_Connection();

            try
            {
                data.setQuery("SELECT Id, Description, Status FROM SUBCATEGORIES" + (state ?? false ? " WHERE Status = 1" : "") + " ORDER BY Description");
                data.executeReader();

                while (data.reader.Read())
                {
                    aux = new SubCategory(  Convert.ToInt32(data.reader["Id"]),
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

        // AGREGAR CATEGORÍA
        public void AddSubCategory(string description, int idCategory) 
        {
            var data = new DB_Connection();
            
            try
            {
                if (ValidateSubCategory(description) == false) // si no existe, agregamos!
                {
                    data.setStoreProcedure("SP_InsertSubCategory");

                    data.addParameters("@description", description);
                    data.addParameters("@idCategory", idCategory);

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

        // EDITAR CATEGORÍA
        public void EditSubCategory(int id, string description)
        {
            var data = new DB_Connection();

            try
            {
                data.setStoreProcedure("SP_EditSubCategory");

                data.addParameters("@id", id);
                data.addParameters("@description", description);
                data.addParameters("@status", true);

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ELIMINAR CATEGORÍA
        public bool DeleteSubCategory(int id)
        {
            var data = new DB_Connection();

            var registrosAfectados = 0;
            try
            {
                data.setQuery("UPDATE SUBCATEGORIES SET Status = 0 WHERE Id =" + id);
                registrosAfectados = data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registrosAfectados > 0;
        }


        //          VALIDACIONES        //

        public bool ValidateSubCategory(string description)
        {
            var data = new DB_Connection();

            try
            {
                string consulta = "SELECT COUNT(*) FROM SUBCATEGORIES WHERE Description = @desc";

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
