using UnityEngine;
using Valve.VR.InteractionSystem;

public class Menu : MonoBehaviour
{
    #region PublicVariables

    public GameObject startMenu;
    public GameObject gameMenu;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);
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
                GameManager.Instance.StartGame();
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