using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 dropPosition;

    [SerializeField] private GameObject goodsDrop;
    [SerializeField] private Vector2 dropPositionOffset;


    private void Awake()
    {
        dropPosition = new(transform.position.x + dropPositionOffset.x, transform.position.y + dropPositionOffset.y);
    }


    public void Click()
    {
        GameManager.Instance.AddMoney(1);
        Instantiate(goodsDrop, dropPosition, transform.rotation);
    }
}
