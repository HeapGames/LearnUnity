using System.Collections.Generic;

public class ConcreteMediator : IMediator
{
    private List<IModule> _modules = new List<IModule>();

    public void RegisterModule(IModule module)
    {
        if (!_modules.Contains(module))
        {
            _modules.Add(module);
            module.SetMediator(this);
        }
    }

    public void Notify(object sender, string ev)
    {
        foreach (var module in _modules)
        {
            if (module != sender)
            {
                module.Notify(ev);
            }
        }
    }
}

