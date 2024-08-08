using UnityEngine;

public class PoolObjectManager : BaseModule, IPoolObjectManager
{
    public override void Notify(string message)
    {
        if (message == "GameStarted")
        {
            Debug.Log("Pool Object Manager: Game Started");
        }
    }

    public GameObject GetObject(string poolKey)
    {
        throw new System.NotImplementedException();
    }


    public void ReturnObject(string poolKey, GameObject obj)
    {

    }

}

