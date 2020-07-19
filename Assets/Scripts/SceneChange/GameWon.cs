using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public void EndGameButton()
    {
        SceneManager.LoadScene("GameWon");
    }

    public void ContinuePlayingButton()
    {
        gameObject.SetActive(false);
    }
}
