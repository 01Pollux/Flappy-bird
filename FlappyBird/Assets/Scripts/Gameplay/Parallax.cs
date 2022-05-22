using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float m_ScrollSpeed = 0f;
    private Material m_MeshMat;

    private void Start()
    {
        m_MeshMat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        m_MeshMat.mainTextureOffset += new Vector2(m_ScrollSpeed * Time.deltaTime, 0f);
    }
}
