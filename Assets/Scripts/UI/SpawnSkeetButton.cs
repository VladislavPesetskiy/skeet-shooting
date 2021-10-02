using UnityEngine;

namespace UI
{
    public class SpawnSkeetButton : MonoBehaviour
    {
        public void SetActiveButton(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}