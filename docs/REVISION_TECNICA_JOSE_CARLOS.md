# Revisión técnica del proyecto UNICLIMA METRICS

**Responsable de la revisión:** José Carlos Trujillo Soliz  
**Fecha:** 21 de noviembre de 2026  
**Repositorio revisado:** [PEP2-2026-UNICLIMA](https://github.com/camilapenafiel/PEP2-2026-UNICLIMA)

## 1. Objetivo de la revisión

Revisar componentes del repositorio para identificar cómo se obtienen y presentan los datos meteorológicos, reconocer aspectos que requieren atención y proponer mejoras para la siguiente etapa de desarrollo.

Esta revisión es documental y estática: se inspeccionó el código fuente disponible en GitHub. No representa una ejecución de pruebas en un equipo ni una validación física de los sensores.

## 2. Archivos revisados

- `README.md`: descripción general, tecnologías, funcionalidades y organización del proyecto.
- `PROYECTO_PR_BD_PE/Form4Metricas.cs`: carga del historial, presentación de gráficas y cálculo de resúmenes estadísticos.
- `PROYECTO_PR_BD_PE/CapaDatos/CD_Lectura.cs`: consultas para recuperar lecturas actuales e historial agrupado por hora.
- `PROYECTO_PR_BD_PE/CapaDatos/Conexion.cs`: configuración de conexión con SQL Server. Por seguridad, no se reproducen aquí datos de acceso.

## 3. Observaciones técnicas

### 3.1 Lenguaje y arquitectura

El proyecto utiliza C# con Windows Forms y organiza parte de su lógica en capas. En los archivos revisados se observa la separación entre presentación (`Form4Metricas`), acceso a datos (`CD_Lectura`) y configuración de conexión (`Conexion`).

### 3.2 Base de datos y recuperación de información

En `CD_Lectura.cs`, el método `ObtenerHistorialParaML(int idEstacion)` consulta las tablas `mediciones` y `sensores`, filtra por estación y agrupa las lecturas por hora. La consulta obtiene temperatura y humedad mediante los identificadores de variable utilizados en el código.

La consulta ordena los resultados cronológicamente. Cuando una variable no tiene valor para una hora, el código convierte el valor nulo a cero. Se recomienda revisar este tratamiento, porque cero puede interpretarse como una medición real y afectar gráficas, promedios y pronósticos. Una mejora sería conservar la ausencia de dato y definir una política explícita de validación o imputación.

### 3.3 Métricas y análisis estadístico

En `Form4Metricas.cs` se observan las siguientes operaciones:

- Carga del historial de una estación.
- Selección de registros mediante saltos de 12 posiciones.
- Presentación de temperatura y humedad en gráficas.
- Cálculo de promedio, mínimo, máximo y desviación estándar muestral.
- Estimación de frecuencia porcentual por encima de umbrales de temperatura y humedad.

**Aspecto por mejorar:** el salto de 12 posiciones no garantiza por sí mismo una separación temporal de 12 horas. La consulta agrupa por hora, pero si existen horas sin registros, doce filas pueden abarcar un periodo mayor. Se recomienda seleccionar por fecha y hora o documentar claramente el criterio de muestreo.

### 3.4 Variables UV y presión

En la versión revisada de `Form4Metricas.cs`, el índice UV se asigna con un valor fijo y la presión atmosférica también se representa con un valor fijo. Por ello, las gráficas y los textos de esas dos variables no reflejan una serie de mediciones obtenidas desde la base de datos.

Se recomienda conectar estas variables con sus registros reales antes de presentarlas como datos medidos. Mientras tanto, la interfaz debería identificarlas como valores de referencia o datos demostrativos.

### 3.5 Seguridad de la conexión

Durante la revisión de `Conexion.cs` se identificó que la cadena de conexión incluye credenciales directamente en el código fuente. Esto representa un riesgo si el repositorio es accesible públicamente o si el código se comparte.

**Acciones recomendadas con prioridad:**

1. Cambiar o revocar las credenciales que estuvieron expuestas.
2. Evitar guardar contraseñas en archivos versionados.
3. Leer la configuración desde variables de entorno, un archivo local excluido de Git o un gestor de secretos.
4. Revisar el historial del repositorio y los permisos de acceso. Eliminar el secreto del archivo actual no sustituye la rotación de las credenciales.

No se incluyen valores de usuario, contraseña ni otros datos sensibles en este informe.

## 4. Recomendaciones priorizadas

| Prioridad | Recomendación | Motivo |
|---|---|---|
| Crítica | Rotar las credenciales expuestas y externalizar la configuración | Proteger el acceso a SQL Server |
| Alta | Obtener UV y presión desde mediciones reales | Evitar presentar valores fijos como lecturas del sensor |
| Alta | Tratar explícitamente los datos faltantes | Evitar que los ceros artificiales distorsionen resultados |
| Media | Ajustar el muestreo del historial usando marcas de tiempo | Mantener intervalos temporales consistentes |
| Media | Probar los cálculos estadísticos con datos vacíos, incompletos y valores extremos | Mejorar la confiabilidad de los resultados |

## 5. Estado de la revisión

La revisión permitió identificar la ruta de recuperación de datos, el cálculo de métricas y varios puntos que requieren validación o mejora. Los hallazgos anteriores se basan en la lectura del código fuente y deben contrastarse con pruebas de ejecución y con el comportamiento de la estación física.

No se afirma que las recomendaciones estén implementadas ni que se hayan ejecutado pruebas funcionales. Este documento registra el análisis realizado y deja una base concreta para el trabajo posterior.

## 6. Aporte realizado

Se realizó una revisión del README y de los componentes de métricas y acceso a datos, se identificaron riesgos de seguridad y aspectos de calidad de información, y se documentaron recomendaciones técnicas priorizadas para continuar el desarrollo de UNICLIMA METRICS.

**Responsable:** José Carlos Trujillo Soliz
