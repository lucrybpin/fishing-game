using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] DataManager dataManager;

    public DataManager DataManager { get => dataManager; }

    private void Start ()
    {
        dataManager = GetComponent<DataManager>();
    }

    public void AddCoin (int amount)
    {
        if (amount <= 0)
        {
            Debug.Log( "Trying to add negative amount of coins" );
            return;
        }
        dataManager.PlayerCoins = dataManager.PlayerCoins + amount;
    }

    public void SetLineMax (float newLineMax)
    {
        if (newLineMax <= 0)
        {
            Debug.Log( "Trying to add negative line range" );
            return;
        }
        dataManager.LineMax = newLineMax;
    }
}
