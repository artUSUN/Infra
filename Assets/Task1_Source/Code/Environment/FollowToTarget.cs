using UnityEngine;

namespace Task1.Source.Code.Environment
{
    public class FollowToTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Transform tr;
        private Vector3 distance;

        private void Start()
        {
            tr = transform;
            distance = target.position - tr.position;
        }

        private void Update()
        {
            tr.position = target.position - distance;
        }
    }
}