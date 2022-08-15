
using UnityEngine;
public class LanternController : UpdateManager
{
    //---------
    [SerializeField] public Light Lantern;
    //---------
    [SerializeField] MeshRenderer lightMaterial;
    
    [Header("Maximum energy of Lantern")]
    [SerializeField]float maxenergy = 100;
    float lightEnergy;

    [Header("Reload Time")]
    [SerializeField]float lerpRecharge = 3f;
    float multiply = 3;

    public float LightEnergy
    {
        get { return lightEnergy; }
        set { lightEnergy = Mathf.Clamp(value, 0, maxenergy); }
    }

    void Start()
    {
        LightEnergy = 50;
        Lantern.enabled = false;
    }

    public override void FrameUpdate()
    {
        lightMaterial.enabled = Lantern.enabled;
        UpdateEnergy();
        if (lightEnergy > 0)
        {TogleLanternState();
        }
        else
        { Lantern.enabled = false;
        }
    }

    void TogleLanternState()
    {
        if (Input.GetMouseButtonDown(0)){EnableLight(!Lantern.enabled);}
    }
    public void EnableLight(bool isenabled)
    {//Is enabled or not, passed by parameter
        Lantern.enabled = isenabled;
    }

    //change battery of lantern
    public void UpdateEnergy()
    {
        lightEnergy = Lantern.enabled ? lightEnergy -= lerpRecharge *multiply* Time.deltaTime : lightEnergy += lerpRecharge*Time.deltaTime;
    }
}
