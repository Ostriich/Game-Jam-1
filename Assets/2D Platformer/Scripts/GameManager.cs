using System.Collections;
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
        [SerializeField] private AudioClip coinSound, killSound, finishSound;

        private void Update()
        {
            KillText.text = KillsCounter.ToString() + "/" + CountEnemiesOnLvl;
        }

        public void CheckFinish()
        {
            if (KillsCounter == CountEnemiesOnLvl)
                StartCoroutine(Delay());
        }

        public void PlaySound(string type)
        {
            switch (type)
            {
                case "Coin":
                    GetComponent<AudioSource>().PlayOneShot(coinSound);
                    break;
                case "Kill":
                    GetComponent<AudioSource>().PlayOneShot(killSound);
                    break;
                case "Finish":
                    GetComponent<AudioSource>().PlayOneShot(finishSound);
                    break;
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.75f);
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }
}
