using TMPro;
using UnityEngine;

public class TextRenderer : MonoBehaviour
{
    [SerializeField] private TextData _textData;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.font = _textData.Font;
    }
}
