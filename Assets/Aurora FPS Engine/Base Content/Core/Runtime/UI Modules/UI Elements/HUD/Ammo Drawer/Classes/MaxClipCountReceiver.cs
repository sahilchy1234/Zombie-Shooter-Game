﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using AuroraFPSRuntime.WeaponModules;
using UnityEngine;
using UnityEngine.UI;

namespace AuroraFPSRuntime.UIModules.UIElements.HUD
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/UI Modules/UI Elements/HUD/Weapon/Max Clip Count Receiver")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public sealed class MaxClipCountReceiver : MonoBehaviour
    {
        [SerializeField]
        [NotNull]
        private WeaponReloadSystem reloadSystem;

        // Stored required components.
        private Text textComponent;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            textComponent = GetComponent<Text>();
        }

        /// <summary>
        /// Called after all Update functions have been called.
        /// </summary>
        private void LateUpdate()
        {
            textComponent.text = reloadSystem.GetMaxClipCount().ToString();
        }

        #region [Getter / Setter]
        public WeaponReloadSystem GetReloadSystem()
        {
            return reloadSystem;
        }

        public void SetReloadSystem(WeaponReloadSystem value)
        {
            reloadSystem = value;
        }

        public Text GetTextComponent()
        {
            return textComponent;
        }
        #endregion
    }
}