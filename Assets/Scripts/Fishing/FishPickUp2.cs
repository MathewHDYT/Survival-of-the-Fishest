using UnityEngine;

public class FishPickUp2 : MonoBehaviour
{
    public float startForceUp = 3f;
    public float startForceLeft = 2f;

    Transform player;

    public Fish fish;

    Rigidbody2D rb;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        player = gm.player;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForceUp, ForceMode2D.Impulse);

        // Player looks into the right direction
        if (player.localScale.x >= 0)
            rb.AddForce(transform.right * startForceLeft, ForceMode2D.Impulse);
        // Player looks into the left direction
        else if (player.localScale.x <= 0)
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
