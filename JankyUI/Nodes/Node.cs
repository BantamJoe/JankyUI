﻿
using System;
using System.Collections.Generic;
using JankyUI.Attributes;
using UnityEngine;

namespace JankyUI.Nodes
{
    [JankyProperty("data-context", nameof(DataContextName))]
    [JankyProperty("style", nameof(Style))]
    internal class Node
    {
        public readonly Binding.JankyProperty<GUIStyle> Style;
        public readonly string DataContextName;

        public List<Node> Children { get; set; }
        public JankyNodeContext Context { get; set; }
    
        public virtual GUISkin Skin
        {
            get
            {
                return ((IJankyContext)Context).Skin;
            }
        }

        public object DataContext
        {
            get
            {
                return Context.DataContextStack.Current();
            }
        }

        protected void PushDataContext()
        {
            if (DataContextName.IsNullOrWhiteSpace())
                return;

        }

        public void Execute()
        {
            if (!DataContextName.IsNullOrWhiteSpace())
            {
                Context.DataContextStack.Push(DataContextName);
                OnGUI();
                Context.DataContextStack.Pop();
            }else
            {
                OnGUI();
            }
        }

        protected virtual void OnGUI()
        {
            foreach (var child in Children)
                child.Execute();
        }
    }
}
