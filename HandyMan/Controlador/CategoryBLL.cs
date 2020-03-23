using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controlador
{
    public class CategoryBLL
    {

        // AGREGAR CATEGORÍA
        public void addCategory(string description ) /*(Persona persona)*/
        {
           DB_Connection data = new DB_Connection();

            try
            {
                data.setStoreProcedure("SP_InsertCategory");

                data.addParameters("@description", description);
 
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

        // EDITAR CATEGORÍA
        public void editCategory(string description, bool state)
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
        public void deleteCategory(int id)
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
    }
}
