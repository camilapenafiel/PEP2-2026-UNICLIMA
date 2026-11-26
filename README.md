# UNICLIMA METRICS (PROYECTO_PR_BD_PE)

## Nombre del proyecto
**UNICLIMA METRICS**

Sistema IoT de monitoreo meteorologico local, analisis estadistico y pronostico para el campus de la Universidad Privada Franz Tamayo (UNIFRANZ).

## Problema
Las aplicaciones meteorologicas convencionales pueden presentar datos poco precisos para una ubicacion especifica cuando utilizan informacion proveniente de estaciones o satelites alejados.

En el campus de UNIFRANZ existe la necesidad de contar con mediciones climaticas locales de temperatura, humedad, presion barometrica, precipitacion y radiacion UV, ademas de informacion historica y alertas.

## Proposito
Desarrollar una estacion meteorologica IoT de bajo costo que permita obtener informacion climatica directamente del entorno del campus de UNIFRANZ, almacenar los datos y presentarlos de forma clara para facilitar su consulta, analisis y uso didactico.

## Usuarios
- Administrador: administracion de estaciones, usuarios y funciones administrativas.
- Investigador / Usuario de Consulta: consulta de informacion climatica, historica, estadistica y reportes.
- Personal y estudiantes del campus: visualizacion de las condiciones climaticas locales y pronosticos.

## Objetivo
Implementar una estacion meteorologica IoT automatizada basada en hardware y un ESP32 para recopilar datos climaticos locales, almacenarlos en SQL Server, generar analisis, pronosticos y alertas mediante reglas y modelos del proyecto, y presentar los resultados mediante una aplicacion de escritorio en C# Windows Forms.

## Descripcion general
UNICLIMA METRICS contempla una estacion meteorologica de bajo costo construida alrededor de un ESP32 con sensores ambientales (temperatura, humedad, presion, precipitacion y radiacion UV), comunicacion via Wi-Fi / HTTP y persistencia en SQL Server.

### Funcionalidades implementadas
- Monitoreo por estacion (Form1Principal): Visualizacion de temperatura ambiente actual, humedad, condicion climatica, valores maximos y minimos del dia y pronostico de proximas horas.
- Metricas historicas y analisis estadistico (Form4Metricas): Graficas dinamicas con LiveCharts2 y resumenes estadisticos y probabilisticos (rango habitual promedio +- desviacion estandar, promedio muestral, minimos/maximos y probabilidad empirica de superar umbrales como calor >= 28 C y humedad >= 70%).
- Pronostico de series de tiempo (CN_Pronostico): Prediccion de temperatura y humedad mediante ML.NET (ForecastBySsa).
- Reportes y gestion (Form9Reportes, Form11MiPerfil): Modulo de reportes RDLC conectados a SQL Server, gestion de perfil y administracion del sistema.

## Documentación de Probabilidad y Estadística

El componente estadístico del sistema se documenta en [Aplicación de Probabilidad y Estadística](docs/probabilidad-estadistica.md). Incluye el tipo de estudio, población y muestra operativa, fuente de datos, medidas descriptivas, cálculo de frecuencias empíricas, pronóstico de series temporales y alcance de la implementación actual.

## Tecnologias utilizadas
- Lenguaje y framework: C#, Windows Forms (.NET) en arquitectura por capas.
- Base de datos: Microsoft SQL Server.
- Machine Learning y graficos: ML.NET (TimeSeries), LiveCharts2 / SkiaSharp.
- Reportes y hardware: RDLC y estaciones con ESP32 / sensores ambientales.

## Integrantes
- Camila Raquel Choque Penafiel - Grupo: UNICLIMA METRICS.
- Jose Carlos Trujillo Soliz - Grupo: Paralelo 3.

## Estado actual y avance
Avance funcional cercano al 80% del proyecto: aplicacion de escritorio en C# Windows Forms conectada a SQL Server, visualizacion por estacion, graficas historicas, resumen estadistico y probabilistico en Form4Metricas, modulo de pronostico con ML.NET, reportes RDLC y evidencias del sistema. Quedan pendientes ampliaciones estadisticas avanzadas y ajustes finales de integracion y pulido.

## Organizacion del repositorio
- src/: codigo fuente de la aplicacion y componentes del proyecto.
- database/: scripts y estructura de base de datos.
- docs/ y Evidencias/: documentacion y capturas de pantalla del funcionamiento del sistema.
- resources/, tests/, EQUIPO/ y .github/: recursos, pruebas, informacion del equipo y configuracion del repositorio.

## Metodologia
El proyecto utiliza Scrum, contemplando refinamiento, planificacion de Sprint, construccion, revision y retrospectiva.

## Instrucciones de ejecucion
1. Clonar el repositorio publico desde GitHub.
2. Configurar la base de datos en SQL Server y verificar la cadena de conexion en la capa de datos (CapaDatos/Conexion.cs).
3. Abrir la solucion del proyecto en Visual Studio.
4. Restaurar paquetes NuGet si es necesario y ejecutar la aplicacion (F5).

## Evidencias del funcionamiento
Las capturas de pantalla del sistema en ejecución se encuentran en [Evidencias](Evidencias/README.md), donde están organizadas y descritas por módulo.