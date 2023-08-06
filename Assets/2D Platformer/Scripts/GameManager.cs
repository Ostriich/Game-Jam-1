using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int KillsCounter = 0;

        public GameObject playerGameObject;
        public GameObject deathPlayerPrefab;
        public Text KillText;
        [SerializeField] private int CountEnemiesOnLvl;


        private void Update()
        {
            KillText.text = KillsCounter.ToString() + "/" + CountEnemiesOnLvl;
        }

        public void CheckFinish()
        {
            if (KillsCounter == CountEnemiesOnLvl)
                SceneManager.LoadScene(Application.loadedLevel);
        }
    }
}
