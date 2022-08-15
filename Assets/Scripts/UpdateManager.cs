using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    //THIS CODE CONTROLS THE UPDATE OF ALL OBJECTS BASED ON ORIGINAL UPDATE
    // Update is called once per frame
    void Update()
    {
        if (GameControl.mainGameControl.mainGameState == GameControl.GameState.run) { FrameUpdate(); };
        
    }

    private void FixedUpdate()
    {
        if (GameControl.mainGameControl.mainGameState == GameControl.GameState.run) { TimeUpdate(); };
    }

    private void LateUpdate()
    {
        if (GameControl.mainGameControl.mainGameState == GameControl.GameState.run) { ByLateUpdate(); ChangeVelAnimation(1); };
        if (GameControl.mainGameControl.mainGameState == GameControl.GameState.pause) { ChangeVelAnimation(0); };
    }
    public virtual void TimeUpdate() { }

    public virtual void FrameUpdate() { }

    public virtual void ByLateUpdate() { }

    public virtual void ChangeVelAnimation(float vel)
    {
        Animator objectAnim = this.gameObject.GetComponent<Animator>() != null ? GetComponent<Animator>() : null;
        if (objectAnim != null) { objectAnim.speed = vel; }
        else { return; }
    }
}
