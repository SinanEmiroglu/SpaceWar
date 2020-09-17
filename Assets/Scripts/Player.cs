﻿using UnityEngine;

namespace SpaceWar
{
    public class Player : MonoBehaviour
    {
        public Health Health;

        [SerializeField] private Weapon[] weapons;

        public void WeaponTierUp()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].gameObject.SetActive(true);
            }
        }
    }
}