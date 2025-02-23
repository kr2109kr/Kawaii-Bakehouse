using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int money;

    [SerializeField] private Text moneyText;

    public List<Station> stations; 
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SaveSystem.Load();
        moneyText.text = money.ToString();
    }


    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
        SaveSystem.Save();
    }


    public void SpenMoney(int amount)
    {
        money -= amount;
        moneyText.text = money.ToString();
        SaveSystem.Save();
    }


    public void Save(ref MoneySaveData data)
    {
        data.moneySaveData = money;
    }


    public void Load(MoneySaveData data)
    {
        money = data.moneySaveData;
    }

}

[System.Serializable]
public struct MoneySaveData
{
    public int moneySaveData;
}
