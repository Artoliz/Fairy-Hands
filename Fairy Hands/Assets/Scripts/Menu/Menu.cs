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
                //!!! Launch game, stay on the same scene, just launch the recipes... !!!
                
                Debug.Log("Je click");
                startMenu.SetActive(false);
                gameMenu.SetActive(true);
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
            }
        }
    }

    public void BackToMainMenu()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                //!!! Stop game but stay on the scene, just cancel the game !!!
                
                startMenu.SetActive(true);
                gameMenu.SetActive(false);
            }
        }
    }

    public void RestartGame()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (hand != null)
            {
                //!!! Reset game here !!!

                startMenu.SetActive(false);
                gameMenu.SetActive(true);
            }
        }
    }

    #endregion
}
