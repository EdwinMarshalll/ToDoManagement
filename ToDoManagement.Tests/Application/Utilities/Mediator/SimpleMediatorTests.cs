using FluentValidation;
using NSubstitute;
using ToDoManagement.Application.Exceptions;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Tests.Application.Utilities.Mediator;

public class SimpleMediatorTests
{
    public class FakeRequest : IRequest<string>{
        public required string Name { get; set; }
    }

    public class FakeHandler : IRequestHandler<FakeRequest, string>
    {
        public Task<string> Handle(FakeRequest request)
        {
            return Task.FromResult("Respuesta correcta");
        }
    }

    public class FakeValidatorRequest : AbstractValidator<FakeRequest>
    {
        public FakeValidatorRequest() {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    [Fact]
    public async Task Send_CallHandleMethod()
    {
        var request = new FakeRequest() { Name = "Nombre A"};
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
        var request = new FakeRequest() { Name = "Nombre A"};
        var useCaseMock = Substitute.For<IRequestHandler<FakeRequest, string>>();
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider.GetService(typeof(IRequestHandler<FakeRequest, string>)).Returns(null);

        var mediator = new SimpleMediator(serviceProvider);

        await Assert.ThrowsAsync<MediatorException>(async () =>
        {
            var result = await mediator.Send(request);
        });
    }

    [Fact]
    public async Task Send_InvalidCommand_ThrowsException()
    {
        var request = new FakeRequest() { Name = "" };
        var serviceProvider = Substitute.For<IServiceProvider>();
        var validator = new FakeValidatorRequest();

        serviceProvider.GetService(typeof(IValidator<FakeRequest>)).Returns(validator);

        var mediator = new SimpleMediator(serviceProvider);

        await Assert.ThrowsAsync<ApplicationValidationException>(async () =>
        {
            await mediator.Send(request);
        });
    }

}
