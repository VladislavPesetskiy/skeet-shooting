using System;
using UnityEngine;

namespace GameCore
{
    public class TargetChecker : MonoBehaviour
    {
        [SerializeField] private Camera m_mainCamera = null;
        [SerializeField] private LayerMask m_targetLayer = default;
        //[SerializeField] private float m_raycastLength = 100f;

        private bool m_inTarget = false;
        private Skeet m_inTargetSkeet = null;
        public Skeet InTargetSkeet => m_inTargetSkeet;

        public Action<float> EventSkeetIn;
        public Action EventTargetOut;

        #region Raycast variation

        /*private void Update()
        {
            CheckTarget();
        }*/
        
        /*private void CheckTarget()
        {
            var cameraTransform = m_mainCamera.transform;
            var from = cameraTransform.position;
            var direction = cameraTransform.forward;

            if (Physics.Raycast(from, direction, out var targetHit, m_raycastLength, m_targetLayer))
            {
                if (m_inTarget == false && targetHit.transform.TryGetComponent(out Skeet skeet))
                {
                    m_inTarget = true;
                    m_inTargetSkeet = skeet;
                    EventSkeetIn?.Invoke(skeet.FlyingTime);
                }
            }
            else
            {
                if (m_inTarget)
                {
                    EventTargetOut?.Invoke();
                    m_inTarget = false;
                    m_inTargetSkeet = null;
                }
            }
        }*/

        /*private void OnDrawGizmos()
        {
            if(m_mainCamera == null) return;
            
            Gizmos.color = Color.blue;
            var cameraTransform = m_mainCamera.transform;
            var cameraPosition = cameraTransform.position;
            Gizmos.DrawLine(cameraPosition, cameraPosition + transform.forward * m_raycastLength);
        }*/

        #endregion

        public void ResetTarget()
        {
            m_inTargetSkeet = null;
            EventTargetOut?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Skeet skeet))
            {
                m_inTargetSkeet = skeet;
                EventSkeetIn?.Invoke(skeet.FlyingProgress);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Skeet skeet))
            {
                ResetTarget();
            }
        }
    }
}