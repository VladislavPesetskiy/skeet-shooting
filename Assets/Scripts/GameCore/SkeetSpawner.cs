using UnityEngine;

namespace GameCore
{
    public class SkeetSpawner : MonoBehaviour
    {
        [SerializeField] private Skeet m_skeetPrefab = null;
        [SerializeField] private Transform m_leftSpawnPoint = null;
        [SerializeField] private Transform m_rightSpawnPoint = null;

        [Header("Spawn Parameters")] 
        [SerializeField] private int m_pathPointCount = 20;
        [SerializeField] private AnimationCurve m_flyCurve = null;
        [SerializeField] private Vector3 m_minFlyPosition = Vector3.zero;
        [SerializeField] private Vector3 m_maxFlyPosition = Vector3.zero;
        
        public void SpawnSkeet()
        {
            bool isToLeftFly = Random.value > 0.5f;
            var spawnPoint = isToLeftFly ? m_leftSpawnPoint : m_rightSpawnPoint;
            var skeet = Instantiate(m_skeetPrefab, spawnPoint.position, Quaternion.identity, spawnPoint.transform);
            skeet.FlyByPath(CreatePath(isToLeftFly));
        }

        private Vector3[] CreatePath(bool isToLeftFly)
        {
            Vector3[] path = new Vector3[m_pathPointCount];
            float positionX = 0f;
            float positionY = 0f;
            float positionZ = 0f;
            
            float endPositionX = Random.Range(m_minFlyPosition.x, m_maxFlyPosition.x);
            float endPositionZ = Random.Range(m_minFlyPosition.z, m_maxFlyPosition.z);
            
            for (int i = 0; i < path.Length; i++)
            {
                float t = (float)i / (path.Length - 1);

                positionX += endPositionX / path.Length * (isToLeftFly ? 1f : -1f);
                positionZ += endPositionZ / path.Length;
                positionY = Mathf.Lerp(m_minFlyPosition.y, m_maxFlyPosition.y, m_flyCurve.Evaluate(t));
                
                Vector3 position = new Vector3(positionX, positionY, positionZ);

                path[i] = position;
            }

            return path;
        }
    }
}