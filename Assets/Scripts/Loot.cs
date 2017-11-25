using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Loot : MonoBehaviour
    {
        public List<WeaponCore> WeaponCores;
        private float _startTime;
        public float PickupDelay = 5f;
        public WeaponCore lootWeaponCore;

        public void Start()
        {
            _startTime = Time.time;
            lootWeaponCore = GetRandomWeaponCore();
            GetComponentInChildren<SpriteRenderer>().sprite = lootWeaponCore.Sprite;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (Time.time < _startTime + PickupDelay) return;
            var itemBag = collision.gameObject.GetComponent<ItemBag>();
            if (itemBag == null) return;
            Debug.Log("Loot picket up!");
            itemBag.CarriedWeapon = lootWeaponCore;
            Destroy(gameObject);
        }

        WeaponCore GetRandomWeaponCore()
        {
            return WeaponCores[UnityEngine.Random.Range((int)0, WeaponCores.Count)];
        }
    }
}
