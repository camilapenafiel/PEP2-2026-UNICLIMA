namespace PROYECTO_PR_BD_PE.CapaEntidades
{
    public class EstacionMeteorologica
    {
        public int IdEstacion { get; set; }
        public string? Nombre { get; set; }
        public int IdUbicacion { get; set; }
        public string? Campus { get; set; } // Para mostrar el nombre de la sede en la grilla
    }
}