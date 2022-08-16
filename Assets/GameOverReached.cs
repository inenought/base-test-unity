using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverReached : MonoBehaviour
{
    [SerializeField] 
    private void OnCollisionEnter(Collision collision)
    {
        GameControl.mainGameControl.StatusGame();
    }
}
