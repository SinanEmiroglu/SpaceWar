using System;
using UnityEngine;

namespace SpaceWar
{
    public class SkillInputAction : MonoBehaviour
    {
        public static event Action<int> OnButtonClicked = delegate { };

        /// <summary>
        /// Called in the click events of the skill UI buttons
        /// </summary>
        public void SkillButtonClickByIndex(int index)
        {
            OnButtonClicked?.Invoke(index);
        }
    }
}