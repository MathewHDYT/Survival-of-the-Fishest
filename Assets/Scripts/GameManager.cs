using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singelton
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found");
            return;
        }

        instance = this;
    }
    #endregion

    public Transform player;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Fish> inventory = new List<Fish>();
    public int space = 12;

    public FoodBar foodbar;

    public RoastFish roastfish;

    public GameObject GamewonButton;
    public GameObject increaseScore;

    public bool caughtfish = false;
    public bool gotrod = false;
    public bool roastingfish = false;
    public bool playeddialogue = false;

    // Bools for TutorialManager
    public bool clickedleft = false;
    public bool clickedrigt = false;
    public bool openedinventory = false;
    public bool incampfire = false;
    public bool usedfish = false;
    public bool clickedclose = false;
    public bool clickedsell = false;
    public bool tutorialdone = false;

    public Text score;
    public int currentscore = 0;

    public void IncreaseScore(int scorechange)
    {
        currentscore += scorechange;
        score.text = currentscore.ToString();

        GameObject increasescore = Instantiate(increaseScore) as GameObject;
        increasescore.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Destroy(increasescore, 2f);

        Text increaseScoretext = increasescore.GetComponent<Text>() as Text;
        increaseScoretext.text = scorechange.ToString();

        if (scorechange > 0)
        {
            FindObjectOfType<AudioManager>().Play("IncreaseScore");
            increaseScoretext.color = Color.green;
            increaseScoretext.text = "+" + scorechange.ToString();
        }

        else if (scorechange == 0)
        {
            increaseScoretext.color = Color.white;
        }

        else if (scorechange < 0)
        {
            FindObjectOfType<AudioManager>().Play("DecreaseScore");
            increaseScoretext.color = Color.red;
        }
    }

    public void GameWon()
    {
        GamewonButton.SetActive(true);
        GamewonButton.GetComponent<GamWonButton>().OpenGameWonUI();
    }

    public void DecreaseScore(int scorechange)
    {
        currentscore -= scorechange;
        score.text = currentscore.ToString();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Add(Fish fish)
    {
        if (inventory.Count >= space)
        {
            Debug.Log("Inventory full");
            return;
        }

        inventory.Add(fish);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void UseFish(Fish fish)
    {
        usedfish = true;

        if (roastingfish || fish.name == "Algea" || fish.name == "Soda")
            return;

        if (!foodbar.CheckFish(fish))
        {
            roastfish.StartRoasting(fish);
            Remove(fish);
        }
    }

    public void Remove(Fish fish)
    {
        inventory.Remove(fish);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
