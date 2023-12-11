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
using UnityEngine.Events;
using AuroraFPSRuntime.CoreModules.ValueTypes;

namespace AuroraFPSRuntime
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/System Modules/Event System/Event Callback Receiver")]
    [DisallowMultipleComponent]
    public sealed class EventCallbackReceiver : MonoBehaviour
    {
        public GameObject pickupBtn;

        [System.Serializable]
        public class CallbackReceiver : CallbackEvent<UnityEvent> { }

        [SerializeField]
        [Array]
        private CallbackReceiver[] callbacks;

        private void Awake()
        {
            for (int i = 0; i < callbacks.Length; i++)
            {
                callbacks[i].RegisterCallback(InvokeUnityEvent);
            }
        }

        public void InvokeUnityEvent(UnityEvent unityEvent)
        {
            unityEvent?.Invoke();
        }


         private void OnDisable()
        {
            if(pickupBtn != null)
            pickupBtn.SetActive(false);
        }

        void OnDestroy()
        {
             if(pickupBtn != null)
            pickupBtn.SetActive(false);
        }
    }
}
