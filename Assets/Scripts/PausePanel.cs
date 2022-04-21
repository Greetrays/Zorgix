using UnityEngine;
using IJunior.TypedScenes;

[RequireComponent(typeof(CanvasGroup))]

public class PausePanel : MonoBehaviour
{
    private CanvasGroup _panel;

    private void Start()
    {
        _panel = GetComponent<CanvasGroup>();
        Close();
    }

    public void Open()
    {
        _panel.alpha = 1;
        _panel.blocksRaycasts = true;
        _panel.interactable = true;
        Time.timeScale = 0;
    }

    public void Close()
    {
        _panel.alpha = 0;
        _panel.blocksRaycasts = false;
        _panel.interactable = false;
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        Menu.Load();
    }

    public void Continue()
    {
        Close();
    }
}
