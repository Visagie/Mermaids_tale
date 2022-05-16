using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public Slider trashmeter;
    public int trash_collected, trash_divider, totaltrash;
    bool apressed, dpressed, spressed, wpressed;
    float speed = 25.0f;
    Rigidbody2D player;
    public float trashdiv;
    bool ispaused;
    public GameObject itself;
    public Material material1;
    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        
        ispaused = true;
        trashmeter.value = 0;
        player = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                resume();
            }
            else
            {
                Pause();
            }
        }

       
        movement();
        
       
        
        

    }
    private void FixedUpdate()
    {
        #region
        if (Input.GetKey(KeyCode.W))
        {
            wpressed = true;
        }
        else
        {
            wpressed = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            spressed = true;
        }
        else
        {
            spressed = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            apressed = true;
        }
        else
        {
            apressed = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dpressed = true;
        }
        else
        {
            dpressed = false;
        }
        #endregion

        if(trashmeter.value == 1)
        {
            winning_condition();
        }
    }

    void movement()
    {
        #region
        if (apressed)
        {
            player.AddForce(Vector3.left * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        
        
         
        
        if (dpressed)
        {
            player.AddForce(Vector3.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        if (wpressed)
        {
            player.AddForce(Vector3.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        if (spressed)
        {
            player.AddForce(Vector3.down * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        #endregion
    }

   

    void trashcollection()
    {
        var a = 1 / trashdiv;

        trashmeter.value+= a;
    }


    private void Pause()
    {
        
    }

    public void resume()
    {
        
        
    }

    void winning_condition()
    {
        
    }

    void gameend()
    {
        
    }

    public void tryagain()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void exitapp()
    {
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "collect") 
        {
            trashcollection();
        }

        if (other.gameObject.tag == "trashbox")
        {
            trashmeter.value = 0;
        }

        if (other.gameObject.tag == "oilbarrel")
        {
            Destroy(other.gameObject);
            StartCoroutine(oilspil());
        }

        if (other.gameObject.tag == "collect")
        {
            Destroy(other.gameObject);
            
        }
    }

    IEnumerator oilspil()
    {
        speed = 12.5f;
        itself.GetComponent<Renderer>().material = material2;
        yield return new WaitForSeconds(1f);

    }
}
