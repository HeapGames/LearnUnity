using UnityEngine;

public class LoadingState : IAppState
{
    public void EnterState(AppManager appManager)
    {
        Debug.Log("Entering Loading State");
    }

    public void UpdateState(AppManager appManager)
    {
        // Loading işlemleri
    }

    public void ExitState(AppManager appManager)
    {
        Debug.Log("Exiting Loading State");
    }
}

