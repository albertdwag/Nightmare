using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnValidate()
    {
        if (_text == null) _text.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateValue(float f)
    {
        _text.text = f.ToString();
    }
}
