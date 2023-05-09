using UnityEngine;

public class CurrentItemInventory : MonoBehaviour
{
    private GameObject currentItem = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectItem(0);

        if (currentItem != null)
        {
            currentItem.transform.position = transform.position;
            currentItem.transform.parent = transform;

            currentItem.transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void SelectItem(int index)
    {
        if (Inventory.Instance.items.Count > index)
        {
            if (currentItem != null)
                currentItem.SetActive(false);
        }

        currentItem = Inventory.Instance.items[index];
        currentItem.SetActive(true);
    }
}
