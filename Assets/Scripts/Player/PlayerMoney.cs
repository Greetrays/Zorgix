using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private float _delayBeetwenAddMoney;

    [SerializeField] private int _money;
    private float _elepsedTime;

    public int Money => _money;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delayBeetwenAddMoney)
        {
            _money++;
            _elepsedTime = 0;
        }
    }
}
