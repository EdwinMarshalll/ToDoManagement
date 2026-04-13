namespace ToDoManagement.Application.Utilities.Mediator;

/// <summary>
/// Define un mediador que envia solicitudes a su manejador correspondiente.
/// </summary>
/// <remarks>
/// Esta interfaz representa el punto de entrada para ejecutar solicitudes de la aplicacion
/// sin que quien la llama necesite saber que manejar las procesa.
/// </remarks>
public interface IMediator
{
    /// <summary>
    /// Envia una solicitud y devuelve su respuesta de forma asincrona.
    /// </summary>
    /// <typeparam name="TResponse">Tipo de respuesta que devolvera la solicitud</typeparam>
    /// <param name="request">La solicitud que se va a ejecutar.</param>
    /// <returns>Una Task que devuelve la respuesta generada por el manejador.</returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}
