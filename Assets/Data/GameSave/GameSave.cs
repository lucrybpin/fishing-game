using System.Collections.Generic;

[System.Serializable]
public class GameSave {
    public int id;
    public int bucketCurrent;
    public int bucketMax;
    public List<FishSaveData> currentBucketFishes;
    public int coins;
    public int lineUpgradeLevel;
    public float lineCurrent;
    public float lineMax;
}
