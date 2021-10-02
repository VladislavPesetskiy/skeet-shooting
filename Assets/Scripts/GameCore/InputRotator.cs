using UnityEngine;

namespace GameCore
{
    public class InputRotator : MonoBehaviour
    {
        [SerializeField] private InputSystem m_inputSystem = null;
        [SerializeField] private Transform m_rotatableRoot = null;

        [Header("Parameters")] 
        [Range(0f, 1f)]
        [SerializeField] private float m_sensitivity = 1f;
    
        [Header("Clamps")]
        [SerializeField] private Vector3 m_minRotation = Vector3.zero;
        [SerializeField] private Vector3 m_maxRotation = Vector3.zero;
    
        private void Update()
        {
            UpdatedRotation();
        }

        private void UpdatedRotation()
        {
            var vectorRotate = new Vector3(m_inputSystem.InputDelta.y, m_inputSystem.InputDelta.x * -1, 0f);
            var targetAngles = m_rotatableRoot.eulerAngles + vectorRotate * m_sensitivity;
        
            targetAngles.x = ClampEulerAngle(targetAngles.x, m_minRotation.x, m_maxRotation.x);
            targetAngles.y = ClampEulerAngle(targetAngles.y, m_minRotation.y, m_maxRotation.y);
        
            m_rotatableRoot.eulerAngles = targetAngles;
        }
    
        private float ClampEulerAngle(float angle, float from, float to)
        {
            if (angle < 0f) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360+from);
            return Mathf.Min(angle, to);
        }
    }
}
