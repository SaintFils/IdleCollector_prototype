using UnityEngine;

namespace Client.Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        
        public Vector2 Axis => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}