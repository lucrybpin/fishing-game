using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISliderBar : MonoBehaviour
{
    [SerializeField] RectTransform fill;
    [SerializeField] WatchableFloat currentValue;
    [SerializeField] WatchableFloat maxValue;
    [SerializeField] TMP_Text text;

    private void LateUpdate ()
    {
        Vector3 currentScale = fill.localScale;
        float proportion = currentValue.Value / maxValue.Value;
        fill.localScale = new Vector3( proportion, currentScale.y, currentScale.z );
        text.text = $"[Line] [{currentValue.Value.ToString("F")}/{maxValue.Value}]";
    }
}
