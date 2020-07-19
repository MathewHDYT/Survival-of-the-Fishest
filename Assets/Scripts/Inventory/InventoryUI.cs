using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsparent;

    GameManager gm;

    InventorySlot[] slots;

    private void Start()
    {
        gm = GameManager.instance;
        gm.onItemChangedCallback += UpdateUI;

        slots = itemsparent.GetComponentsInChildren<InventorySlot>();
    }
    
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < gm.inventory.Count)
            {
                slots[i].AddItem(gm.inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
