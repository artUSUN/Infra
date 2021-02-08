using UnityEngine;

namespace Source.Code.Task_1.Troopers.Components
{
    public class MoverComponent
    {
        private readonly Transform tr;
        private readonly Rigidbody rb;
        private readonly float speed;

        public MoverComponent(TrooperBehaviour trooper)
        {
            tr = trooper.Transform;
            rb = trooper.GetComponent<Rigidbody>();
            speed = trooper.Settings.MoveSpeed;
        }

        public void Move(Vector3 targetPoint)
        {
            SetRotationToTarget(targetPoint);

            rb.AddForce(tr.forward * speed * Time.fixedDeltaTime);

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed); 
        }

        private void SetRotationToTarget(Vector3 targetPoint)
        {
            targetPoint.y = tr.position.y;
            tr.LookAt(targetPoint);
        }
    }
}
