/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using UnityEngine;

namespace AuroraFPSRuntime.SystemModules.HealthModules
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/System Modules/Health/Hitbox")]
    [DisallowMultipleComponent]
    public sealed class Hitbox : MonoBehaviour, IHealth, IDamageable
    {
        [SerializeField]
        [NotNull]
        private HealthComponent healthComponent;

        [SerializeField]
        private float multiplier = 0;

        [SerializeField]
        private float protection = 100;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            Debug.Assert(healthComponent != null, $"Health reference is not assigned! GameObject: {gameObject}, Root: {transform.root}");
        }

        #region [IHealth Implementation]
        public float GetHealth()
        {
            return healthComponent.GetHealth();
        }

        public bool IsAlive()
        {
            return healthComponent.IsAlive();
        }
        #endregion

        #region [IDamageable Implementation]
        /// <summary>
        /// Take damage to the health.
        /// </summary>
        /// <param name="amount">Damage amount.</param>
        public void TakeDamage(float amount, DamageInfo damageInfo)
        {
            amount *= multiplier;

            if (protection > 0)
            {
                protection -= amount;
                if (protection < 0)
                {
                    amount = Mathf.Abs(protection);
                    protection = 0;
                }
            }

            healthComponent.TakeDamage(amount, damageInfo);
        }
        #endregion

        #region [Getter / Setter]
        public HealthComponent GetHealthComponent()
        {
            return healthComponent;
        }

        public void SetHealthComponent(HealthComponent value)
        {
            healthComponent = value;
        }

        public float GetMultiplier()
        {
            return multiplier;
        }

        public void SetMultiplier(float value)
        {
            multiplier = value;
        }

        public float GetProtection()
        {
            return protection;
        }

        public void SetProtection(float value)
        {
            protection = value;
        }
        #endregion
    }
}

