using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject CanvasHud;
    [SerializeField] GameObject CanvasUI;
     void Awake()
    {
        GameControl.mainGameControl.mainGameState = GameControl.GameState.run;
    }
    private void Start()
    {
        CanvasHud.SetActive(true);
        CanvasUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GameControl.mainGameControl.PauseGame();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            GameControl.mainGameControl.ResumeGame();
        }

        switch (GameControl.mainGameControl.mainGameState)
        {
            case GameControl.GameState.run:
                CanvasHud.SetActive(true);
                CanvasUI.SetActive(false);
                
                break;
            case GameControl.GameState.pause:
                CanvasHud.SetActive(false);
                CanvasUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

                break;
            case GameControl.GameState.resetScene:
                break;
            default:
                break;
        }
    }

    public void EndGame()//Player finished game
    {

    }

    public void GameOver()//Player Died Fighting agains enemies :(
    {

    }
}