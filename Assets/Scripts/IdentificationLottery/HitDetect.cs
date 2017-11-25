using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.AgentAI;
using UnityEngine;

namespace Assets.Scripts.IdentificationLottery
{
    class HitDetect : MonoBehaviour
    {
        public CustomWeapon Weapon;

        public bool hitHeroes = false;
        void OnTriggerEnter(Collider other)
        {
            if (hitHeroes)
            {
                var playerAi = other.GetComponent<PlayerAI>();
                if (playerAi == null) return;
                Weapon.HitDetectedOn(playerAi);
            }
            else
            {
                var minionAi = other.GetComponent<MinionAI>();
                if (minionAi == null) return;
                Debug.Log("DetectedHit");
                Weapon.HitDetectedOn(minionAi);
            }
        }
    }
}
