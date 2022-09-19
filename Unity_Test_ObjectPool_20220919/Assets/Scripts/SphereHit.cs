using System;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// ²yÅé¸I¼²
    /// </summary>
    public class SphereHit : MonoBehaviour
    {
        private Action<GameObject> actionHit;

        public void Init(Action<GameObject> _actionHit)
        {
            actionHit = _actionHit;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "¦aªO")
            {
                actionHit(gameObject);
            }
        }
    }
}
