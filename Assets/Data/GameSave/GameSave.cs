using System.Collections.Generic;

[System.Serializable]
public class GameSave {
    public int id;
    public int bucketLevel;
    public int bucketCurrent;
    public int bucketMax;
    public List<FishSaveData> currentBucketFishes;
    public int coins;
    public int lineLevel;
    public int sinkSpeedLevel;
    public float sinkSpeed;
    public float lineCurrent;
    public float lineMax;
}
