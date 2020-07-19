using UnityEngine;

public class FishPickUp : MonoBehaviour
{
    public float startForceUp = 5f;
    public float startForceLeft = 2f;

    Rigidbody2D rb;

    GameManager gm;

    public Fish fish;

    private void Start()
    {
        gm = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForceUp, ForceMode2D.Impulse);
        rb.AddForce(-transform.right * startForceLeft, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && gm.inventory.Count < gm.space)
        {
            gm.caughtfish = true;
            Destroy(gameObject);

            if (fish != null)
            {
                gm.Add(fish);
            }
            else
            {
                Debug.Log("Fish was empty");
            }
        }
    }
}
