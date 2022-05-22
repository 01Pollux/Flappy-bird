using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float m_SpawnRate = 1f;
    [SerializeField]
    private Vector2 m_SpawnPosition = new(-2f, 2f);
    [SerializeField]
    private Pipe m_Pipe;

    public float SpawnRate => m_SpawnRate;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), m_SpawnRate, m_SpawnRate);
    }

    private void SpawnPipe()
    {
        Pipe pipe = Instantiate(m_Pipe, transform);
        pipe.transform.position = new Vector3(pipe.transform.position.x, Random.Range(m_SpawnPosition.x, m_SpawnPosition.y), 0f);
    }
}
