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
    public partial class Payments : System.Web.UI.Page
    {
        public static List<Payment> ListPayments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void AddingPayment(string description)
        {
            try
            {
                var paymentBLL = new PaymentBLL();
                paymentBLL.AddPayment(description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static List<Payment> GetPayments(bool? state = true)
        {
            var paymentBLL = new PaymentBLL();

            ListPayments = paymentBLL.GetPayments(state);

            return ListPayments;
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static void EditingPayment(int id, string description, bool state)
        {
            try
            {
                var paymentBLL = new PaymentBLL();

                paymentBLL.EditPayment(id, description, state);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static bool DeletingPayment(int eid)
        {
            try
            {
                var paymentBLL = new PaymentBLL();
                return paymentBLL.DeletePayment(eid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}