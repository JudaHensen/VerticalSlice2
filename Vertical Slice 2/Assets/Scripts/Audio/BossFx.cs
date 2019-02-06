using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFx : MonoBehaviour {

    [Header("Boss attack slash")]
    public AudioClip bossSlash;

    [Header("Boss attack hit")]
    public AudioClip bossHit;

    [Header("Player walk fx")]
    public AudioClip bossWalk;

    [Header("Assign a different AudioSource to each variable.")]
    // Boss slash source
    public AudioSource sourceSlash;
    // Boss attack hit source
    public AudioSource sourceHit;
    // Boss run source
    public AudioSource sourceRun;
    private bool isRunning = false;

    private AudioSystem audioSystem;

    void Start() {
        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();

        audioSystem.BossSlash += OnSlash;
        audioSystem.BossHit += OnHit;
        audioSystem.BossWalk += OnWalk;
    }

    // play on boss slash
    private void OnSlash() {
        sourceSlash.clip = bossSlash;
        sourceSlash.Play();
    }

    // play on boss attack hit
    private void OnHit() {
        sourceHit.clip = bossHit;
        sourceHit.Play();
    }

    // play when the boss is walking
    private void OnWalk(bool value) {
        if(value && !isRunning)
        {
            sourceRun.Play();
            isRunning = true;
        }
        else
        {
            sourceRun.Pause();
            isRunning = false;
        }
    }
	
}
