using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
    private int currentGoodsLevel;
    private int currentStationLevel = 0;

    public bool isUnlocked;

    [SerializeField] private int unlockCost;
    public bool isStationUpgraded;

    [SerializeField] private SpriteRenderer OvenSpriteRenderer;
    private Slider timerSlider;


    private float doingTime;

    private float stationTimer = 0;
    private int multiplier = 1;

    private Unlock unlockComponent;


    [SerializeField] private VerticalLayoutGroup upgradeMenu;
    [SerializeField] private Text goodsUpgradeText;
    [SerializeField] private Text stationUpgradeText;
    [SerializeField] private Goods goods;
    [SerializeField] private List<StationLevel> stationLevels;


    [SerializeField] private GameObject dropGoods;


    [System.Serializable]
    private struct StationLevel
    {
        public Sprite stationSprite;
        public int upgradeCost;
    }


    private void Awake()
    {
        timerSlider = GetComponentInChildren<Slider>(true);
        unlockComponent = GetComponent<Unlock>();


        if (!isStationUpgraded)
        {
            stationUpgradeText.text = stationUpgradeText.text = "Station Lv." + (currentStationLevel + 1) + " [" + stationLevels[currentStationLevel + 1].upgradeCost + " ]";
        }
    }


    private void Start()
    {

        StartCoroutine(Bake(goods.levels[currentGoodsLevel].employeeTimer));
        timerSlider.value = 0;
    }


    private void Update()
    {
        if (currentGoodsLevel <= goods.levels.Count - 1)
        {
            if (currentGoodsLevel == goods.levels.Count - 1)
            {
                goodsUpgradeText.text = goods.name + " Lv." + (currentGoodsLevel + 1) + " [ Max Level ]";
            }

            else
            {
                goodsUpgradeText.text = goods.name + " Lv." + (currentGoodsLevel + 1) + " [ " + goods.levels[currentGoodsLevel + 1].upgradeCost + " ]";
            }
        }

        if (isStationUpgraded)
        {
            OvenSpriteRenderer.sprite = stationLevels[currentStationLevel].stationSprite;

            stationUpgradeText.text = "Station Lv." + (currentStationLevel + 1) + " [ Max Level ]";
            multiplier = 2;
        }
    }

    IEnumerator Bake(float duration)
    {
        while (true)
        {
            yield return StartCoroutine(BakeTimer(duration));
            if (isStationUpgraded)
            {
                Instantiate(dropGoods, transform.position, transform.rotation);
                Instantiate(dropGoods, transform.position, transform.rotation);
            }

            else
            {
                Instantiate(dropGoods, transform.position, transform.rotation);
            }
            SellGoods();
        }
    }


    IEnumerator BakeTimer(float duration)
    {
        while (stationTimer <= duration)
        {
            stationTimer += Time.deltaTime;
            timerSlider.value = stationTimer / duration;
            yield return null;
        }

        stationTimer = 0;
        timerSlider.value = 0;
    }


    private void SellGoods()
    {
        GameManager.Instance.AddMoney(goods.levels[currentGoodsLevel].sellingPrice * multiplier);
    }


    


    public void UpgradeGoods()
    {
        if (currentGoodsLevel < goods.levels.Count - 1)
        {
            if (GameManager.Instance.money >= goods.levels[currentGoodsLevel + 1].upgradeCost)
            {
                GameManager.Instance.SpenMoney(goods.levels[currentGoodsLevel + 1].upgradeCost);


                currentGoodsLevel++;


                if (currentGoodsLevel < goods.levels.Count - 1)
                {
                    goodsUpgradeText.text = goods.name + " Lv." + (currentGoodsLevel + 1) + " [ " + goods.levels[currentGoodsLevel + 1].upgradeCost + " ]";
                }


                else
                {
                    goodsUpgradeText.text = goods.name + " Lv." + (currentGoodsLevel + 1) + " [ Max Level ]";
                }

                SaveSystem.Save();
                
            }
        }
    }


    public void UpgradeStation()
    {
        if (currentStationLevel < stationLevels.Count - 1)
        {
            if (GameManager.Instance.money >= stationLevels[currentStationLevel + 1].upgradeCost)
            {
                GameManager.Instance.SpenMoney(stationLevels[currentStationLevel + 1].upgradeCost);

                currentStationLevel++;
                isStationUpgraded = true;

                SaveSystem.Save();
            }

        }
    }


    public void Save(ref StationSaveData data)
    {
        data.currentGoodsLevel = currentGoodsLevel;
        data.currentStationLevel = currentStationLevel;
        data.isUnlocked = isUnlocked;
        data.isStationUpgraded = isStationUpgraded;
    }


    public void Load(StationSaveData data)
    {
        currentGoodsLevel = data.currentGoodsLevel;
        currentStationLevel = data.currentStationLevel;
        isUnlocked = data.isUnlocked;
        isStationUpgraded = data.isStationUpgraded;
    }


}

[System.Serializable]
public struct StationSaveData
{
    public int currentGoodsLevel;
    public int currentStationLevel;
    public bool isUnlocked;
    public bool isStationUpgraded;
}