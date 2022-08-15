using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    //-------------------------------
    [SerializeField]Image energyImgUi;
    [SerializeField]Image lifeImgUi;
    //------------ PLAYER LIFE
    [SerializeField]PlayerStatus playersts;
    //-------------LANTERN
    [SerializeField]LanternController lantern;
    //
    float energyAmount;
    float lifeAmount;
    //
    void FixedUpdate()
    {
        lifeAmount = playersts.Life;
        energyAmount = lantern.LightEnergy;
        UpdateBar(energyImgUi, energyAmount);
        UpdateBar(lifeImgUi, lifeAmount);
    }
    public void BackToMenu()=> Menu_UI_Buttons.MenuAcess.MenuGame();

    void UpdateBar(Image img, float fillAmount) => img.fillAmount = fillAmount / 100;
}
