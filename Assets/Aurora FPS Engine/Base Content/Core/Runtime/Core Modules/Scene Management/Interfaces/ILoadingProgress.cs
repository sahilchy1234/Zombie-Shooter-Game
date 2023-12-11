/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.CoreModules.SceneManagement
{
    public interface ILoadingProgress
    {
        /// <summary>
        /// Get current scene loading progress.
        /// </summary>
        float GetLoadingProgress();
    }
}