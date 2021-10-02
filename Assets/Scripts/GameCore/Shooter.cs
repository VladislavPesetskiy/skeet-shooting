using UnityEngine;

namespace GameCore
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_shootFX = null;
        
        public void SkeetShoot(Skeet skeet)
        {
            if(skeet == null) return;
            
            m_shootFX.Play();
            skeet.Destroy();
        }

        public void SkeetShoot(Skeet skeet,float chance)
        {
            if (Random.value < chance)
            {
                SkeetShoot(skeet);
            }
        }
    }
}