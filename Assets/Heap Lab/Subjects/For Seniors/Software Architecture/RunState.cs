using UnityEngine;

public class RunState : IAppState
{
    public void EnterState(AppManager appManager)
    {
        Debug.Log("Entering Run State");
    }

    public void UpdateState(AppManager appManager)
    {
        // Run işlemleri
    }

    public void ExitState(AppManager appManager)
    {
        Debug.Log("Exiting Run State");
    }
}

