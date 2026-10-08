# ColasDePrioridad_Nombre_Apellido

Laboratorio 4 - Cola de Prioridad con Min Heap en C#.

## Descripción

Aplicación de consola desarrollada en C# para administrar tickets de soporte utilizando una Cola de Prioridad implementada mediante un Min Heap propio.

La prioridad 1 es la más urgente y la prioridad 5 la menos urgente.

## Funcionalidades

1. Registrar Ticket
2. Mostrar Siguiente Ticket
3. Atender Ticket
4. Mostrar Cola de Prioridad
5. Buscar Ticket
6. Mostrar cantidad de Tickets
7. Salir

## Estructura

- `Program.cs`: menú y operaciones del sistema.
- `Ticket.cs`: modelo de datos de los tickets.
- `MinHeap.cs`: implementación propia del Min Heap.

## Requisitos

- .NET 8 SDK o compatible.
- No se utiliza `PriorityQueue`, `SortedSet` ni una estructura equivalente para administrar la cola.

## Ejecución

Desde la carpeta del proyecto:

```bash
dotnet run
```

## Formato de tickets

Los códigos deben utilizar el formato:

`TCK0001`

Ejemplos:

- TCK0001
- TCK0002
- TCK0003

## Prioridades

| Prioridad | Nivel |
|---|---|
| 1 | Crítica |
| 2 | Alta |
| 3 | Media |
| 4 | Baja |
| 5 | Muy Baja |

## Prueba recomendada

Registrar:

- TCK0001 - Cliente A - Prioridad 3
- TCK0002 - Cliente B - Prioridad 1
- TCK0003 - Cliente C - Prioridad 5
- TCK0004 - Cliente D - Prioridad 2

Al utilizar "Mostrar Siguiente Ticket", debe aparecer TCK0002, porque tiene prioridad 1.

Al utilizar "Atender Ticket", debe eliminarse TCK0002. Posteriormente debe atenderse TCK0004 y luego los demás según corresponda.

## Nota para la entrega

Cambiar `Nombre_Apellido` por el nombre y apellido del estudiante tanto en el nombre de la carpeta/proyecto como en el namespace si se desea mantener la nomenclatura exacta.
