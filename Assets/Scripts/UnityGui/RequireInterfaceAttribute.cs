using System;
using UnityEngine;

namespace UnityGui
{
    public class RequireInterfaceAttribute : PropertyAttribute
    {
        public Type RequiredType { get; private set; }
        
        public RequireInterfaceAttribute(Type requiredType)
        {
            RequiredType = requiredType;
        }
    }
}