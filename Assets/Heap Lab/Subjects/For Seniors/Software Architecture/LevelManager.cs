using UnityEngine;

public class LevelManager : BaseModule, ILevelManager
{
    public override void Notify(string message)
    {
        if (message == "GameStarted")
        {
            Debug.Log("Level Manager: Game Started");
        }
    }
    public void LoadLevel(int levelIndex)
    {

    }

    public void UnloadLevel(int levelIndex)
    {

    }

}

