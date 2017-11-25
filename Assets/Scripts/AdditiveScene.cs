using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class AdditiveScene : MonoBehaviour
    {
        void Start()
        {
            if(FindObjectOfType<DecardTrigger>() == null) {
                SceneManager.LoadScene("Lottery", LoadSceneMode.Additive);
            }
        }
    }
}
