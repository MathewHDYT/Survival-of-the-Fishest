using UnityEngine;
using System.Collections;

public class Lake : MonoBehaviour
{
    public Fish[] fish;
    
    public GameObject instantiatefish;

    public GameObject exclamationMark;

    public float minwait, maxwait, timetofish;

    private float waittime = 0f;

    private bool fishing = false;

    private bool playedsound = false;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Rod"))
        {
            fishing = true;
            col.GetComponentInParent<PlayerMovement>().fishing = fishing;
            waittime = Random.Range(minwait, maxwait);
        }
    }

    private void Update()
    {
        if (!fishing)
            return;

        if (waittime > 0)
        {
            waittime -= Time.deltaTime;
        }
        else if (waittime < 0)
        {
            StartCoroutine(StartTimetoFish());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Rod"))
        {
            fishing = false;
            col.GetComponentInParent<PlayerMovement>().fishing = fishing;
            if (waittime < 0)
            {
                FindObjectOfType<AudioManager>().Play("Pop");
                Fish caughtfish = fish[Random.Range(0, fish.Length)];
                
                GameObject instantiedfish = Instantiate(instantiatefish, col.transform.position, Quaternion.identity);
                instantiedfish.GetComponent<FishPickUp>().fish = caughtfish;
                instantiedfish.GetComponent<SpriteRenderer>().sprite = caughtfish.sprite;
                exclamationMark.SetActive(false);
            }

        }

        playedsound = false;
    }

    IEnumerator StartTimetoFish()
    {
        exclamationMark.SetActive(true);
        if (!playedsound)
        {
            FindObjectOfType<AudioManager>().Play("Fish");
            playedsound = true;
        }
        yield return new WaitForSeconds(timetofish);
        waittime = Random.Range(minwait, maxwait);
        exclamationMark.SetActive(false);
    }
}
