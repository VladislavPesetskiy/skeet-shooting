using UnityEngine;

namespace GameCore
{
    public class InputSystem : MonoBehaviour
    {
        private Vector3 m_mousePositionTemp = Vector3.zero;
        private Vector3 m_mousePosition => Input.mousePosition;
    
        private Vector2 m_inputDelta = Vector2.zero;
        public Vector2 InputDelta => m_inputDelta;

        private void Update()
        {
            UpdateInputDirection();
        }

        private void UpdateInputDirection()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_mousePositionTemp = m_mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                m_inputDelta = m_mousePositionTemp - m_mousePosition;
                m_mousePositionTemp = m_mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                m_inputDelta = Vector2.zero;
            }
        }
    }
}
