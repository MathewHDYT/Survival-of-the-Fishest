using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsUI;

    public void OpenInventory()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        optionsUI.SetActive(!optionsUI.activeSelf);
    }
}
