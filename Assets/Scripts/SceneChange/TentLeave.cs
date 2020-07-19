using UnityEditor;
using UnityEngine;

public class TentLeave : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Application.Quit();
        }
    }

}
