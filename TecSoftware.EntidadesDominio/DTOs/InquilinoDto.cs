﻿using System;

namespace TecSoftware.EntidadesDominio
{
    public class InquilinoDto
    {
        public int InquilinoId { get; set; }
        public string Nombre { get; set; }
        public string Dominio { get; set; }
        public string PlanServicio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoInquilino Estado { get; set; }
    }
}
