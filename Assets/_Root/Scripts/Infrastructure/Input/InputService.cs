namespace Infrastructure
{
    public class InputService
    {
        private readonly InputActions inputActions = new();

        public InputActions Input => inputActions;
        
        public void Enable() => inputActions.Enable();
        public void Disable() => inputActions.Disable();
        
    }
}