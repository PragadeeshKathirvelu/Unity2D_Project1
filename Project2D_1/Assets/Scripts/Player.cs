using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    private int score = 0;
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject restartText;

    public float playerSpeed;
    private float horizontalInput;
    public Color[] colorBank;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        if(gameOver==false)
        {
            InvokeRepeating("ChangeColor", 1f, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
            }
        }

        if(gameOver==true&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void ChangeColor()
    {
        if(gameOver==false)
        {
            int colorIndex = Random.Range(0, colorBank.Length);
            MeshRenderer playerMesh = GetComponent<MeshRenderer>();
            playerMesh.material.color = colorBank[colorIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer playerMesh = GetComponent<MeshRenderer>();

        if ((playerMesh.material.color == Color.blue) && (other.gameObject.CompareTag("BlueSphere")) || (playerMesh.material.color == Color.green) && (other.gameObject.CompareTag("YellowSphere")) || (playerMesh.material.color == Color.red) && (other.gameObject.CompareTag("PinkSphere")))
        {
            Debug.Log("Correct Collision Happened");
            score = score + 1;
            scoreText.text = "Score: " + score.ToString();
            gameOver = false;
        }
        else
        {
            gameOverText.SetActive(true);
            restartText.SetActive(true);
            gameOver = true;
        }
    }
}
