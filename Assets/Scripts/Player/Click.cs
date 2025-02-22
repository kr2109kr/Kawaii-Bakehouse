using UnityEngine;

public class Click : MonoBehaviour
{
    private int clickCount;
    private int clickCountTarget;


    private void OnMouseUp()
    {
       //clickCountTarget = GameManager.gameManager.collection.
        clickCount++;

        if (clickCount == clickCountTarget)
        {
            Debug.Log("Done");
            clickCount = 0;
        }
    }
}
