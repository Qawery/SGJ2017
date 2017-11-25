using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.IdentificationLottery;
using UnityEngine;

namespace Assets.Scripts.AgentAI
{
    class CustomWeapon : Weapon
    {
        private AttackType _attackType;
        public SpriteRenderer WeaponSpriteRenderer;

        public WeaponCore WeaponCore;

        override public void Awake()
        {
            _attackType = GetComponent<AttackType>();
            GetComponentInChildren<HitDetect>().Weapon = this;
        }


        public void SetWeaponCore(WeaponCore core)
        {
            WeaponCore = core;
            WeaponSpriteRenderer.sprite = core.Sprite;
            GetComponent<AttackType>().Animator.speed = core.Speed;
        }

        public override void StartAttack()
        {
            base.StartAttack();
            _attackType.StartAttacking();
        }

        public override void StopAttack()
        {
            base.StopAttack();
            _attackType.StopAttacking();
        }

        internal void HitDetectedOn(MinionAI minionAi)
        {
            minionAi.ApplyDamage((int)WeaponCore.Strength * 2);
            Debug.Log("Applied dmg");
        }

        internal void HitDetectedOn(PlayerAI playerAi)
        {
            playerAi.ApplyStagger(0.1f);
        }

        internal void SetOwner(GameObject adventurer)
        {
            owner = adventurer.GetComponent<WeaponAI>();
            owner.weapon = this;
        }
    }
}
