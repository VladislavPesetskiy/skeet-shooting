using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image m_progressSource = null;

        protected float m_progress = 0f;

        public virtual void SetProgress(float progress)
        {
            m_progress = progress;
            m_progressSource.fillAmount = m_progress;
        }

        public virtual void ResetProgress()
        {
            m_progress = 0f;
            m_progressSource.fillAmount = 0f;
        }
    }
}