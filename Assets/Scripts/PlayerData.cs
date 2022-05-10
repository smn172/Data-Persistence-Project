using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData istance;

    public string playerName;
    public int playerScore;

    private void Awake()
    {
        if (istance == null)
        {
            istance = this;
        }
        else if (istance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
