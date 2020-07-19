using UnityEngine;
using UnityEngine.SceneManagement;

public class TentToMenu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
