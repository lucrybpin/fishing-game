using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] DataManager dataManager;
    [SerializeField] AudioManager audioManager;

    public DataManager DataManager { get => dataManager; }
    public AudioManager AudioManager { get => audioManager; }

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

    public async UniTask AddCoinsOverTime (int amount, float time)
    {
        float elapsedTime = 0f;
        int initialCoins = dataManager.PlayerCoins;
        int finalCoins = initialCoins + amount;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            dataManager.PlayerCoins = ( int ) Mathf.Lerp( initialCoins, finalCoins, elapsedTime / time );
            await UniTask.Yield();
        }
        dataManager.PlayerCoins = finalCoins;
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

    public void SetSinkSpeedLevel (int newLevel)
    {
        if (newLevel < 0)
        {
            Debug.Log( "Trying to set negative line level" );
            return;
        }
        dataManager.SinkSpeedLevel = newLevel;
        dataManager.SinkSpeed = GamePresetsData.GetSinkSpeedByUpgradeLevel( newLevel );
    }

    public void SetFloatLevel (int newLevel)
    {
        if (newLevel < 0)
        {
            Debug.Log( "Trying to set negative line level" );
            return;
        }
        dataManager.FloatSpeedLevel = newLevel;
        dataManager.FloatSpeed = GamePresetsData.GetFloatSpeedByUpgradeLevel( newLevel );
    }
}
