using UnityEngine;

namespace _4_Collisions.Scripts
{
    public class MoveViaInput : MonoBehaviour
    {
        private const string HorizontalAxisName = "Horizontal";
        [SerializeField] private float speed = 1;
        private void Update()
        {
            transform.Translate(Input.GetAxis(HorizontalAxisName) * speed * Time.deltaTime * transform.right);
        }
    }
}
