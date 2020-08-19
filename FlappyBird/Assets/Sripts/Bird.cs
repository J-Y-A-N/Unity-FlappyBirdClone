using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

	public float speed;
	Rigidbody2D rb;

	public Score scoreText;
	public GameObject replayBtn;

	// Use this for initialization
	void Start() {
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * speed;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Column"))
		{
			scoreText.ScoreUp();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
			Time.timeScale = 0;
			replayBtn.SetActive(true);
        }
    }

	public void ReplayGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
