using UnityEngine;

public class PlayState : IAppState
{
    public void EnterState(AppManager appManager)
    {
        Debug.Log("Entering Play State");
    }

    public void UpdateState(AppManager appManager)
    {
        // Play işlemleri
    }

    public void ExitState(AppManager appManager)
    {
        Debug.Log("Exiting Play State");
    }
}

