using UnityEngine;

namespace Game
{
    public class BasicZombie : MonoBehaviour
    {
        [SerializeField] private float _velocity;
        [SerializeField] private float _damage;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Timer _attackTimer;

        private HealthManager _plantHealth;

        private void Start()
        {
            _rb.linearVelocity = _velocity * Vector2.left;
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Ally"));
            Debug.DrawRay(transform.position, Vector2.left / 2, Color.black);

            if (hit.collider != null &&
                hit.collider.gameObject.TryGetComponent(out _plantHealth) &&
                _attackTimer.TimerIsStopped())
            {
                _rb.linearVelocity = Vector2.zero;
                _plantHealth.ReduceHealth(_damage);
                _attackTimer.TimerStart();
            }
        }

        public void OnTimerTimeOut()
        {
            if (_plantHealth != null)
            {
                _plantHealth.ReduceHealth(_damage);
                _attackTimer.TimerRestart();
            }

            if (_plantHealth == null || _plantHealth.IsOutOfHealth())
            {
                _rb.linearVelocity = _velocity * Vector2.left;
                _plantHealth = null;
                _attackTimer.TimerReset();
            }
        }
    }
}
