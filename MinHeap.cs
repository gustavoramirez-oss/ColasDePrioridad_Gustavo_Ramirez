using System.Collections.Generic;

namespace ColasDePrioridad_Nombre_Apellido
{
    /// <summary>
    /// Implementación propia de un Min Heap para almacenar tickets.
    /// La prioridad menor representa una mayor urgencia.
    /// </summary>
    public class MinHeap
    {
        private readonly List<Ticket> elementos;

        public int Cantidad => elementos.Count;

        public MinHeap()
        {
            elementos = new List<Ticket>();
        }

        /// <summary>
        /// Inserta un ticket en la siguiente posición disponible
        /// y posteriormente ejecuta Bubble Up.
        /// </summary>
        public void Insertar(Ticket ticket)
        {
            elementos.Add(ticket);
            BubbleUp(elementos.Count - 1);
        }

        /// <summary>
        /// Devuelve el elemento de la raíz sin eliminarlo.
        /// </summary>
        public Ticket? Peek()
        {
            if (elementos.Count == 0)
                return null;

            return elementos[0];
        }

        /// <summary>
        /// Extrae el elemento mínimo, reemplaza la raíz con el último
        /// elemento y restaura el Heap mediante Bubble Down.
        /// </summary>
        public Ticket? ExtractMin()
        {
            if (elementos.Count == 0)
                return null;

            Ticket minimo = elementos[0];

            int ultimoIndice = elementos.Count - 1;
            Ticket ultimo = elementos[ultimoIndice];

            elementos.RemoveAt(ultimoIndice);

            if (elementos.Count > 0)
            {
                elementos[0] = ultimo;
                BubbleDown(0);
            }

            return minimo;
        }

        /// <summary>
        /// Busca un ticket por su código sin modificar el Heap.
        /// </summary>
        public Ticket? Buscar(string codigo)
        {
            foreach (Ticket ticket in elementos)
            {
                if (ticket.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                    return ticket;
            }

            return null;
        }

        /// <summary>
        /// Devuelve una copia de los elementos actuales del Heap.
        /// La copia evita modificar la estructura original.
        /// </summary>
        public List<Ticket> ObtenerElementos()
        {
            return new List<Ticket>(elementos);
        }

        /// <summary>
        /// Reorganiza el Heap hacia arriba después de una inserción.
        /// </summary>
        private void BubbleUp(int indice)
        {
            while (indice > 0)
            {
                int padre = (indice - 1) / 2;

                if (elementos[indice].Prioridad >= elementos[padre].Prioridad)
                    break;

                Intercambiar(indice, padre);
                indice = padre;
            }
        }

        /// <summary>
        /// Reorganiza el Heap hacia abajo después de una extracción.
        /// </summary>
        private void BubbleDown(int indice)
        {
            while (true)
            {
                int izquierdo = (indice * 2) + 1;
                int derecho = (indice * 2) + 2;
                int menor = indice;

                if (izquierdo < elementos.Count &&
                    elementos[izquierdo].Prioridad < elementos[menor].Prioridad)
                {
                    menor = izquierdo;
                }

                if (derecho < elementos.Count &&
                    elementos[derecho].Prioridad < elementos[menor].Prioridad)
                {
                    menor = derecho;
                }

                if (menor == indice)
                    break;

                Intercambiar(indice, menor);
                indice = menor;
            }
        }

        private void Intercambiar(int indiceA, int indiceB)
        {
            Ticket temporal = elementos[indiceA];
            elementos[indiceA] = elementos[indiceB];
            elementos[indiceB] = temporal;
        }
    }
}
