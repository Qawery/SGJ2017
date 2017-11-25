using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class IdentificationMusic : MonoBehaviour
    {
        public AudioSource NormalMusic;
        public AudioSource Identification;

        void OnEnable()
        {
            NormalMusic.mute = true;
            Identification.Play();
        }

        void OnDisable()
        {
            Identification.Stop();
            NormalMusic.mute = false;
        }
    }
}
