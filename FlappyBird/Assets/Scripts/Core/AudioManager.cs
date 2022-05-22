using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioManager
{
    [SerializeField]
    AudioClip[] m_Score;
    
    [SerializeField]
    AudioClip[] m_Lose;
    [SerializeField]
    AudioClip[] m_Flap;
    
    [SerializeField]
    AudioClip[] m_ButtonPress;

    public void PlayScore()
    {
        if (m_Score?.Length > 0)
            AudioSource.PlayClipAtPoint(m_Score[Random.Range(0, m_Score.Length - 1)], Vector3.zero);
    }

    public void PlayLose()
    {
        if (m_Lose?.Length > 0)
            AudioSource.PlayClipAtPoint(m_Lose[Random.Range(0, m_Lose.Length - 1)], Vector3.zero);
    }

    public void PlayFlap()
    {
        if (m_Flap?.Length > 0)
            AudioSource.PlayClipAtPoint(m_Flap[Random.Range(0, m_Flap.Length - 1)], Vector3.zero);
    }

    public void PlayPress()
    {
        if (m_ButtonPress?.Length > 0)
            AudioSource.PlayClipAtPoint(m_ButtonPress[Random.Range(0, m_ButtonPress.Length - 1)], Vector3.zero);
    }
}
