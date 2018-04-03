﻿using System;
using JankyUI.Attributes;
using JankyUI.Binding;
using UnityEngine;

namespace JankyUI.Nodes
{

    [JankyTag("Scrollbar")]
    [JankyProperty("type", nameof(Type))]
    [JankyProperty("size", nameof(Size))]
    [JankyProperty("value", nameof(Value))]
    [JankyProperty("min-value", nameof(MinValue))]
    [JankyProperty("max-value", nameof(MaxValue))]
    internal class ScrollBarNode : LayoutNode
    {
        public enum ScrollBarTypeEnum
        {
            Horizontal,
            Vertical
        }

        public readonly PropertyBinding<ScrollBarTypeEnum> Type;
        public readonly PropertyBinding<float> Value;
        public readonly PropertyBinding<float> Size;
        public readonly PropertyBinding<float> MinValue;
        public readonly PropertyBinding<float> MaxValue;

        public override void Execute()
        {
            switch (Type.Value)
            {
                case ScrollBarTypeEnum.Horizontal:
                    Value.Value = GUILayout.HorizontalScrollbar(Value, Size, MinValue, MaxValue, GetLayoutOptions());
                    break;

                case ScrollBarTypeEnum.Vertical:
                    Value.Value = GUILayout.VerticalScrollbar(Value, Size, MinValue, MaxValue, GetLayoutOptions());
                    break;
            }
        }
    }
}