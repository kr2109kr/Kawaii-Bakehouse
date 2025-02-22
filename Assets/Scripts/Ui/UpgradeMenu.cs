using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private Button goodsUpgradeButton;
    [SerializeField] private Button stationUpgradeButton;



    public void ToggleMenu()
    {
        if (goodsUpgradeButton.gameObject.activeSelf == true && stationUpgradeButton.gameObject.activeSelf)
        {
            goodsUpgradeButton.gameObject.SetActive(false);
            stationUpgradeButton.gameObject.SetActive(false);
        }

        else
        {
            goodsUpgradeButton.gameObject.SetActive(true);
            stationUpgradeButton.gameObject.SetActive(true);
        }
    }
}
