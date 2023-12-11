﻿/* ================================================================
   ---------------------------------------------------
   Project   :    Aurora FPS Engine
   Publisher :    Infinite Dawn
   Author    :    Tamerlan Shakirov
   ---------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace AuroraFPSRuntime.SystemModules.Settings
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/System Modules/Settings System/Processors/Universal/Dropdown Settings Processor")]
    [DisallowMultipleComponent]
    public class DropdownSettingsProcessor : SettingsProcessor
    {
        [SerializeField]
        [NotNull]
        private Dropdown dropdown;

        [SerializeField]
        private string defaultValue = string.Empty;

        /// <summary>
        /// Called when the script instance is being loaded
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Debug.Assert(dropdown != null, $"<b><color=#FF0000>Attach reference of the UI Dropdown element to {gameObject.name}<i>(gameobject)</i> -> {GetType().Name}<i>(component)</i> -> Dropdown<i>(field)</i>.</color></b>");
        }

        /// <summary>
        /// <br>Called when the settings manager saves the settings file.</br>
        /// <br>Note: Called only if selected stream <i>Save</i> option. Otherwise this callback will be ignored.</br>
        /// <br>Implement this method to save processor value.</br>
        /// </summary>
        protected override object OnSave()
        {
            return dropdown.options[dropdown.value];
        }

        /// <summary>
        /// <br>Called when the settings manager load the settings file.</br>
        /// <br>Note: Called only if selected stream <i>Load</i> option. Otherwise this callback will be ignored.</br>
        /// <br>Implement this method to load processor value.</br>
        /// </summary>
        protected override void OnLoad(object value)
        {
            string option = value.ToString();
            dropdown.value = dropdown.options.FindIndex(t => t.text == option);
        }

        /// <summary>
        /// <br>Called when settings file is not found or 
        /// target processor GUID is not found in loaded buffer.</br>
        /// <br>Implement this method to determine default value for this processor.</br>
        /// </summary>
        /// <returns>Default value of processor.</returns>
        public override object GetDefaultValue()
        {
            return defaultValue;
        }
    }
}