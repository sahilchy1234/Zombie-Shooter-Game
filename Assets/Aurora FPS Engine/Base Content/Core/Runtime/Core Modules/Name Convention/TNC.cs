/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.CoreModules
{
    /// <summary>
    /// Tag name conventions of the all Aurora FPS Engine tags.
    /// </summary>
    public static class TNC
    {
        public const string Player = "Player";
        public const string Weapon = "Weapon";
        public const string Camera = "FPCamera";
        public const string CameraLayer = "FPWeaponLayer";
        public const string AI = "AI";
        public const string Terrain = "Terrain";

        public readonly static string[] AllTags = new string[] { Player, Weapon, Camera, CameraLayer, AI, Terrain };
    }
}