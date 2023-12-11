﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using System;

namespace AuroraFPSRuntime.SystemModules.ControllerModules
{
    [Obsolete]
    public interface ICameraZoom
    {
        void ZoomIn();

        void ZoomOut();

        /// <summary>
        /// Called when camera start zooming.
        /// </summary>
        event Action OnStartZoomCallback;

        /// <summary>
        /// Called when camera stop zooming.
        /// </summary>
        event Action OnStopZoomCallback;

        /// <summary>
        /// Called every time before start start zooming to check, can be camera start zoom.
        /// </summary>
        event Func<bool> ZoomConditionCallback;
    }
}