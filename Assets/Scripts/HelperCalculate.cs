using UnityEngine;

namespace Assets.Scripts
{
    public static class HelperCalculate
    {
        public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
        {
            //h = v^2/2g
            //2gh = v^2
            //sqrt(2gh) = v
            return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
        }
    }
}
