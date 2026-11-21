using Microsoft.ML.Data;
using System;

namespace PROYECTO_PR_BD_PE.CapaEntidades
{
    // 1. Lo que entra (Pasado)
    public class DatosClimaHistorico
    {
        public DateTime FechaHora { get; set; }

        [LoadColumn(0)]
        public float Temperatura { get; set; }

        [LoadColumn(1)]
        public float Humedad { get; set; }
    }

    // 2. Lo que sale hacia la interfaz (Combinado)
    public class PrediccionClima
    {
        public float[]? PronosticoTemperatura { get; set; }
        public float[]? PronosticoHumedad { get; set; }
    }

    // --- NUEVO: Moldes estrictos individuales para ML.NET ---

    public class PrediccionTemp
    {
        public float[]? PronosticoTemperatura { get; set; }
    }

    public class PrediccionHum
    {
        public float[]? PronosticoHumedad { get; set; }
    }
}