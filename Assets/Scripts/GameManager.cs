using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int money;


    [SerializeField] private Text moneyText;

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


    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }

    public void SpenMoney(int amount)
    {
        money -= amount;
        moneyText.text = money.ToString();
    }

}
