namespace ToDoManagement.Application.Utilities.Mediator;

/// <summary>
/// Define un manejador para procesar una solicitud especifica y devolver una respuesta tipada.
/// </summary>
/// <typeparam name="TRequest">
/// Tipo de solicitud que se va a procesar. Debe implementar <see cref="IRequest{TResponse}"/>.
/// </typeparam>
/// <typeparam name="TResponse">
/// Tipo de respuesta que devolvera el manejador.
/// </typeparam>
public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Procesa la solicitud recibida y devuelve el resultado de forma asincrona.
    /// </summary>
    /// <param name="request">La solicitud que contiene los datos de entrada.</param>
    /// <returns>Una tarea que contiene la respuesta generada por el manejador.</returns>
    Task<TResponse> Handle(TRequest request);
}
