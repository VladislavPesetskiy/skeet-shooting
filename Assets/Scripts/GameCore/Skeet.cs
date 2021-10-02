using System;
using DG.Tweening;
using UnityEngine;

namespace GameCore
{
    public class Skeet : MonoBehaviour
    {
        [SerializeField] private float m_flyDuration = 0f;
        [SerializeField] private float m_rotateDuration = 1f;
        [SerializeField] private Transform m_rotateRoot = null;
        [SerializeField] private ParticleSystem m_explosionFX = null;

        private float m_flyingTime = 0f;
        public float FlyingTime => m_flyingTime;

        public void FlyByPath(Vector3[] path)
        {
            transform.DOLocalPath(path, m_flyDuration).SetEase(Ease.Linear).OnComplete(DeInit);
            PlayRotateAnimation();
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

        private void PlayRotateAnimation()
        {
            var localEuler = transform.localEulerAngles;
            var rotateVector =  new Vector3(localEuler.x, 360f, localEuler.z);
            m_rotateRoot.DOLocalRotate(rotateVector, m_rotateDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }

        private void UpdateTimer()
        {
            m_flyingTime += Time.deltaTime;
        }

        private void DeInit()
        {
            Destroy(gameObject);
        }
    }
}