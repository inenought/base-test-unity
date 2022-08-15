using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Menu_UI_Buttons : MonoBehaviour
{
    private static Menu_UI_Buttons instance = null;

    public static Menu_UI_Buttons MenuAcess
    {
        get
        {
            if (instance == null)
            {
                instance = new Menu_UI_Buttons();
            }
            return instance; 
        }
    }

    [Header("Buttons")]
    [SerializeField]
    GameObject ButtonStartGame;
    [SerializeField]
    GameObject ButtonExitGame;
    //----------------------
    public enum GameState 
    {
        Run,
        Pause
    };

    public GameState gs;
    //----------------------
    [Header("Scenes")]
    [SerializeField] string menuScene = "Menu";
    [SerializeField] string GameplayScene = "Gameplay";

    //EventButtons
    public void StartGame() => SceneManager.LoadScene(GameplayScene);
    public void MenuGame() => SceneManager.LoadScene(menuScene);
    public void ResetCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
