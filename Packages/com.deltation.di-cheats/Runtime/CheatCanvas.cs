using UnityEngine;

namespace DELTation.DIFramework.Cheats
{
    public class CheatCanvas : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}