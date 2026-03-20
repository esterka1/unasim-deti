using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelDesign
{
    public class MovingPlatform : MonoBehaviour
    {

        private Rigidbody rb;

        public float moveDuration = 1f;
        public Vector3 startPoint;
        public Vector3 endPoint;

        private Vector3 _startPointWorldSpace;
        private Vector3 _endPointWorldSpace;

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Knob.png", true);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startPoint+transform.position, endPoint+transform.position);
            Gizmos.DrawWireSphere(startPoint+transform.position, 0.2f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(endPoint+transform.position, 0.2f);
        }


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            _startPointWorldSpace = startPoint + transform.position;
            _endPointWorldSpace = endPoint + transform.position;
        }
        
        private void Update()
        {
            float lerp = Mathf.PingPong(Time.fixedTime * moveDuration, 1); // goes from 0 to 1 and back to 0
            rb.MovePosition(Vector3.Lerp(_startPointWorldSpace, _endPointWorldSpace, lerp)); //move between start and end based on lerp value
        }
        

    }
}