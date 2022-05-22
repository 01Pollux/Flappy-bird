using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Main;

    public PlayerController PlayerController;

    public uint SpeedFactor;
    public uint Score;

    [SerializeField]
    private UI m_UI;
    [SerializeField]
    private AudioManager m_Audio = new();

    private uint m_InitialSpeedFactor;

    private void Start()
    {
        Debug.Assert(Main == null);
        Main = this;
        m_InitialSpeedFactor = SpeedFactor;
        EndGame(false);
    }


    public void EndGame(bool sound = true)
    {
        Time.timeScale = 0f;

        PlayerController.enabled = false;
        m_UI.SetActive(true);

        if (sound)
            m_Audio.PlayLose();
    }

    public void StartGame()
    {
        SpeedFactor = m_InitialSpeedFactor;
        Time.timeScale = 1f;
        m_UI.SetScore(Score = 0);

        PlayerController.enabled = true;
        m_UI.SetActive(false);

        foreach (var pipe in FindObjectsOfType<Pipe>())
            Destroy(pipe.gameObject);

        m_Audio.PlayPress();
    }


    public void OnScore()
    {
        SpeedFactor++;
        m_UI.SetScore(++Score);
        m_Audio.PlayScore();
    }

    public void OnFlap()
    {
        m_Audio.PlayFlap();
    }


    [System.Serializable]
    struct UI
    {
        public Text ScoreText;
        public Image GameOverImage;
        public Button PlayButton;

        public void SetActive(bool state)
        {
            GameOverImage.gameObject.SetActive(state);
            PlayButton.gameObject.SetActive(state);
        }

        public void SetScore(uint score)
        {
            ScoreText.text = score.ToString();
        }
    }
}
