using System;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameCore
{
    public class SkeetSpawner : MonoBehaviour
    {
        [SerializeField] private Skeet m_skeetPrefab = null;
        [SerializeField] private SpawnSkeetButton m_spawnSkeetButton = null;
        [SerializeField] private Transform m_leftSpawnPoint = null;
        [SerializeField] private Transform m_rightSpawnPoint = null;

        [Header("Spawn Parameters")] 
        [SerializeField] private int m_pathPointCount = 20;
        [SerializeField] private AnimationCurve m_flyCurve = null;
        
        [Space]
        [SerializeField] private float m_minHeightFlying = 0f;
        [SerializeField] private float m_maxHeightFlying = 0f;
        
        [Space]
        [SerializeField] private float m_minOffsetFlyingX = 0f;
        [SerializeField] private float m_maxOffsetFlyingX = 0f;
        
        [Space]
        [SerializeField] private float m_minDistanceFlying = 0f;
        [SerializeField] private float m_maxDistanceFlying = 0f;

        public Action DestroyedSpawnedSkeet;

        private void Awake()
        {
            DestroyedSpawnedSkeet += OnDestroyedSpawnedSkeet;
        }

        public void OnSpawnSkeetButton()
        {
            m_spawnSkeetButton.SetActiveButton(false);
            
            bool isToLeftFly = Random.value > 0.5f;
            var spawnPoint = isToLeftFly ? m_leftSpawnPoint : m_rightSpawnPoint;
            var skeet = Instantiate(m_skeetPrefab, spawnPoint.position, Quaternion.identity, spawnPoint.transform);
            skeet.FlyByPath(CreatePath(isToLeftFly), DestroyedSpawnedSkeet);
        }

        private void OnDestroyedSpawnedSkeet()
        {
            m_spawnSkeetButton.SetActiveButton(true);
        }

        private Vector3[] CreatePath(bool isToLeftFly)
        {
            Vector3[] path = new Vector3[m_pathPointCount];
            float positionX = 0f;
            float positionY = 0f;
            float positionZ = 0f;
            
            float endPositionX = Random.Range(m_minOffsetFlyingX, m_maxOffsetFlyingX);
            float endPositionZ = Random.Range(m_minDistanceFlying, m_maxDistanceFlying);
            var maxHeight = Random.Range(m_minHeightFlying, m_maxHeightFlying);
            
            for (int i = 0; i < path.Length; i++)
            {
                float t = (float)i / (path.Length - 1);

                positionX += endPositionX / path.Length * (isToLeftFly ? 1f : -1f);
                positionZ += endPositionZ / path.Length;
                positionY = Mathf.Lerp(0f, maxHeight, m_flyCurve.Evaluate(t));
                
                Vector3 position = new Vector3(positionX, positionY, positionZ);

                path[i] = position;
            }

            return path;
        }
    }
}