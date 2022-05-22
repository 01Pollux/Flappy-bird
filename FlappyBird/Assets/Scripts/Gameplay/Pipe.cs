using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] 
    private float m_Speed = 4f;
    private float m_LeftEdge;

    public float SpeedFactor => m_Speed;

    private void Start()
    {
        m_LeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > m_LeftEdge)
        {
            transform.position += m_Speed * Time.deltaTime * Vector3.left;
            m_Speed += (GameManager.Main.SpeedFactor / 100f) * Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }
}
