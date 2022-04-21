using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private float _delayBeetwenAddMoney;
    [SerializeField] private PlayerHealth _player;

    [SerializeField] private int _moneyPerLevel;

    private int _money;
    private float _elepsedTime;
    private bool _playerIsAlife;

    public event UnityAction<int> Replenishment;

    public int Money => _money;
    public int MoneyPerLevel => _moneyPerLevel;

    private void OnEnable()
    {
        _player.Dying += OnDying;
    }

    private void Start()
    {
        _playerIsAlife = true;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
    }

    private void Update()
    {
        if (_playerIsAlife)
        {
            _elepsedTime += Time.deltaTime;

            if (_elepsedTime >= _delayBeetwenAddMoney)
            {
                _moneyPerLevel++;
                Replenishment?.Invoke(_moneyPerLevel);
                _elepsedTime = 0;
            }
        }
    }

    private void OnDying()
    {
        _money += _moneyPerLevel;
        _playerIsAlife = false;
    }
}
