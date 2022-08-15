using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatusSystem;

public class PlayerStatus : CharacterStatus
{
    void Start()
    {
        Life = this.InitialLife;
        initPos = this.gameObject.transform;
        //----------------------------
        Anim = this.gameObject.GetComponent<Animator>();
    }

}
