﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

namespace AuroraFPSRuntime.Attributes
{
    public sealed class SliderAttribute : ViewAttribute
    {
        public readonly float minValue;
        public readonly float maxValue;
        public readonly string minProperty;
        public readonly string maxProperty;

        public SliderAttribute(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public SliderAttribute(string minProperty, string maxProperty)
        {
            this.minProperty = minProperty;
            this.maxProperty = maxProperty;
        }

        public SliderAttribute(string minProperty, float maxValue)
        {
            this.minProperty = minProperty;
            this.maxValue = maxValue;
        }

        public SliderAttribute(float minValue, string maxProperty)
        {
            this.minValue = minValue;
            this.maxProperty = maxProperty;
        }
    }
}