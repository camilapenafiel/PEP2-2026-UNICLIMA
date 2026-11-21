using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System.Collections.Generic;
using PROYECTO_PR_BD_PE.CapaEntidades;

namespace PROYECTO_PR_BD_PE.CapaNegocio
{
    public class CN_Pronostico
    {
        public PrediccionClima GenerarPronostico(List<DatosClimaHistorico> historial, int diasAPredecir)
        {
            MLContext mlContext = new MLContext();
            int horasHorizonte = diasAPredecir * 24;

            IDataView dataView = mlContext.Data.LoadFromEnumerable(historial);

            // 1. ENTRENAMIENTO DE TEMPERATURA (Usando PrediccionTemp)
            var pipelineTemp = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(PrediccionTemp.PronosticoTemperatura),
                inputColumnName: nameof(DatosClimaHistorico.Temperatura),
                windowSize: 24,
                seriesLength: historial.Count,
                trainSize: historial.Count,
                horizon: horasHorizonte);

            var modeloTemp = pipelineTemp.Fit(dataView);
            var motorTemp = modeloTemp.CreateTimeSeriesEngine<DatosClimaHistorico, PrediccionTemp>(mlContext);
            var prediccionTemp = motorTemp.Predict();

            // 2. ENTRENAMIENTO DE HUMEDAD (Usando PrediccionHum)
            var pipelineHum = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(PrediccionHum.PronosticoHumedad),
                inputColumnName: nameof(DatosClimaHistorico.Humedad),
                windowSize: 24,
                seriesLength: historial.Count,
                trainSize: historial.Count,
                horizon: horasHorizonte);

            var modeloHum = pipelineHum.Fit(dataView);
            var motorHum = modeloHum.CreateTimeSeriesEngine<DatosClimaHistorico, PrediccionHum>(mlContext);
            var prediccionHum = motorHum.Predict();

            // 3. RETORNAR RESULTADOS COMBINADOS
            return new PrediccionClima
            {
                PronosticoTemperatura = prediccionTemp.PronosticoTemperatura,
                PronosticoHumedad = prediccionHum.PronosticoHumedad
            };
        }
    }
}