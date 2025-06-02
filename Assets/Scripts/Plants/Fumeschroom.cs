using UnityEngine;

namespace Game
{
    public class Fumeschroom : Plant
    {
        private enum FumeshroomState { COOLDOWN, READY, ATTACK }

        [SerializeField] private GameObject _projectile;
        [SerializeField] private Timer _rechargeTimer;

        private FumeshroomState _state = FumeshroomState.COOLDOWN;

        private void Update()
        {
            switch (_state)
            {
                case FumeshroomState.READY:
                    {
                        RaycastHit2D rc = Physics2D.Raycast(transform.position, Vector2.right, 100, LayerMask.GetMask("Enemy"));
                        Debug.DrawRay(transform.position, Vector3.right * 100, Color.red);
                        if (rc.collider != null)
                        {
                            _state = FumeshroomState.ATTACK;
                        }
                    }
                    break;
                case FumeshroomState.ATTACK:
                    {
                        GameObject gameObject = Instantiate(_projectile, transform.position + (Vector3.right / 2), Quaternion.identity, transform.parent);
                        IProjectile projectile = gameObject.GetComponent<IProjectile>();
                        projectile.Fire(Vector2.right);

                        _state = FumeshroomState.COOLDOWN;
                        _rechargeTimer.TimerRestart();
                    }
                    break;
                case FumeshroomState.COOLDOWN:
                    if (_rechargeTimer.TimerIsStopped())
                    {
                        _rechargeTimer.TimerStart();
                    }
                    break;
                default:
                    throw new UnityException();
            }
        }

        public void OnTimerTimeOut()
        {
            _state = FumeshroomState.READY;
        }
    }
}
