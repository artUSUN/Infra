namespace Source.Code.Task_1.Troopers.BehaviourStates
{
    public class State
    {
        protected readonly TrooperBehaviour trooper;

        public State(TrooperBehaviour trooper)
        {
            this.trooper = trooper;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Exit() { }
    }
}
