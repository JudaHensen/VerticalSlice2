using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [Header("LevelSystem instance")]
    [SerializeField]
    private LevelSystem levelsystem;

    private bool doorOpen = false;

    public void OpenDoor()
    {
        if (levelsystem.BossSlain)
        {
            doorOpen = true;
            // play door opening animation
        }
    }

    private void EnterDoor()
    {
        if(doorOpen)
        {
            // enter next level
        }
    }
}
