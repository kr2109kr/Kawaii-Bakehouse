using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static SaveData saveData = new();

    [System.Serializable]
    public struct SaveData
    {
        public StationSaveData stationSaveData_0;
        public StationSaveData stationSaveData_1;
        public StationSaveData stationSaveData_2;
        public StationSaveData stationSaveData_3;
        public StationSaveData stationSaveData_4;
        public StationSaveData stationSaveData_5;
        public StationSaveData stationSaveData_6;

        public MoneySaveData moneySaveData;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }


    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    public static void Reset()
    {
        saveData = new();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }


    private static void HandleSaveData()
    {
        GameManager.Instance.Save(ref saveData.moneySaveData);
        GameManager.Instance.stations[0].Save(ref saveData.stationSaveData_0);
        GameManager.Instance.stations[1].Save(ref saveData.stationSaveData_1);
        GameManager.Instance.stations[2].Save(ref saveData.stationSaveData_2);
        GameManager.Instance.stations[3].Save(ref saveData.stationSaveData_3);
        GameManager.Instance.stations[4].Save(ref saveData.stationSaveData_4);
        GameManager.Instance.stations[5].Save(ref saveData.stationSaveData_5);
    }


    public static void HandleLoadData()
    {
        GameManager.Instance.Load(saveData.moneySaveData);
        GameManager.Instance.stations[0].Load(saveData.stationSaveData_0);
        GameManager.Instance.stations[1].Load(saveData.stationSaveData_1);
        GameManager.Instance.stations[2].Load(saveData.stationSaveData_2);
        GameManager.Instance.stations[3].Load(saveData.stationSaveData_3);
        GameManager.Instance.stations[4].Load(saveData.stationSaveData_4);
        GameManager.Instance.stations[5].Load(saveData.stationSaveData_5);
    }



}
