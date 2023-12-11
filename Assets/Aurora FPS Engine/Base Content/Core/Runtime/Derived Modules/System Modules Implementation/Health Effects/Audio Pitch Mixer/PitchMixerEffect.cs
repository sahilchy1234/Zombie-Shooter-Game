/* ================================================================
   ----------------------------------------------------------------
   Project   :   Apex Inspector
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using AuroraFPSRuntime.CoreModules.Coroutines;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace AuroraFPSRuntime.SystemModules.HealthModules
{
    [HealthFunctionMenu("Pitch Mixer", "Audio/Audio Mixer/Pitch Mixer")]
    public sealed class PitchMixerEffect : HealthEffect
    {
        [SerializeField]
        [NotNull]
        private AudioMixer mixer;

        [SerializeField]
        [NotEmpty]
        [VisibleIf("mixer", "NotNull")]
        [Indent(1)]
        private string parameter = string.Empty;

        [SerializeField]
        [Slider(0.001f, 0.9f)]
        [VisibleIf("mixer", "NotNull")]
        [Indent(1)]
        private float minPitch = 0.1f;

        [SerializeField]
        private float startPoint = 50;

        // Stored required properties.
        private CharacterHealth characterHealth;
        private CoroutineObject coroutineObject;

        /// <summary>
        /// Implement this method to make some initialization 
        /// and get access to CharacterHealth references.
        /// </summary>
        /// <param name="healthComponent">Player health component reference.</param>
        public override void Initialization(CharacterHealth characterHealth)
        {
            this.characterHealth = characterHealth;
            coroutineObject = new CoroutineObject(characterHealth);
            coroutineObject.Start(PitchProcessor, true);
        }

        private IEnumerator PitchProcessor()
        {
            while (true)
            {
                float inverseLerp = Mathf.InverseLerp(characterHealth.GetMinHealth(), startPoint, characterHealth.GetHealth());
                inverseLerp = Mathf.Max(minPitch, inverseLerp);
                mixer.SetFloat(parameter, inverseLerp);
                yield return null;
            }
        }
    }
}