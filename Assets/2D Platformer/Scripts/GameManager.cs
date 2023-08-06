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
        [SerializeField] private GameObject panel, textPanel;

        private float wait;

        private void Start()
        {
            Time.timeScale = 1;
        }

        private void Update()
        {
            KillText.text = KillsCounter.ToString() + "/" + CountEnemiesOnLvl;

            if (KillsCounter < CountEnemiesOnLvl)
                wait += Time.deltaTime;

            if (Input.anyKeyDown)
                wait = 0;
            if (wait >= 20)
                OpenEndPanel(true);
        }

        public void CheckFinish()
        {
            if (KillsCounter == CountEnemiesOnLvl)
            {
                PlaySound("Finish");
                OpenEndPanel(false);
            }
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

        private void OpenEndPanel(bool win)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            if (!win)
                textPanel.GetComponent<Text>().text = "О нет! Все герои погибли, мир обречен! А ты проиграл :))";
            else
                textPanel.GetComponent<Text>().text = "Благодаря тебе герои спасут мир! 'Иногда, чтобы победить, нужно ничего не делать' @Джейсон Стетхем ";
        }
    }
}
