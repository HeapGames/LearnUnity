using UnityEngine;

public class UIManager : BaseModule, IUIManager
{
    public override void Notify(string message)
    {
        if (message == "GameStarted")
        {
            Debug.Log("UI Manager: Game Started");
        }
    }

    public void HideUI()
    {

    }

    public void ShowUI()
    {

    }

}

