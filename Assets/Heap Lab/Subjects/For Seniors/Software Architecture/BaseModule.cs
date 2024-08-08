using UnityEngine;

public abstract class BaseModule : MonoBehaviour, IModule
{
    protected IMediator mediator;

    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void Notify(string message);
}

