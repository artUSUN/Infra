using UnityEngine;

namespace Task1.Source.Code.Environment
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Transform tr;
        private Transform camTransform;

        private void Start()
        {
            tr = transform;
            camTransform = Camera.main.transform;
        }

        private void Update()
        {
            tr.LookAt(camTransform);
        }
    }
}