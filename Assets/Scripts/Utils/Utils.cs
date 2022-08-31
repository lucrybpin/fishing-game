using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static T GetPrefabByName<T>(string prefabName) where T: class
    {
        return Resources.Load( "Prefabs/" + prefabName, typeof( T ) ) as T;
    }


}
