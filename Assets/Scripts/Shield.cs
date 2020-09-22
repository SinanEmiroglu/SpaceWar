﻿using System.Collections;
using UnityEngine;

namespace SpaceWar
{
    public class Shield : PooledMonoBehaviour
    {
        [SerializeField] private int healAmount = 1;
        [SerializeField] private float healFrequency = 1f;

        private Player _player;
        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _player = GameManager.Instance.Player;
            _waitForSeconds = new WaitForSeconds(healFrequency);
        }

        private void OnEnable()
        {
            StartCoroutine(HealPlayerCor());
        }

        private IEnumerator HealPlayerCor()
        {
            while (true)
            {
                _player.Health.TakeHeal(healAmount);
                yield return _waitForSeconds;
            }
        }

        protected override void OnDisable()
        {
            StopCoroutine(HealPlayerCor());
            base.OnDisable();
        }
    }
}