using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private List<UpgradeObject> _upgradeObjects;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Transform _container;
   // [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private UpgradeView _template;

    private void Start()
    {
      //  _money.text = _playerMoney.Money.ToString();

        foreach (var item in _upgradeObjects)
        {
            AddItem(item);
        }
    }

    private void AddItem(UpgradeObject upgradeObject)
    {
        var item = Instantiate(_template, _container);
        item.Render(upgradeObject);
    }
}
