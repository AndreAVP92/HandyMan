using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Controlador;
using Modelo;

namespace Vista
{
    public partial class crud_Categories : System.Web.UI.Page
    {
        public static List<Category> ListCategories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void AddingCategory(string description)
        {
            try
            {
                var categoryBLL = new CategoryBLL();

                categoryBLL.AddCategory(description);
                //GetCategories(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static List<Category> GetCategories(bool? state = true)
        //public static List<Category> GetCategories(bool state )
        {
            var categoryBLL = new CategoryBLL();

            ListCategories = categoryBLL.GetCategories(state);

            return ListCategories;
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void EditingCategory(int id, string description)
        {
            try
            {
                var categoryBLL = new CategoryBLL();

                categoryBLL.EditCategory(id, description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool DeletingCategory(int eid)
        {
            try
            {
                var categoryBLL = new CategoryBLL();
                return categoryBLL.DeleteCategory(eid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}