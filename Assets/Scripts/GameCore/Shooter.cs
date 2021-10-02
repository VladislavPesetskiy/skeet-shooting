using UnityEngine;

namespace GameCore
{
    public class Shooter : MonoBehaviour
    {
        public void SkeetShoot(Skeet skeet)
        {
            if(skeet == null) return;
            skeet.Destroy();
        }
    }
}