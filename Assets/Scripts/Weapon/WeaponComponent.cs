using UnityEngine;

namespace SpaceWar
{
    [RequireComponent(typeof(Weapon))]
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapon _weapon;

        protected abstract void WeaponFired();

        protected virtual void Awake()
        {
            _weapon = GetComponent<Weapon>();
        }

        private void OnEnable()
        {
            _weapon.OnFire += WeaponFired;
        }

        private void OnDisable()
        {
            _weapon.OnFire -= WeaponFired;
        }
    }
}