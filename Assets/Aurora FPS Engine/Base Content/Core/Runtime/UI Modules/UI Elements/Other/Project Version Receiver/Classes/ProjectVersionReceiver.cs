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
using UnityEngine.UI;

namespace AuroraFPSRuntime.UIModules.UIElements
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/UI Modules/UI Elements/Other/Project Version Receiver")]
    [DisallowMultipleComponent]
    public sealed class ProjectVersionReceiver : MonoBehaviour
    {
        [SerializeField]
        [NotNull]
        private Text text;

        [SerializeField]
        private string prefix;

        [SerializeField]
        private string suffix;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            text.text = string.Format("{0}{1}{2}", prefix, Application.version, suffix);
        }
    }
}