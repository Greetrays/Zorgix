using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private float _delayBeetwenAddMoney;
    [SerializeField] private PlayerHealth _player;

    private int _moneyPerLevel;

    private float _elepsedTime;
    private bool _playerIsAlife;

    public event UnityAction<int> Replenishment;
    public event UnityAction<int> Dying;

    private void OnEnable()
    {
        _player.Died += OnDying;
    }

    private void Start()
    {
        _playerIsAlife = true;
    }

    private void OnDisable()
    {
        _player.Died -= OnDying;
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
        Dying?.Invoke(_moneyPerLevel);
        _playerIsAlife = false;
    }
}
