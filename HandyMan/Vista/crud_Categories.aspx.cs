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
                CategoryBLL categoryBLL = new CategoryBLL();

                categoryBLL.AddCategory(description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static List<Category> GetCategories()
        {
            CategoryBLL categoryBLL = new CategoryBLL();

            ListCategories = categoryBLL.GetCategories();

            return ListCategories;
        }

        //[WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        //public static void EditingCategory(int id, string description, bool state)
        //{
        //    try
        //    {
        //        CategoryBLL categoryBLL = new CategoryBLL();

        //        categoryBLL.EditCategory(id, description, state);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void DeletingCategory(int eid)
        {
            try
            {
                CategoryBLL categoryBLL = new CategoryBLL();
                categoryBLL.DeleteCategory(eid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}