using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.AudioManager;



  public class TriggerAudio : MonoBehaviour
    {

        public AudioManager audioManager;
        //public MusicPlayer musicPlayer;
        //public AudioPlayer audioPlayer;

        public string ClipToPlay = "none";

        private void OnTriggerEnter(Collider other)
        {
             Debug.Log(other.name + "entered Audio Trigger");
             audioManager.Play(ClipToPlay);
             //musicPlayer.PlayTrack();
             //audioPlayer.Play();
        }

    }
