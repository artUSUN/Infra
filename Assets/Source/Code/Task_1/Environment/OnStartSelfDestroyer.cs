using UnityEngine;

namespace Source.Code.Task_1.Environment
{
    public class OnStartSelfDestroyer : MonoBehaviour
    {
        private void Start()
        {
            Destroy(this.gameObject);
        }
    }
}