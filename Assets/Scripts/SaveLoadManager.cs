using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney _score;

    private string _filePath;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}

[System.Serializable]
public class Save
{
    private int _money;

    public int Money => _money;

    public void SaveScore()
    {

    }
}
