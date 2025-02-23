using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    private bool isOpened;
    
    [SerializeField] private SpriteRenderer tablespriteRenderer;
    [SerializeField] private SpriteRenderer ovenSpriteRenderer;

    [SerializeField] private Button goodsUpgradeButton;
    [SerializeField] private Button stationUpgradeButton;


    public void ToggleMenu()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            goodsUpgradeButton.gameObject.SetActive(true);
            stationUpgradeButton.gameObject.SetActive(true);
            tablespriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            ovenSpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }

        else
        {
            goodsUpgradeButton.gameObject.SetActive(false);
            stationUpgradeButton.gameObject.SetActive(false);
            tablespriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            ovenSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}
