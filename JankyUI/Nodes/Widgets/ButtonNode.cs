﻿using System;
using JankyUI.Attributes;
using JankyUI.Binding;
using UnityEngine;

namespace JankyUI.Nodes
{
    [JankyTag("Button")]
    [JankyProperty("text", nameof(Text))]
    [JankyProperty("image", nameof(Image))]
    [JankyProperty("on-click", nameof(OnClick))]
    [JankyProperty("repeat", nameof(IsRepeat))]
    internal class ButtonNode : LayoutNode
    {
        public readonly JankyMethod<Action> OnClick;
        public readonly JankyProperty<string> Text;
        public readonly JankyProperty<bool> IsRepeat;
        public readonly JankyProperty<Texture> Image;

        private readonly GUIContent Content;

        public ButtonNode()
        {
            Content = new GUIContent();
        }

        private void UpdateContent()
        {
            Content.text = Text;
            Content.image = Image;
        }

        protected override void OnGUI()
        {
#if MOCK
            UpdateContent();
            Console.WriteLine("Button: {0} {1}", Text, IsRepeat);
#else
            UpdateContent();
            if (IsRepeat?.Value ?? false)
            {
                if (GUILayout.RepeatButton(Content, GetLayoutOptions()))
                    OnClick.Invoke();
            }
            else
            {
                if (GUILayout.Button(Content, GetLayoutOptions()))
                    OnClick.Invoke();
            }
#endif
        }
    }
}
