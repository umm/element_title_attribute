using UnityEngine;

namespace UnityModule
{
    public class ElementTitleAttribute : PropertyAttribute
    {
        public string FieldName { get; }

        public ElementTitleAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}