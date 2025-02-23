using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    private Station station;
    [SerializeField] private int unlockCost;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject timerSlider;
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject unlockButton;
    [SerializeField] private Text unlockCostText;


    private void Awake()
    {
        station = GetComponent<Station>();
    }

    private void Start()
    {
        unlockCostText.text = unlockCost.ToString();
        SaveSystem.Load();

        if (!station.isUnlocked)
        {
            LockStation();
        }

        if (station.isUnlocked)
        {
            LoadUnlockStattion();
        }
    }

    public void Update()
    {
        if (station.isUnlocked)
        {
            LoadUnlockStattion();
        }
    }

    public void LockStation()
    {
        table.SetActive(false);
        station.enabled = false;
        timerSlider.SetActive(false);
        upgradeButton.SetActive(false);
        unlockButton.SetActive(true);
    }


    public void UnlockStation()
    {
        if (GameManager.Instance.money >= unlockCost)
        {
            GameManager.Instance.SpenMoney(unlockCost);
            table.SetActive(true);
            station.enabled = true;
            timerSlider.SetActive(true);
            upgradeButton.SetActive(true);
            unlockButton.SetActive(false);
            station.isUnlocked = true;

            SaveSystem.Save();
        }
    }

    public void LoadUnlockStattion()
    {
        table.SetActive(true);
        station.enabled = true;
        timerSlider.SetActive(true);
        upgradeButton.SetActive(true);
        unlockButton.SetActive(false);
    }
}
