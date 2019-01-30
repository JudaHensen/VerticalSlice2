using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {

    [Header("Time between the boss death grunt & the boss slain fx")]
    [SerializeField]
    private float bossSlainDelay = 1;
    private float bossSlainTimer = 0;
    private bool bossIsSlain = false;

    public event Action<bool> PlayerWalk, BossWalk;
    public event Action<int> PlayerSlash, PlayerHit;
    public event Action BossSlash, BossHit;
    
    public event Action PlayerDeath, BossDeath, BossSlain;


    void Update()
    {
        if(bossIsSlain && bossSlainTimer < bossSlainDelay)
        {
            if (bossSlainTimer >= bossSlainDelay) BossSlain();
        }
    }

    // Player & Boss movement
    public void SetPlayerWalk(bool value)
    {
        PlayerWalk(value);
    }
    public void SetBossWalk(bool value)
    {
        BossWalk(value);
    }

    // Player & Boss slashes
    public void PlayerAttackSlash(int value)
    {
        PlayerSlash(value);
    }
    public void BossAttackSlash()
    {
        BossSlash();
    }

    // Player & Boss Attack Hits
    public void PlayerAttackHit(int value)
    {
        PlayerHit(value);
    }
    public void BossAttackHit()
    {
        BossHit();
    }


    public void Kill(string entity)
    {
        switch (entity) {
            case "player":
                PlayerDeath();
                break;
            case "boss":
                BossDeath();
                bossIsSlain = true;
                break;
        }
    }

}
