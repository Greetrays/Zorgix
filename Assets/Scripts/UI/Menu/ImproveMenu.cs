using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]

public class ImproveMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items;
    [SerializeField] private MenuLoader _mainMenu;
    
    private CanvasGroup _improveMenu;

    public event UnityAction ClosedMenu;

    private void OnEnable()
    {
        _mainMenu.OpenedImproveMenu += OnClickOpenButton;
    }

    private void OnDisable()
    {
        _mainMenu.OpenedImproveMenu -= OnClickOpenButton;
    }

    private void Start()
    {
        _improveMenu = GetComponent<CanvasGroup>();
    }

    public void OnClickExitButton()
    {
        _improveMenu.alpha = 0;
        _improveMenu.blocksRaycasts = false;
        _improveMenu.interactable = false;
        ClosedMenu?.Invoke();
    }

    public void OnClickOpenButton()
    {
        _improveMenu.alpha = 1;
        _improveMenu.interactable = true;
        _improveMenu.blocksRaycasts = true;
    }
}
