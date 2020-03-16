using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Service
    {
        public int           Id             { get; set; }
        public User          Customer       { get; set; } // Cliente
        public User          Handyman       { get; set; } // Profesional o Handyman
        public string        Address        { get; set; } // Dirección
        public string        Description    { get; set; } // Describe el problema
        public double        Amount         { get; set; } // Presupuesto o Importe a pagar
        public DateTime      DateService    { get; set; } // Fecha que se solicitó el servicio
        public ServiceStatus ServiceStatus  { get; set; } // Estado en que se encuentra la solicitud de servicio
        public Payment       Payment        { get; set; } // Modo de Pago
        //public bool          State          { get; set; }

        //CONSTRUCTOR
        public Service (User customer, User handyman, string address, string description, double amount, DateTime dateService, ServiceStatus serviceStatus, Payment payment)
        {
            Customer = customer;
            Handyman = handyman;
            Address = address;
            Description = description;
            Amount = amount;
            DateService = dateService;
            ServiceStatus = serviceStatus;
            Payment = payment;
        }
    }
}
