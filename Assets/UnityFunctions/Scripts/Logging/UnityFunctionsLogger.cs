using UnityEngine;

namespace UnityFunctions.Logging
{
    public class UnityFunctionsLogger : MonoBehaviour
    {
        public bool shouldLogFixedUpdate;
        public bool shouldLogUpdate;
        public bool shouldLogLateUpdate;

        private void Awake()
        {
            Debug.Log($"{name}: Awake");
        }

        private void OnEnable()
        {
            Debug.Log($"{name}: {nameof(OnEnable)}");
        }

        private void Start()
        {
            Debug.Log($"{name}: {nameof(Start)}");
        }

        private void FixedUpdate()
        {
            if (shouldLogFixedUpdate)
            {
                Debug.Log($"{name}: {nameof(FixedUpdate)}");
            }
        }

        private void Update()
        {
            if (shouldLogUpdate)
            {
                Debug.Log($"{name}: {nameof(Update)}");
            }
        }

        private void LateUpdate()
        {
            if (shouldLogLateUpdate)
            {
                Debug.Log($"{name}: {nameof(LateUpdate)}");
            }
        }

        private void OnDisable()
        {
            Debug.Log($"{name}: {nameof(OnDisable)}");
        }
    }
}