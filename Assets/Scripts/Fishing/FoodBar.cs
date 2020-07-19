using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public float waittime = 30f;

    public Sprite[] fullfish;
    public Sprite[] halffish;
    public Sprite emptyfish;

    private List<int> indexes = new List<int>();

    public Image[] slots;

    private bool loosingfood;

    GameManager gm;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;

        for (int i = 0; i < slots.Length; i++)
        {
            indexes.Add(i);
        }
    }

    void Update()
    {
        if (!loosingfood)
            StartCoroutine(FoodLost());
    }

    public bool CheckFish(Fish fish)
    {
        int index;

        switch (fish.name)
        {
            case "Bream":
                index = 0;
                break;
            case "Carp":
                index = 1;
                break;
            case "Trout":
                index = 2;
                break;
            case "Red Mullet":
                index = 3;
                break;
            default:
                index = 0;
                break;
        }

        if (slots[index].sprite == fullfish[index])
            return true;
        else
            return false;
    }

    public void EatFish(Fish fish)
    {
        int index;

        switch (fish.name)
        {
            case "Bream":
                index = 0;
                break;
            case "Carp":
                index = 1;
                break;
            case "Trout":
                index = 2;
                break;
            case "Red Mullet":
                index = 3;
                break;
            default:
                index = 0;
                break;
        }

        slots[index].sprite = fish.sprite;
        indexes.Add(index);
    }

    IEnumerator FoodLost()
    {
        loosingfood = true;

        int rindex = random.Next(indexes.Count);
        int relement = indexes[rindex];

        yield return new WaitForSeconds(waittime);

        if (slots[relement].sprite == fullfish[relement])
        {
            slots[relement].sprite = halffish[relement];
        }
        else if (slots[relement].sprite == halffish[relement])
        {
            slots[relement].sprite = emptyfish;
        }
        if (slots[relement].sprite == emptyfish)
        {
            indexes.Remove(relement);
        }
        if (indexes.Count <= 0)
        {
            gm.EndGame();
        }

        loosingfood = false;
    }
}
