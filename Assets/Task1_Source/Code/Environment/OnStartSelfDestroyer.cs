using UnityEngine;

namespace Task1.Source.Code.Environment
{
    public class OnStartSelfDestroyer : MonoBehaviour
    {
        private void Start()
        {
            Destroy(this.gameObject);
        }
    }
}