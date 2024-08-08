public interface IMediator
{
    void RegisterModule(IModule module);
    void Notify(object sender, string ev);
}

