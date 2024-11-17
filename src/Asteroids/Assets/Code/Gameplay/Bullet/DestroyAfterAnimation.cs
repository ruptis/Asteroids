using UnityEngine;

namespace Asteroids.Code.Gameplay.Bullet
{
    [RequireComponent(typeof(Animator))]
    public sealed class DestroyAfterAnimation : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}