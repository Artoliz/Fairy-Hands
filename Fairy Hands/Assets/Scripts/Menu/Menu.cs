using UnityEngine;
using Valve.VR.InteractionSystem;

public class Menu : MonoBehaviour
{
    #region PublicVariables

    public GameObject startMenu;
    public GameObject gameMenu;

    public static Menu Instance;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);

        Instance = this;
    }

    #endregion

    #region PublicMethods

    public void PlayGame()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                startMenu.SetActive(false);
                gameMenu.SetActive(true);
                GameManager.Instance.StartGame(false);
                break;
            }
        }
    }

    public void PlayGameWithTutorial()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                startMenu.SetActive(false);
                gameMenu.SetActive(true);
                GameManager.Instance.StartGame(true);
                break;
            }
        }
    }

    public void QuitToDesktop()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                Application.Quit();
                break;
            }
        }
    }

    public void BackToMainMenu()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                startMenu.SetActive(true);
                gameMenu.SetActive(false);
                GameManager.Instance.StopGame();
                break;
            }
        }
    }

    public void RestartGame()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                GameManager.Instance.RestartGame();
                break;
            }
        }
    }

    #endregion
}