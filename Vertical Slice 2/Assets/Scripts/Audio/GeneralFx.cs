using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFx : MonoBehaviour {

    [Header("Player death screams")]
    public List<AudioClip> playerDeathFx;

    [Header("Boss death")]
    public List<AudioClip> bossDeathFx;

    [Header("Boss slain Fx")]
    public AudioClip bossSlainFx;

    [Header("Menu click Fx")]
    public AudioClip menuClickFx;

    private AudioSystem audioSystem;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();

        audioSystem.PlayerDeath += PlayerDeath;
        audioSystem.BossDeath += BossDeath;
        audioSystem.BossSlain += BossSlain;
        audioSystem.UIButtonClick += MenuClick;
    }

    private void PlayerDeath() {
        source.clip = playerDeathFx[Random.Range(0, playerDeathFx.Count)];
    }

    private void BossDeath() {
        source.clip = bossDeathFx[Random.Range(0, bossDeathFx.Count)];
    }

    private void MenuClick()
    {
        source.clip = menuClickFx;
    }


    private void BossSlain() {
        source.clip = bossSlainFx;
    }
}
