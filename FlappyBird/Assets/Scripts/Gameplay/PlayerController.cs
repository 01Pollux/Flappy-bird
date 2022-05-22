using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_FlyForce = 5f;

    private Vector3 m_Direction;
    private Animator m_Animator;

    public void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void OnEnable()
    {
        transform.position = Vector3.zero;
        m_Direction.y = m_FlyForce;
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_Direction.y = m_FlyForce;
            m_Animator.SetTrigger("Flap");
            GameManager.Main.OnFlap();
        }
        
        float delta_time = Time.deltaTime;
        m_Direction.y += Physics2D.gravity.y * delta_time;
        transform.position += m_Direction * delta_time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            GameManager.Main.EndGame();
        else if (collision.CompareTag("PipeScore"))
            GameManager.Main.OnScore();
    }
}
