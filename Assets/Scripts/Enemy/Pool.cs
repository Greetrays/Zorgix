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

    protected void Init(List<GameObject> templates, int capacity)
    {
        _pool.Clear();
        _capacity = capacity;

        for(int i = 0; i < _capacity; i++)
        {
            var newObject = Instantiate(templates[Random.Range(0, templates.Count)], Container);
            newObject.SetActive(false);
            SetPlayer(newObject);
            _pool.Add(newObject);
        }       
    }

    protected void Init(List<GameObject> templates)
    {
        _pool.Clear();

        for (int i = 0; i < templates.Count; i++)
        {
            var newObject = Instantiate(templates[i], Container);
            newObject.SetActive(false);
            SetPlayer(newObject);
            _pool.Add(newObject);
        }      
    }

    protected bool TryGetObject(out GameObject gameObj)
    {
        gameObj = _pool.FirstOrDefault(o => o.activeSelf == false);

        return gameObj != null;
    }

    protected void TryDestroyObjects()
    {
        Vector3 disableMaxPoint = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 0));
        Vector3 disableMinPoint = Camera.main.ViewportToWorldPoint(new Vector2(-0.2f, 0));

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).transform.position.x >= disableMaxPoint.x || transform.GetChild(i).transform.position.x <= disableMinPoint.x || transform.GetChild(i).gameObject.activeSelf == false)
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
}
