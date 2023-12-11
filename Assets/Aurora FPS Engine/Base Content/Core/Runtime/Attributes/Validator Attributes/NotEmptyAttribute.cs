﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using System;

namespace AuroraFPSRuntime.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class NotEmptyAttribute : ValidatorAttribute
    {
        public const string NameArgument = "{name}";
        public const string DefaultMessageFormat = "{name} cannot be empty!";

        public NotEmptyAttribute()
        {
            Format = DefaultMessageFormat;
            Size = MessageBoxSize.Small;
        }

        #region [Parameters]
        /// <summary>
        /// Custom message format. 
        /// Arguments: {name}
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Size of message box.
        /// </summary>
        public MessageBoxSize Size { get; set; }
        #endregion
    }
}