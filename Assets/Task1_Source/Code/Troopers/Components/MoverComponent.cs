using UnityEngine;

namespace Task1.Source.Code.Troopers.Components
{
    public class MoverComponent
    {
        private readonly Transform tr;
        private readonly Rigidbody rb;
        private readonly TrooperBehaviour trooper;

        public MoverComponent(TrooperBehaviour trooper)
        {
            tr = trooper.Transform;
            rb = trooper.GetComponent<Rigidbody>();
            this.trooper = trooper;
        }

        public void Move(Vector3 targetPoint)
        {
            SetRotationToTarget(targetPoint);

            rb.AddForce(tr.forward * 10 * Time.fixedDeltaTime, ForceMode.VelocityChange);

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, trooper.Settings.MoveSpeed); 
        }


        private void SetRotationToTarget(Vector3 targetPoint)
        {
            targetPoint.y = tr.position.y;
            tr.LookAt(targetPoint);
        }
    }
}
