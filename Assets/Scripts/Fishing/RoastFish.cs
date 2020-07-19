using UnityEngine;
using System.Collections;

public class RoastFish : MonoBehaviour
{
    public GameObject grilledFish;
    public Sprite grilledfish;
    public ParticleSystem smoke;

    GameManager gm;

    private void Start ()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.incampfire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.incampfire = false;
        }
    }

    public void StartRoasting(Fish fish)
    {
        StartCoroutine(Roasting(fish));
    }

    IEnumerator Roasting(Fish ungrilledfish)
    {
        gm.roastingfish = true;
        smoke.Play();
        grilledFish.SetActive(true);
        SpriteRenderer sprite = grilledFish.GetComponent<SpriteRenderer>();
        sprite.sprite = ungrilledfish.sprite;
        yield return new WaitForSeconds(5f);
        sprite.sprite = grilledfish;
        yield return new WaitForSeconds(5f);
        grilledFish.SetActive(false);

        gm.foodbar.EatFish(ungrilledfish);
        gm.roastingfish = false;
        smoke.Stop();
    }
}
