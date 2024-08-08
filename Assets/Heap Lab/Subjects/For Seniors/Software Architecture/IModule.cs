public interface IModule
{
    void SetMediator(IMediator mediator);
    void Notify(string message);
}

