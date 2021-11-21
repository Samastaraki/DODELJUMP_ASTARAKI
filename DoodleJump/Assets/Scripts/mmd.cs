using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mmd : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Sakhre;
    public int score;
    public Text scoreBoard;
    public bool isPlaying;
    // Start is called before the first frame update

    public GameObject tryAgain;
    
    void Start()
    {
        score = 0;
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {

            scoreBoard.text = score.ToString();
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.03f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.03f, 0f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sakhre")
        {
            score++;
            Vector3 mmd=new Vector3((float)Random.Range(-7, 7), this.transform.position.y + 6f, 0f);
            Instantiate(Sakhre,mmd,Quaternion.identity);
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(0f, 500f));
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            isPlaying = false;
            tryAgain.SetActive(true);
        }
    }

    public void Again()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
