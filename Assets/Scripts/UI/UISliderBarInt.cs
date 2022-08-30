using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISliderBarInt : MonoBehaviour
{
    [SerializeField] RectTransform fill;
    [SerializeField] WatchableInt currentValue;
    [SerializeField] WatchableInt maxValue;
    [SerializeField] TMP_Text text;

    private void LateUpdate ()
    {
        Vector3 currentScale = fill.localScale;
        float proportion = currentValue.Value / maxValue.Value;
        fill.localScale = new Vector3( proportion, currentScale.y, currentScale.z );
        text.text = $"[Bucket] [{currentValue.Value}/{maxValue.Value}]";
    }
}
