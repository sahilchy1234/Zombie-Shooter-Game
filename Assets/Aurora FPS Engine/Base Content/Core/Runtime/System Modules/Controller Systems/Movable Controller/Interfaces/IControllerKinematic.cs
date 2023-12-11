﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Deryabin Vladimir
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.SystemModules.ControllerSystems
{
    interface IControllerKinematic
    {
        void IsKinematic(bool value);
        bool IsKinematic();
    }
}
