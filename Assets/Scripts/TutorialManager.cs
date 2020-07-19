using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject score;
    public GameObject bagpack;

    private int popUpIndex = 0;

    private float waittime = 6f;


    private bool calledonce = false;

    GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.tutorialdone)
            return;

        if (popUpIndex == 0 && gm.gotrod)
        {
            popUps[popUpIndex].SetActive(true);
            if (gm.clickedleft)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1 && gm.gotrod)
        {
            popUps[popUpIndex].SetActive(true);
            if (gm.clickedrigt)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2 && gm.incampfire)
        {
            popUps[popUpIndex].SetActive(true);
            bagpack.SetActive(true);
            if (gm.openedinventory)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3 && gm.incampfire && gm.inventory.Count > 0)
        {
            popUps[popUpIndex].SetActive(true);
            if (gm.usedfish)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            popUps[popUpIndex].SetActive(true);
            if (gm.clickedclose)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            popUps[popUpIndex].SetActive(true);
            score.SetActive(true);
            if (gm.clickedsell)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6 && gm.incampfire)
        {
            popUps[popUpIndex].SetActive(true);

            if (calledonce)
                return;

            StartCoroutine(SetWinTutorial());
            calledonce = true;
        }
    }

    IEnumerator SetWinTutorial()
    {
        yield return new WaitForSeconds(waittime);

        popUps[popUpIndex].SetActive(false);
        popUpIndex++;
        gm.tutorialdone = true;
    }
}
