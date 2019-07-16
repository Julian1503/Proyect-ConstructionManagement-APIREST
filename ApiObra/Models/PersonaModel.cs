﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class PersonaModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ApYNom => $"{Apellido} {Nombre}";
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public TipoSexo Sexo { get; set; }
    }
}
