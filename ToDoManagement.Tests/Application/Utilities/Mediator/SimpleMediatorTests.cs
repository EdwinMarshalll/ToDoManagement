using NSubstitute;
using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Tests.Application.Utilities.Mediator;

public class SimpleMediatorTests
{
    public class FakeRequest : IRequest<string>{}

    public class FakeHandler : IRequestHandler<FakeRequest, string>
    {
        public Task<string> Handle(FakeRequest request)
        {
            return Task.FromResult("Respuesta correcta");
        }
    }

    [Fact]
    public async Task Send_CallHandleMethod()
    {
        var request = new FakeRequest();
        var useCaseMock = Substitute.For<IRequestHandler<FakeRequest, string>>();
        var serviceProvider = Substitute.For<IServiceProvider>();

        serviceProvider.GetService(typeof(IRequestHandler<FakeRequest, string>)).Returns(useCaseMock);

        var mediator = new SimpleMediator(serviceProvider);

        var result = await mediator.Send(request);

        await useCaseMock.Received(1).Handle(request);
    }

    [Fact]
    public async Task Send_InvalidRequest_ThrowsException()
    {
        var request = new FakeRequest();
        var useCaseMock = Substitute.For<IRequestHandler<FakeRequest, string>>();
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider.GetService(typeof(IRequestHandler<FakeRequest, string>)).Returns(null);

        var mediator = new SimpleMediator(serviceProvider);

        await Assert.ThrowsAsync<MediatorException>(async () =>
        {
            var result = await mediator.Send(request);
        });
    }

}
