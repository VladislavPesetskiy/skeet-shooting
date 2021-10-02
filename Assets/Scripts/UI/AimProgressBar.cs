using System;
using GameCore;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AimProgressBar : ProgressBar
    {
        public override void SetProgress(float currentValue, float maxValue)
        {
            base.SetProgress(currentValue, maxValue);
        }
    }
}
