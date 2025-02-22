using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
    private int currentGoodsLevel;
    private int currentStationLevel = 0;

    [SerializeField] private bool isLocked;
    [SerializeField] private int unlockCost;
    [SerializeField] private bool isStationUpgraded;


    private SpriteRenderer spriteRenderer;
    private Slider timerSlider;
    private Button goodsUpgradeButton;
    private Button stationUpgradeButton;

    private float doingTime;

    private float stationTimer;
    private int multiplier = 1;

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
        //[SerializeField] private int
    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timerSlider = GetComponentInChildren<Slider>();
    }


    private void Start()
    {
        StartCoroutine(Bake(goods.levels[currentGoodsLevel].employeeTimer));
        timerSlider.value = 0;
        goodsUpgradeText.text = goods.name + " Lv." + (currentGoodsLevel + 1) + " [ " + goods.levels[currentGoodsLevel + 1].upgradeCost + " ]";
        stationUpgradeText.text = stationUpgradeText.text = "Station Lv." + (currentStationLevel + 1) + " [" + stationLevels[currentStationLevel + 1].upgradeCost + " ]";
        
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


    public void GoodsUpgrade()
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
            }
        }
    }


    public void StationUpgrade()
    {
        if (currentStationLevel < stationLevels.Count - 1)
        {
            if (GameManager.Instance.money >= stationLevels[currentStationLevel + 1].upgradeCost)
            {
                GameManager.Instance.SpenMoney(stationLevels[currentStationLevel + 1].upgradeCost);

                currentStationLevel++;
                spriteRenderer.sprite = stationLevels[currentStationLevel].stationSprite;

                stationUpgradeText.text = "Station Lv." + (currentStationLevel + 1) + " [ Max Level ]";
                multiplier = 2;
                isStationUpgraded = true;

               

            }

        }
    }
}
