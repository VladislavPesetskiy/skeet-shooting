using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image m_progressSource = null;

        protected float m_progress = 0f;

        public virtual void SetProgress(float currentValue, float maxValue)
        {
            m_progress = currentValue / maxValue;
            m_progressSource.fillAmount = m_progress;
        }
    }
}