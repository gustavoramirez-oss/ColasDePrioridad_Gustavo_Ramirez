namespace ColasDePrioridad_Nombre_Apellido
{
    /// <summary>
    /// Representa un ticket de soporte registrado en la cola de prioridad.
    /// </summary>
    public class Ticket
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }

        public Ticket(string codigo, string cliente, string descripcion, int prioridad)
        {
            Codigo = codigo;
            Cliente = cliente;
            Descripcion = descripcion;
            Prioridad = prioridad;
        }
    }
}
