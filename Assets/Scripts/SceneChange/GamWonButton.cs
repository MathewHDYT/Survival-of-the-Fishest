using UnityEngine;

public class GamWonButton : MonoBehaviour
{
    public GameObject gamewonUI;

    public void OpenGameWonUI()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        gamewonUI.SetActive(!gamewonUI.activeSelf);
    }
}
