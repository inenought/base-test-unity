using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State_Manager : MonoBehaviour
{
    public void GoToMenuEvent()
    {
        Menu_UI_Buttons.MenuAcess.MenuGame();
    }
    public void GamePausedEvent()
    {
        GameControl.mainGameControl.PauseGame();
    }

    public void ReloaddGameEvent()
    {
        GameControl.mainGameControl.ResetGame();
    }
    public void ResumeGameEvent()
    {
        GameControl.mainGameControl.ResumeGame();
    }
}
