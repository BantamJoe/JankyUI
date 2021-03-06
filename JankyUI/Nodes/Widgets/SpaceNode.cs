﻿using System;
using JankyUI.Attributes;
using JankyUI.Nodes.Binding;
using UnityEngine;

namespace JankyUI.Nodes
{
    [JankyTag("Space")]
    [JankyProperty("size", nameof(Size), DefaultValue = "NaN")]
    internal class SpaceNode : Node
    {
        public JankyProperty<float> Size;

        protected override void OnGUI()
        {
#if MOCK
            Console.WriteLine("Space: {0}", Size);
#else
            if (float.IsNaN(Size))
                GUILayout.FlexibleSpace();
            else
                GUILayout.Space(Size);
#endif
        }
    }
}
