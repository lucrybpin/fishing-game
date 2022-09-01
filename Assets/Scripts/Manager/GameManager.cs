using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] DataManager dataManager;

    public DataManager DataManager { get => dataManager; }

    private void Awake ()
    {
        GamePresetsData.Setup();
    }

    private void Start ()
    {
        dataManager = GetComponent<DataManager>();
    }

    public void AddCoins (int amount)
    {
        if (amount < 0)
        {
            Debug.Log( "Trying to add negative amount of coins" );
            return;
        }
        dataManager.PlayerCoins = dataManager.PlayerCoins + amount;
    }

    public void SubtractCoins (int amount)
    {
        if (amount < 0)
        {
            Debug.Log( "Trying to subtract negative amount of coins" );
            return;
        }
        if (dataManager.PlayerCoins - amount < 0)
        {
            Debug.Log( "Trying to subtract amount greater than available coins" );
            return;
        }
        dataManager.PlayerCoins = dataManager.PlayerCoins - amount;
    }

    public void SetLineLevel(int newLevel)
    {
        if (newLevel < 0)
        {
            Debug.Log( "Trying to set negative line level" );
            return;
        }
        dataManager.LineLevel = newLevel;
        dataManager.LineMax = GamePresetsData.GetLineLimitByUpgradeLevel( newLevel );
    }

    public void SetBucketLevel (int newLevel)
    {
        if (newLevel < 0)
        {
            Debug.Log( "Trying to set negative line level" );
            return;
        }
        dataManager.BucketLevel = newLevel;
        dataManager.BucketMax = GamePresetsData.GetBucketSizeByUpgradeLevel( newLevel );
    }
}
