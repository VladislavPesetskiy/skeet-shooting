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
            m_maxTimeValue = skeetFlyingProgress;
        }

        private void ResetTimer()
        {
            m_timerValue = 0f;
            m_aimProgressBar.SetProgress(m_timerValue, m_maxTimeValue);
        }

        private void UpdateTimer()
        {
            if(m_timerValue <= 0) return;

            m_timerValue -= Time.deltaTime;
            if (m_timerValue <= 0)
            {
                ResetTimer();
                m_shooter.SkeetShoot(m_targetChecker.InTargetSkeet);
            }
            
            m_aimProgressBar.SetProgress(m_maxTimeValue - m_timerValue, m_maxTimeValue);
        }
    }
}