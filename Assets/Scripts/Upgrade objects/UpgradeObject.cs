using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeObject : MonoBehaviour
{
    [Header("Абстрактные характеристики")]
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _lable;
    [SerializeField] private int _level;
    [SerializeField] private int _price;
    [SerializeField] private int _markup;
    [SerializeField] private string _description;

    public Sprite Icon => _icon;
    public string Lable => _lable;
    public int Level => _level;
    public int Price => _price;
    public string Description => _description;

    private void OnValidate()
    {
        if (_level <= 0)
            _level = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth player))
        {
            gameObject.SetActive(false);
        }
    }

    protected abstract void Upgrade();
}
