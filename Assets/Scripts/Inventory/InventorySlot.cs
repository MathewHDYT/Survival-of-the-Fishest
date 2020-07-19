using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Button sellbutton;

    public Transform player;
    public GameObject instantiatefish;
    Vector3 offset = new Vector3(0, 1.2f, 0);

    public Fish fish;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    public void AddItem(Fish newfish)
    {
        fish = newfish;

        icon.sprite = fish.sprite;
        icon.enabled = true;

        removeButton.interactable = true;
        sellbutton.interactable = true;

    }

    public void ClearSlot()
    {
        fish = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
        sellbutton.interactable = false;
    }

    public void OnRemoveButton()
    {
        gm.clickedclose = true;
        GameObject instantiedfish = Instantiate(instantiatefish, player.position + offset, Quaternion.identity);
        instantiedfish.GetComponent<SpriteRenderer>().sprite = fish.sprite;
        instantiedfish.GetComponent<FishPickUp2>().fish = fish;
        gm.Remove(fish);
    }

    public void OnSellButton()
    {
        gm.clickedsell = true;
        gm.IncreaseScore(fish.price);
        gm.Remove(fish);
    }

    public void UseItem()
    {
        if (fish != null && gm.incampfire)
        {
            gm.UseFish(fish);
        }
    }
}
