using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameSessionManager
{
    /// <summary>
    /// Управление игровой сессией
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int _enemyToDestroyMin = 15;
        [SerializeField] private int _enemyToDestroyMax = 20;
        [SerializeField] private GameObject _winCanvas;
        [SerializeField] private GameObject _looseCanvas;
        [SerializeField] private Button _restartButtonWin;
        [SerializeField] private Button _restartButtonLoose;
        private int _enemyToDestroy;

        public int CountOfDestroyedEnemy { get; set; }
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            _restartButtonWin.onClick.AddListener(Restart);
            _restartButtonLoose.onClick.AddListener(Restart);
        }

        private void Start()
        {
            _enemyToDestroy = Random.Range(_enemyToDestroyMin, _enemyToDestroyMax);
        }

        public void CheckWin()
        {
            if (CountOfDestroyedEnemy < _enemyToDestroy) return;

            _winCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        public void Loose()
        {
            _looseCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}