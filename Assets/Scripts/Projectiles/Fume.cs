using UnityEngine;

namespace Game
{
    public class Fume : MonoBehaviour, IProjectile
    {
        [SerializeField] private ParticleSystem _ps;

        public void Fire(Vector2 direction)
        {
        }

        private void OnParticleCollision(GameObject other)
        {
            Debug.Log("hello");
        }

        private void OnParticleTrigger()
        {
        }
    }
}
