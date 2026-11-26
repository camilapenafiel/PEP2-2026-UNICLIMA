# Aplicación de Probabilidad y Estadística — UNICLIMA METRICS

## 1. Propósito del componente estadístico

El componente estadístico de UNICLIMA METRICS transforma las mediciones ambientales almacenadas en la base de datos en resúmenes que ayudan a interpretar el comportamiento reciente de la temperatura y la humedad. Complementa las gráficas históricas y el módulo de pronóstico.

La implementación revisada se encuentra principalmente en `PROYECTO_PR_BD_PE/Form4Metricas.cs`. El acceso al historial se realiza mediante `CapaDatos/CD_Lectura.cs`, y el pronóstico se implementa en `CapaNegocio/CN_Pronostico.cs`.

## 2. Tipo de estudio y análisis

- **Enfoque:** cuantitativo, porque trabaja con mediciones numéricas de variables ambientales.
- **Diseño:** observacional, ya que el sistema registra y analiza mediciones sin intervenir experimentalmente sobre las condiciones ambientales.
- **Alcance:** descriptivo y predictivo. Es descriptivo al resumir las mediciones históricas y predictivo mediante el módulo de series temporales.
- **Unidad de análisis:** registros de mediciones ambientales asociados a una estación y a una fecha/hora.

## 3. Población y muestra

- **Población de interés:** las mediciones ambientales registradas por las estaciones que forman parte del sistema UNICLIMA durante el periodo de operación.
- **Muestra utilizada en el módulo Form4Metricas:** el código consulta el historial de la estación con identificador `1`, agrupa las mediciones por hora y selecciona un registro cada 12 posiciones. Después conserva como máximo los 15 registros más recientes de esa lista filtrada.
- **Tamaño de muestra (`n`):** depende de la cantidad de registros que devuelve la consulta y de los datos disponibles. Por tanto, no se fija aquí un número universal; el cálculo se realiza con la cantidad efectiva de valores válidos que recibe el resumen estadístico.
- **Método de selección:** selección no probabilística por disponibilidad y criterio operativo: estación consultada, historial existente y filtrado temporal aplicado por el código.

> **Alcance que debe tenerse en cuenta:** la implementación actual de `Form4Metricas` no representa necesariamente todas las estaciones ni todos los registros históricos. Para describir un análisis concreto se debe indicar la estación y el periodo realmente consultados.

## 4. Fuentes e instrumentos de recolección de datos

La fuente de información del análisis son los registros almacenados en Microsoft SQL Server. En el código revisado, `CD_Lectura.ObtenerHistorialParaML(int idEstacion)` consulta las tablas `mediciones` y `sensores`, agrupa los datos por hora y obtiene temperatura y humedad para la estación indicada.

El proyecto contempla una estación meteorológica IoT basada en ESP32. Los valores analizados por el módulo estadístico proceden de los registros disponibles en la base de datos; no se utilizan encuestas ni entrevistas para este componente.

## 5. Técnicas de procesamiento y conceptos aplicados

### 5.1. Estadística descriptiva

Para cada serie numérica recibida por el resumen se calculan:

- **Media muestral:** promedio de los valores observados.

  \[
  \bar{x}=\frac{1}{n}\sum_{i=1}^{n}x_i
  \]

- **Mínimo y máximo:** menor y mayor valor observado en la muestra.
- **Desviación estándar muestral:** mide la dispersión respecto de la media. El código utiliza el divisor \(n-1\) cuando hay más de una observación.

  \[
  s=\sqrt{\frac{\sum_{i=1}^{n}(x_i-\bar{x})^2}{n-1}}
  \]

- **Intervalo de referencia descriptivo:** se calcula como \(\bar{x}-s\) a \(\bar{x}+s\). En la interfaz se presenta como un rango habitual orientativo; no debe interpretarse como un intervalo de confianza ni como una garantía de que todos los valores normales deban estar dentro de él.

### 5.2. Probabilidad empírica o frecuencia relativa

El sistema estima la frecuencia observada de superar ciertos umbrales en los valores recibidos:

