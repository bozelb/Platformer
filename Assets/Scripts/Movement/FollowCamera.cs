using UnityEngine;
using Platformer.Movement;

namespace Platformer.Movement
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] GameObject followObject;

        private void Update()
        {
            //transform.position = transform.forward + followObject.transform.position;
        }
    }
}
