using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class CategoryBLL
    {
        //LISTAR CATEGORÍAS
        public List<Category> GetCategories()
        {
            List<Category> lista = new List<Category>();
            Category aux;

            DB_Connection data = new DB_Connection();

            try
            {
                data.setQuery("SELECT Id, Description, Status FROM CATEGORIES WHERE Status = 1");
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
           DB_Connection data = new DB_Connection();

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
        public void EditCategory(string description, bool state)
        {
            DB_Connection data = new DB_Connection();

            try
            {
                data.setStoreProcedure("SP_EditCategory");
                
                data.addParameters("@description", description);
                data.addParameters("@status", state);

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ELIMINAR CATEGORÍA
        public void DeleteCategory(int id)
        {
            DB_Connection data = new DB_Connection();

            try
            {
                data.setQuery("DELETE FROM CATEGORIES WHERE Id =" + id); 
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //          VALIDACIONES        //

        public bool ValidateCategory(string description)
        {
            DB_Connection data = new DB_Connection();
            
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
    }
}
