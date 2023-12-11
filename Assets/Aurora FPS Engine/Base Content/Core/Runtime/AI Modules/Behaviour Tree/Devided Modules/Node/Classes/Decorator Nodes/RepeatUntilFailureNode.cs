﻿/* ================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Davleev Zinnur
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================ */

using AuroraFPSRuntime.AIModules.BehaviourTree.Attributes;
using AuroraFPSRuntime.Attributes;

namespace AuroraFPSRuntime.AIModules.BehaviourTree.Nodes
{
    [TreeNodeContent("Until Failure", "Decorators /Until Failure")]
    [HideScriptField]
    public class RepeatUntilFailureNode : DecoratorNode
    {
        protected override State OnUpdate()
        {
            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Success:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                default:
                    return State.Running;
            }
        }
    }
}