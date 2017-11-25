using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class VictoryMusic : MonoBehaviour
    {
        public AudioSource NormalMusic;
        public AudioSource Victory;

        void OnEnable()
        {
            foreach (var source in FindObjectsOfType<AudioSource>())
            {
                source.Stop();
            }
            //NormalMusic.mute = true;
            Victory.Play();
        }

        void OnDisable()
        {
            Victory.Stop();
            //NormalMusic.mute = false;
        }
    }
}
