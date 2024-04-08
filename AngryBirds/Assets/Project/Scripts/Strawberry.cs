using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;


    Rigidbody2D rb;
    bool hasHit; 

    private static int chances = 0;

    //to create top strawberry bar
    public Image[] lives;
    public Sprite fullStrawberry;
    public Sprite emptyStrawberry;

    void Start() {

        rb = GetComponent<Rigidbody2D>();

    }

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        //set the images for the top bar (I'm confused on how this is working)
        foreach (Image img in lives)
        {
            img.sprite = fullStrawberry;
        }
        for (int i = 0; i < chances; i++)
        {
            lives[i].sprite = emptyStrawberry;
        }
    
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (chances < 3) {

            if (_birdWasLaunched &&
                GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            {
                _timeSittingAround += Time.deltaTime;
                
            }

            //set to 2 because the scene reinstantiates an additional time
            
            if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            _timeSittingAround > 3)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
                chances++;
                Debug.Log("You used " + chances + " chances");
                
            }

            
        }

        if (chances == 3) {
            Debug.Log("Level complete!");
            FindObjectOfType<SceneLoader>()?.GoToNextScene();
            chances = 0;
            return;
        }
        
    }

   private void OnMouseDown()
   {
        // GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
   }

   private void OnMouseUp()
   {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
   }

   private void OnMouseDrag()
   {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
   }

    // to make the strawberry stick upon collision
   private void OnCollisionEnter2D(Collision2D collision) {

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
   }

}
