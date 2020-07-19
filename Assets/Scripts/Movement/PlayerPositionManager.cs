using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    private static bool firsttime = true;
    public GameObject tutorial;

    public Transform player;

    void Awake()
    {
        if (firsttime)
        {
            tutorial.SetActive(true);
            player.position = new Vector3(0, player.position.y, player.position.z);
            firsttime = false;
        }
        else
        {
            tutorial.SetActive(false);
        }
       
    }
}
