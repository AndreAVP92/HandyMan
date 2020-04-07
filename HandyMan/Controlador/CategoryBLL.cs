using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
using System.Data;

namespace Controlador
{
    public class CategoryBLL
    {
        //LISTAR CATEGORÍAS
        public List<Category> GetCategories(bool? state = true)
        //public List<Category> GetCategories(bool state)
        {
            Category aux;
            var lista = new List<Category>();         
            var data = new DB_Connection();

            try
            {
                data.setQuery("SELECT Id, Description, Status FROM CATEGORIES" + (state ?? false ? " WHERE Status = 1" : "") + " ORDER BY Description");
                //etQuery("SELECT Id, Description, Status FROM CATEGORIES WHERE Status =" + state + " ORDER BY Description");
                data.executeReader();

                while (data.reader.Read())
                {
                    aux = new Category(     Convert.ToInt32(data.reader["Id"]),
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
        public void AddCategory(string description) /*(Persona persona)*/
        {
            var data = new DB_Connection();

            try
            {
                if (ValidateCategory(description) == false) // si no existe, agregamos!
                {
                    data.setStoreProcedure("SP_InsertCategory");

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

        // EDITAR CATEGORÍA
        public void EditCategory(int id, string description)
        {
           var data = new DB_Connection();

            try
            {
                data.setStoreProcedure("SP_EditCategory");

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
        public bool DeleteCategory(int id)
        {
            var data = new DB_Connection();

            var registrosAfectados = 0;
            try
            {
                data.setQuery("UPDATE CATEGORIES SET Status = 0 WHERE Id =" + id);
                registrosAfectados = data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registrosAfectados > 0;
        }

        //          VALIDACIONES        //

        public bool ValidateCategory(string description)
        {
            var data = new DB_Connection();
            
            try
            {
                string consulta = "SELECT COUNT(*) FROM CATEGORIES WHERE Description = @desc";
                
                data.connection.Open();
                
                SqlCommand cmd = new SqlCommand(consulta, data.connection);
                cmd.Parameters.AddWithValue("@desc", description);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    if(count == 0)
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

        //public int searchCategoryID(string category)
        //{
        //    var data = new DB_Connection();

        //    string query = "SELECT Id FROM CATEGORIES WHERE Description=" + category;
        //    SqlCommand cmd = new SqlCommand(query, data.connection);
        //    data.connection.Open();
        //    int idcategory = Convert.ToInt32(cmd.ExecuteScalar());
        //    data.connection.Close();

        //    return idcategory;
        //}
    }
}
