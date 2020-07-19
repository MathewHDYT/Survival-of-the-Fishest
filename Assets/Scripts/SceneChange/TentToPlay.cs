using UnityEngine;
using UnityEngine.SceneManagement;

public class TentToPlay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
