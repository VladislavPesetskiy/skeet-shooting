using System;
using UI;
using UnityEngine;

namespace GameCore
{
    public class AimProgressListener : MonoBehaviour
    {
        [SerializeField] private TargetChecker m_targetChecker = null;
        [SerializeField] private AimProgressBar m_aimProgressBar = null;
        [SerializeField] private Shooter m_shooter = null;
        [SerializeField] private float m_minTimeFillProgress = 0f;
        [SerializeField] private float m_maxTimeFillProgress = 0f;
        
        private float m_timerValue = 0f;
        private float m_maxTimeValue = 0f;
        
        private void Awake()
        {
            m_targetChecker.EventSkeetIn += StartTimer;
            m_targetChecker.EventTargetOut += ResetTimer;
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void StartTimer(float skeetFlyingProgress)
        {
            m_timerValue = skeetFlyingProgress;
            
            // Formula for calculate time filling progress
            m_maxTimeValue = Mathf.Lerp(m_minTimeFillProgress, m_maxTimeFillProgress, skeetFlyingProgress);
        }

        private void ResetTimer()
        {
            m_timerValue = 0f;
            m_aimProgressBar.ResetProgress();
        }

        private void UpdateTimer()
        {
            if(m_timerValue <= 0) return;
            if (m_targetChecker.InTargetSkeet == null)
            {
                ResetTimer();
                return;
            }
            if(m_targetChecker.InTargetSkeet.FlyingProgress >= 0.98f)
            {
                m_shooter.SkeetShoot(m_targetChecker.InTargetSkeet, (m_maxTimeValue - m_timerValue) / m_maxTimeValue);
                ResetTimer();
                return;
            }
            

            m_timerValue -= Time.deltaTime;
            m_aimProgressBar.SetProgress(m_maxTimeValue - m_timerValue, m_maxTimeValue);
            
            if (m_timerValue <= 0)
            {
                ResetTimer();
                m_shooter.SkeetShoot(m_targetChecker.InTargetSkeet);
            }
        }
    }
}