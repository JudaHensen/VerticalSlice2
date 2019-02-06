using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour {

    [Header("Player attack slashes")]
    public List<AudioClip> playerSlashes;

    [Header("Player attack hits")]
    public List<AudioClip> playerHits;

    [Header("Player walk fx")]
    public AudioClip playerWalk;

    [Header("Assign a different AudioSource to each variable.")]
    // Player slash source
    public AudioSource sourceSlash;
    // Player attack hit source
    public AudioSource sourceHit;
    // Player run source
    public AudioSource sourceRun;
    private bool isRunning = false;

    private AudioSystem audioSystem;

    void Start() {
        audioSystem = GameObject.FindWithTag("AudioSystem").GetComponent<AudioSystem>();

        audioSystem.PlayerSlash += OnSlash;
        audioSystem.PlayerHit += OnHit;
        audioSystem.PlayerWalk += OnWalk;
    }

    // on player slash, play fx
    private void OnSlash(int value) {
        sourceSlash.clip = playerSlashes[value];
        sourceSlash.Play();
    }

    // on player attack hit, play fx
    private void OnHit(int value) {
        sourceHit.clip = playerHits[value];
        sourceHit.Play();
    }

    // when the player is walking, play fx
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
