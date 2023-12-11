﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using System;
using System.IO;

namespace AuroraFPSRuntime.Attributes
{
    public sealed class AssetSelecterAttribute : ViewAttribute
    {
        public AssetSelecterAttribute()
        {
            this.AssetType = null;
            this.Path = "Assets";
            this.Search = SearchOption.AllDirectories;
        }

        #region [Parameters]
        /// <summary>
        /// Target asset search type.
        /// </summary>
        public Type AssetType { get; set; }
        
        /// <summary>
        /// Search asset path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Search asset option.
        /// </summary>
        public SearchOption Search { get; set; }
        #endregion
    }
}