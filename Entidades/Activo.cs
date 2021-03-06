﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Steven Camacho
    /// 10/may/2019
    /// Clase para administrar la entidad de Activo
    /// </summary>
    public class Activo
    {
        int placa;
        string serie;
        string modelo;
        DateTime fechaCompraDT;
        String fechaCompra;
        string descripcion;
        bool isNotDeleted;

        public Activo() { }

        public int Placa { get => placa; set => placa = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public String FechaCompra { get => fechaCompra; set =>fechaCompra= value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool IsNotDeleted { get => isNotDeleted; set => isNotDeleted = value; }
        public DateTime FechaCompraDT { get => fechaCompraDT; set => fechaCompraDT = value; }
    }
}
