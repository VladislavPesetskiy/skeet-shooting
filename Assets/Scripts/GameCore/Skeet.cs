using System;
using DG.Tweening;
using UnityEngine;

namespace GameCore
{
    public class Skeet : MonoBehaviour
    {
        [SerializeField] private float m_flyDuration = 0f;
        [SerializeField] private ParticleSystem m_explosionFX = null;

        private Action m_onComplete;

        private float m_flyingTimer = 0f;
        public float FlyingProgress => m_flyingTimer / m_flyDuration;

        public void FlyByPath(Vector3[] path, Action onComplete)
        {
            transform.DOLocalPath(path, m_flyDuration).SetEase(Ease.Linear).OnComplete(DeInit);
            m_onComplete = onComplete;
        }

        public void Destroy()
        {
            m_explosionFX.transform.parent = null;
            m_explosionFX.Play();
            DeInit();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            m_flyingTimer += Time.deltaTime;
        }

        private void DeInit()
        {
            m_onComplete?.Invoke();
            Destroy(gameObject);
        }
    }
}