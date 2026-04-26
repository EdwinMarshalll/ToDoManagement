namespace ToDoManagement.Application.Utilities.Mediator;

/// <summary>
/// Define una solicitud que regresa una respuesta del tipo especificado.
/// </summary>
/// <remarks>Implementa esta interfaz para representar una solicitud que puede ser manejada para reproducir una respuesta. Esto es
/// comunmente usado en patrones de mensajes request/response.</remarks>
/// <typeparam name="TResponse">El tipo de la respuesta regresada por la solicitud.</typeparam>
public interface IRequest<TResponse>
{

}

/// <summary>
/// Define una solicitud que no regresa nada
/// </summary>
public interface IRequest
{

}