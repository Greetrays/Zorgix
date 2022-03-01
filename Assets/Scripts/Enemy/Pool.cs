using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [Header("Пул")]
    [SerializeField] private int _capacity;
    [SerializeField] protected Transform Container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Init(List<GameObject> templates)
    {
        _pool.Clear();

        for(int i = 0; i < _capacity; i++)
        {
            var newObject = Instantiate(templates[Random.Range(0, templates.Count)], Container);
            newObject.SetActive(false);
            _pool.Add(newObject);
        }       
    }

    protected bool TryGetObject(out GameObject gameObject)
    {
        gameObject = _pool.FirstOrDefault(o => o.activeSelf == false);

        return gameObject != null;
    }

    protected void DisableObject()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2 (-0.5f, 0));

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
}
