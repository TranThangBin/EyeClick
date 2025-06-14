using UnityEngine;

namespace Game
{
    public class GameOverTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverMenu;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                _gameOverMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

        private void OnDestroy() => Time.timeScale = 1;
    }
}
