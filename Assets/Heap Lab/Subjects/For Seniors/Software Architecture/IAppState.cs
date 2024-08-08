public interface IAppState
{
    void EnterState(AppManager appManager);
    void UpdateState(AppManager appManager);
    void ExitState(AppManager appManager);
}

