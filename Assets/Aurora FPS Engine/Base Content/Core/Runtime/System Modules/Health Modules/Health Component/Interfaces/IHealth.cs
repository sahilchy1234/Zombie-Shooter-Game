﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.SystemModules.HealthModules
{
    public interface IHealth
    {
        /// <summary>
        /// Get current health value.
        /// </summary>
        float GetHealth();

        /// <summary>
        /// Alive state of health object.
        /// </summary>
        /// <returns>
        /// True if health > health limit value.
        /// Otherwise false.
        /// </returns>
        bool IsAlive();
    }
}