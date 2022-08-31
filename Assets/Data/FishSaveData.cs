
using System;

[System.Serializable]
public class FishSaveData
{
    public Type type;
    public string typeName;

    public FishSaveData (Type type)
    {
        this.type = type;
        this.typeName = type.ToString();
    }
}
