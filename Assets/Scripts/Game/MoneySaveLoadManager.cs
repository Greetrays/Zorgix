using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class MoneySaveLoadManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;

    //private BinaryFormatter _binaryFormatter = new BinaryFormatter();
    private Save _save = new Save();
    private string _filePath;

    private void OnEnable()
    {
        _playerMoney.Dying += SaveGame;
        LoadGame();
    }

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";
    }

    private void OnDisable()
    {
        _playerMoney.Dying -= SaveGame;
    }

    public void LoadGame()
    {
        if (File.Exists(_filePath) == false)
        {
            return;
        }

        BinaryFormatter _binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Open);
        _save = (Save)_binaryFormatter.Deserialize(fileStream);
        fileStream.Close();

        Debug.Log("Теперь денег: " + _save.Money);
    }

    private void SaveGame(int money)
    {
        BinaryFormatter _binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Create);
        _save.SaveMoney(money);
        _binaryFormatter.Serialize(fileStream, _save);
        fileStream.Close();
    }
}

[System.Serializable]
public class Save
{
    private int _money;

    public int Money => _money;

    public void SaveMoney(int playerMoney)
    {
        _money += playerMoney;
    }
}
