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
using AuroraFPSRuntime.SystemModules.ControllerSystems;
using AuroraFPSRuntime.SystemModules.InventoryModules;
using UnityEngine;

namespace AuroraFPSRuntime.SystemModules
{
    [HideScriptField]
    [AddComponentMenu("Aurora FPS Engine/System Modules/Remote Body/Remote Body Animator")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class RemoteBodyAnimator : MonoBehaviour
    {
        [SerializeReference]
        [NotNull]
        private PlayerController controller;

        [SerializeField]
        [NotNull]
        private InventorySystem inventorySystem;

        [SerializeField]
        [Label("Speed")]
        [Prefix("Float", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter speedParameter = "Speed";

        [SerializeField]
        [Label("Direction")]
        [Prefix("Float", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter directionParameter = "Direction";

        [SerializeField]
        [Label("IsCrouched")]
        [Prefix("Bool", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter isCrouchedParameter = "IsCrouched";

        [SerializeField]
        [Label("IsGrounded")]
        [Prefix("Bool", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter isGroundedParameter = "IsGrounded";

        [SerializeField]
        [Label("IsJumped")]
        [Prefix("Trigger", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter isJumpedParameter = "IsJumped";

        [SerializeField]
        [Label("IsEquipped")]
        [Prefix("Bool", Style = "Parameter")]
        [Foldout("Parameters", Style = "Header")]
        private AnimatorParameter isEquippedParameter = "IsEquipped";

        [SerializeField]
        [Foldout("Parameters", Style = "Header")]
        private float velocitySmooth = 12.5f;

        // Stored required components.
        private Animator animator;

        // Stored required properties.
        private Vector3 deltaVelocity;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            animator = GetComponent<Animator>();
            Debug.Assert(controller != null, $"<b><color=#FF0000>Attach reference of the player controller to {gameObject.name}<i>(gameobject)</i> -> {GetType().Name}<i>(component)</i> -> Controller<i>(field)</i>.</color></b>");
        }

        /// <summary>
        /// Called every frame, while the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            Vector3 velocity = controller.GetVelocity();

            const float VELOCITY_RATIO = 0.025f;
            if (velocity.magnitude > VELOCITY_RATIO)
            {
                float dx = Vector3.Dot(controller.transform.right, velocity);
                float dy = Vector3.Dot(controller.transform.forward, velocity);
                Vector3 newDeltaVelocity = new Vector2(dx, dy);
                deltaVelocity = Vector3.Lerp(deltaVelocity, newDeltaVelocity, velocitySmooth * Time.deltaTime);
            }
            else
            {
                deltaVelocity = Vector3.zero;
            }

            animator.SetFloat(speedParameter, deltaVelocity.y);
            animator.SetFloat(directionParameter, deltaVelocity.x);
            animator.SetBool(isGroundedParameter, controller.IsGrounded());
            animator.SetBool(isCrouchedParameter, controller.IsCrouched());
            animator.SetBool(isEquippedParameter, inventorySystem.IsEquipped());

            if (controller.IsJumped())
            {
                animator.SetTrigger(isJumpedParameter);
            }
        }

        #region [Getter / Setter]
        public PlayerController GetController()
        {
            return controller;
        }

        public void SetController(PlayerController value)
        {
            controller = value;
        }

        public AnimatorParameter GetSpeedParameter()
        {
            return speedParameter;
        }

        public void SetSpeedParameter(AnimatorParameter value)
        {
            speedParameter = value;
        }

        public AnimatorParameter GetDirectionParameter()
        {
            return directionParameter;
        }

        public void SetDirectionParameter(AnimatorParameter value)
        {
            directionParameter = value;
        }

        public AnimatorParameter GetIsCrouchedParameter()
        {
            return isCrouchedParameter;
        }

        public void SetIsCrouchedParameter(AnimatorParameter value)
        {
            isCrouchedParameter = value;
        }

        public AnimatorParameter GetIsGroundedParameter()
        {
            return isGroundedParameter;
        }

        public void SetIsGroundedParameter(AnimatorParameter value)
        {
            isGroundedParameter = value;
        }

        public AnimatorParameter GetIsJumpedParameter()
        {
            return isJumpedParameter;
        }

        public void SetIsJumpedParameter(AnimatorParameter value)
        {
            isJumpedParameter = value;
        }

        public float GetVelocitySmooth()
        {
            return velocitySmooth;
        }

        public void SetVelocitySmooth(float value)
        {
            velocitySmooth = value;
        }
        #endregion
    }
}