using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] WatchableInt watchableCoins;
    [SerializeField] WatchableInt watchableBucketcurrent;
    [SerializeField] WatchableInt watchableBucketMax;
    [SerializeField] WatchableFloat watchableLineCurrent;
    [SerializeField] WatchableFloat watchableLineMax;

    public int PlayerCoins
    {
        get { return watchableCoins.Value; }
        set { watchableCoins.Value = value; }
    }

    public int BucketCurrent
    {
        get { return watchableBucketcurrent.Value; }
        set { watchableBucketcurrent.Value = value; }
    }

    public int BucketMax
    {
        get { return watchableBucketMax.Value; }
        set { watchableBucketMax.Value = value; }
    }

    public float LineCurrent
    {
        get { return watchableLineCurrent.Value; }
        set { watchableLineCurrent.Value = value; }
    }

    public float LineMax
    {
        get { return watchableLineMax.Value; }
        set { watchableLineMax.Value = value; }
    }

}