\[
P_{emp}(A)=\frac{\text{número de observaciones que cumplen }A}{n}
\]

En el código de `Form4Metricas` se utilizan estos criterios:

- **Temperatura alta:** temperatura mayor o igual a \(28\ ^\circ C\).
- **Humedad alta:** humedad mayor o igual a \(70\%\).

El resultado se expresa como porcentaje de los registros considerados. Es una estimación empírica basada en la muestra consultada, no una probabilidad teórica ni una predicción meteorológica.

### 5.3. Pronóstico de series temporales

El proyecto contiene la clase `CN_Pronostico`, que utiliza ML.NET y el método `ForecastBySsa` para generar pronósticos de temperatura y humedad a partir de un historial. El horizonte se establece en horas mediante el parámetro `diasAPredecir * 24`.

## 6. Visualización e interpretación

El formulario `Form4Metricas` utiliza LiveCharts2 para mostrar series de temperatura, humedad, índice UV y presión. El resumen estadístico y probabilístico se actualiza según la métrica seleccionada.

La interpretación debe considerar la naturaleza de los datos que actualmente usa el código:

- Para **temperatura y humedad**, el formulario toma valores del historial consultado y calcula media, mínimo, máximo, desviación estándar, rango \(\bar{x}\pm s\) y frecuencia de superación del umbral correspondiente.
- En la versión revisada, las series mostradas para **índice UV** y **presión** se generan con valores constantes (4 y 1013 hPa, respectivamente) dentro de `Form4Metricas`. Por ello, no deben presentarse como mediciones variables obtenidas de sensores ni como resultados de un análisis estadístico real de esas dos variables hasta que se conecten a datos registrados.
- El pronóstico de ML.NET es un componente separado del resumen descriptivo de `Form4Metricas`.

## 7. Justificación

Las mediciones locales permiten estudiar las condiciones ambientales del entorno donde se encuentra instalada la estación. Al resumir temperatura y humedad mediante medidas descriptivas y frecuencias empíricas, UNICLIMA METRICS facilita reconocer niveles observados, variabilidad y frecuencia de superación de umbrales definidos por el proyecto. El módulo de pronóstico complementa este análisis al estimar comportamientos futuros a partir de series históricas.

De esta manera, el sistema busca convertir registros numéricos almacenados en SQL Server en información comprensible para la consulta y el seguimiento ambiental.

## 8. Archivos del proyecto relacionados

- `PROYECTO_PR_BD_PE/Form4Metricas.cs`: cálculo del resumen descriptivo y de las frecuencias empíricas; actualización de gráficas.
- `PROYECTO_PR_BD_PE/CapaDatos/CD_Lectura.cs`: consulta y agrupación horaria del historial de temperatura y humedad.
- `PROYECTO_PR_BD_PE/CapaNegocio/CN_Pronostico.cs`: generación de pronósticos mediante ML.NET (`ForecastBySsa`).

## 9. Aspectos pendientes de fortalecer

Para ampliar y hacer más completo el componente estadístico se recomienda:

1. Permitir seleccionar la estación y el intervalo de fechas desde la interfaz, y documentar esos filtros en cada análisis.
2. Mostrar el tamaño de muestra efectivo (`n`) y el periodo exacto utilizado en cada cálculo.
3. Conectar las variables de presión e índice UV a mediciones reales de la base de datos antes de presentar sus gráficas como datos observados.
4. Evaluar si el muestreo de un registro cada 12 posiciones es adecuado o si conviene analizar todos los registros válidos del periodo.
5. Validar y tratar explícitamente valores faltantes o inválidos; actualmente la consulta convierte algunos valores nulos de temperatura o humedad a cero.
6. Documentar y evaluar el desempeño de los pronósticos comparando predicciones con observaciones posteriores.

---

**Nota de rigor:** esta documentación describe el comportamiento que se observa en los archivos fuente revisados del repositorio. No afirma un tamaño de muestra fijo, un periodo específico, sensores concretos ni resultados numéricos que no estén demostrados por el código o por una consulta reproducible.
