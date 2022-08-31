using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIValueInt : MonoBehaviour
{
    [SerializeField] WatchableInt currentValue;
    [SerializeField] string prefix;
    [SerializeField] string posfix;
    [SerializeField] TMP_Text text;

    private void LateUpdate ()
    {
        text.text = $"{prefix}{currentValue.Value}{posfix}";
    }
}
