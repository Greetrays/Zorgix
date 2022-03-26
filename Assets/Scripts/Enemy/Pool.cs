using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool : MonoBehaviour
{
    [Header("Пул")]
    [SerializeField] protected Transform Container;

    [SerializeField] private PlayerEnergyBarrier _player;

    private List<GameObject> _pool = new List<GameObject>();
    private int _capacity;

    protected void Init(List<SpawnObject> templates)
    {
        _pool.Clear();

        for (int i = 0; i < templates.Count; i++)
        {
            for (int j = 0; j < templates[i].Count; j++)
            {
                var newObject = Instantiate(templates[i].Template, Container);
                newObject.SetActive(false);
                SetPlayer(newObject);
                _pool.Add(newObject);

                if (newObject.TryGetComponent(out Enemy enemy))
                {
                    enemy.SetTarget(_player.gameObject.GetComponent<PlayerHealth>());
                }
            }
        }
    }

    protected bool TryGetObject(out GameObject gameObj)
    {
        var activeElements = _pool.Where(obj => obj.activeSelf == false).ToList();
        gameObj = activeElements.ElementAtOrDefault(Random.Range(0, activeElements.Count));
        return gameObj != null;
    }

    protected void TryDestroyObjects()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2(-0.2f, 0));

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).transform.position.x <= disablePoint.x || transform.GetChild(i).gameObject.activeSelf == false)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }

    protected bool TryGetRandomObject(out GameObject gameObj)
    {
        int randomIndex = Random.Range(0, _pool.Count);

        if (_pool[randomIndex].activeSelf == false)
        {
            gameObj = _pool[randomIndex];
        }
        else
        {
            gameObj = null;
        }

        return gameObj != null;
    }

    protected void DisableObject()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2 (-0.2f, 0));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x <= disablePoint.x)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    private void SetPlayer(GameObject obj)
    {
        if (obj.TryGetComponent(out ObjectMover objectMover))
        {
            objectMover.SetPlayer(_player);
        }
    }

    [System.Serializable]
    public class SpawnObject
    {
        [SerializeField] private GameObject _template;
        [SerializeField] private int _count;

        public GameObject Template => _template;
        public int Count => _count;
    }
}
