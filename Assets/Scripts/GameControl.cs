using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameControl
{
    public enum GameState
    {
        run,
        pause,
        status,
        resetScene
    }

    public GameState mainGameState;

    private static GameControl GCinstance = null;

    public static GameControl mainGameControl
    { get { return GCinstance = GCinstance ?? new GameControl(); } }

    public void StatusGame() => mainGameState = GameState.status;
    public void PauseGame() => mainGameState = GameState.pause;
    public void ResumeGame() => mainGameState = GameState.run;
    public void ResetGame() { mainGameState = GameState.resetScene; Menu_UI_Buttons.MenuAcess.ResetCurrentScene(); }
}