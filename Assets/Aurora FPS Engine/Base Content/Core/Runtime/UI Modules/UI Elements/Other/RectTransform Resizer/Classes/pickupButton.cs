/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.Attributes;
using AuroraFPSRuntime.CoreModules.ValueTypes;
using AuroraFPSRuntime.CoreModules.Coroutines;
using System.Collections;
using UnityEngine;

namespace AuroraFPSRuntime.UIModules.UIElements.HUD
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/UI Modules/UI Elements/Other/pickupButton")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class pickupButton : MonoBehaviour
    {
        [System.Serializable]
        public class ResizeCallback : CallbackEvent<float, AnimationCurve> { }

        [SerializeField]
        private Vector2 size = Vector2.one;

        [SerializeField]
        [Foldout("Show Event", Style = "Header")]
        private ResizeCallback showCallback;

        [SerializeField]
        [Foldout("Hide Event", Style = "Header")]
        private ResizeCallback hideCallback;

        // Stored required components.
        // private new RectTransform transform;

        // Stored required properties.
        // private CoroutineObject<Vector2, float, AnimationCurve> resizeCoroutine;



        //
        public GameObject pickUpBtn;
       
        private void Awake()
        {
            // transform = GetComponent<RectTransform>();
            // resizeCoroutine = new CoroutineObject<Vector2, float, AnimationCurve>(this);

            showCallback.RegisterCallback(ToOriginalSize);
            hideCallback.RegisterCallback(ToZeroSize);
        }

        private void ToOriginalSize(float duration, AnimationCurve curve)
        {
            // resizeCoroutine.Start(Resize, size, duration, curve, true);
            pickUpBtn.SetActive(true);
           
        }

        private void ToZeroSize(float duration, AnimationCurve curve)
        {
            // resizeCoroutine.Start(Resize, Vector2.zero, duration, curve, true);
            pickUpBtn.SetActive(false);
        }


        private void OnDisable()
        {
            if(pickUpBtn != null){
            pickUpBtn.SetActive(false);
            }
        }

        void OnDestroy()
        {
            if(pickUpBtn != null){
            pickUpBtn.SetActive(false);
            }
        }
    }
}