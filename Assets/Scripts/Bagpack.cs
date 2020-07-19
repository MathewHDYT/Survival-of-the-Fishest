using UnityEngine;

public class Bagpack : MonoBehaviour
{
    public GameObject inventoryUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        gm.openedinventory = true;
    }
}
