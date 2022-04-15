using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _description;

    public void Render(UpgradeObject upgradeObject)
    {
        _icon.sprite = upgradeObject.Icon;
        _lable.text = upgradeObject.Lable;
        _price.text = upgradeObject.Price.ToString();
        _level.text = upgradeObject.Level.ToString();
        _description.text = upgradeObject.Description;
    }
}
