using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewTextData", menuName = "Text data/Create text data", order = 51)]

public class TextData : ScriptableObject
{
    [SerializeField] private TMP_FontAsset _font;

    public TMP_FontAsset Font => _font;
}
