using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private string _playerTag = "Player";
    private string _handTag = "Hand";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag) && !transform.parent.CompareTag(_handTag))
        {
            Inventory.Instance.AddItem(gameObject);
            gameObject.SetActive(false);
        }
    }
}
