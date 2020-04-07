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
    public partial class crud_SubCategories : System.Web.UI.Page
    {
        public static List<SubCategory> ListSubCategories { get; set; }
        public List<Category> ListCategories { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  //Evitamos el postback
            {
                var categoryBLL = new CategoryBLL();
                ListCategories = categoryBLL.GetCategories(true);
            }
        }

        //  Agregamos SubCategoría
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void AddingSubCategory(string description, int category)
        {
            try
            {              
                var subcategoryBLL = new SubCategoryBLL();
                var categoryBLL = new CategoryBLL();
     
                subcategoryBLL.AddSubCategory(description, category); //Agregamos subcategoría y vinculamos con categoria
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Listamos SubCategorías
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static List<SubCategory> GetSubCategories(bool? state = true)
        {
            var subcategoryBLL = new SubCategoryBLL();

            ListSubCategories = subcategoryBLL.GetSubCategories(state);

            return ListSubCategories;
        }

        // Editamos SubCategorías
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void EditingSubCategory(int id, string description)
        {
            try
            {
                var subcategoryBLL = new SubCategoryBLL();

                subcategoryBLL.EditSubCategory(id, description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Eliminamos SubCategorías
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
        //  Traemos las Categorías al DropDownList
        //[WebMethod]
        //public static List<ListItem> FillCategories()
        //{
        //    string query = "SELECT Id, Description FROM CATEGORIES WHERE Status=1";
        //    string dbconnection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(dbconnection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            List<ListItem> categories = new List<ListItem>();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    categories.Add(new ListItem
        //                    {
        //                        Value = sdr["Id"].ToString(),
        //                        Text = sdr["Description"].ToString()
        //                    });
        //                }
        //            }
        //            con.Close();
        //            return categories;
        //        }
        //    }
        //}
    }
}