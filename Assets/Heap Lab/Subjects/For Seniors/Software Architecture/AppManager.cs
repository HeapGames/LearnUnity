using System.Collections;
using UnityEngine;

public sealed class AppManager : MonoBehaviour
{
    private IAppState _currentState;
    private ConcreteMediator _mediator;
    private IModule[] _modules;

    void Awake()
    {
        _mediator = new ConcreteMediator();
        _modules = GetComponentsInChildren<IModule>();

        foreach (var module in _modules)
        {
            _mediator.RegisterModule(module);
        }
    }

    public void SetState(IAppState newState)
    {
        _currentState?.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    void Update()
    {
        _currentState?.UpdateState(this);
    }
}


public interface IGameManager
{
    void Initialize();
    void StartGame();
    void EndGame();
}

public interface ILevelManager
{
    void LoadLevel(int levelIndex);
    void UnloadLevel(int levelIndex);
}

public interface IUIManager
{
    void ShowUI();
    void HideUI();
}

public interface IPoolObjectManager
{
    GameObject GetObject(string poolKey);
    void ReturnObject(string poolKey, GameObject obj);
}


