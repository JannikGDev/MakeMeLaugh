using UnityEngine;

namespace PlayerControls.Scripts
{
    public class IInput:MonoBehaviour
    {
        public float horizontalInput { get; set; }
        public bool jumpInput { get; set; }
        public bool attackInput { get; set; }
        public bool testInput { get; set; }
    }
}