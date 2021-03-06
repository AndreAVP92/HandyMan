﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class User
    {
        public int        Id                { get; set; }
        public Photo      Photo             { get; set; } // Foto
        public string     Name              { get; set; }
        public int        Phone             { get; set; }
        public string     Email             { get; set; }
        public string     Password          { get; set; }
        public Address    Address           { get; set; }
        public string     StatusConecction  { get; set; } // Desconectado ó Conectado
        public DateTime   RegisterDate      { get; set; } // Fecha de Registro
        public Scores     Scores            { get; set; } // Valoración promedio 
        public Role       Role              { get; set; } // Rol que tomará el usuario
        public string     Condition         { get; set; } // Dado de baja, de alta, suspendido, en Revisión 

        // CONSTRUCTOR
        public User(Photo photo, string name, int phone, string email, string password, string status, DateTime registerdate, Scores scores, Role role, string condition)
        {
            Photo               = photo;
            Name                = name;
            Phone               = phone;
            Email               = email;
            Password            = password;
            StatusConecction    = status;
            RegisterDate        = registerdate;
            Scores              = scores;
            Role                = role;
            Condition           = condition;
        }

        public User(string name, string email, string password, DateTime registerdate, Role role, string condition)
        {
            Name            = name;
            Email           = email;
            Password        = password;
            RegisterDate    = registerdate;
            Role            = role;
            Condition       = condition;
        }

        public User(int id, Photo photo) 
        {
            Id      = id;
            Photo   = photo;
        }

        public User(int id, Scores score)
        {
            Id      = id;
            Scores  = score;
        }
    }      
}
