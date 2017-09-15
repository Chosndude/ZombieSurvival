using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerMovement : MonoBehaviour {

    // Use this for initialization
    Vector3 velocity;
    float normalSpeed = 10f;
    float maxSpeed = 10f;
    float superSpeed = 30f;
    float reload = 60f;
    bool active;
    public Text cooldownText;
    float timer;
    void Start()
    {
        if (PlayerPrefs.GetFloat("move") > 0)
        {
            normalSpeed = PlayerPrefs.GetFloat("move");
            maxSpeed = normalSpeed;
            superSpeed = maxSpeed * 3;
        }
    }
	// Update is called once per frame
	void Update () {
        if (active)
        {
            timer += Time.deltaTime;
            cooldownText.text = "" + (int)(reload - timer);
        }
        if (timer > 5)
            maxSpeed = normalSpeed;
        if (timer > reload)
        {
            timer = 0;
            active = false;
            cooldownText.text = "";
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, ballMovement.minX+.6f, ballMovement.maxX-.6f),Mathf.Clamp(transform.position.y,ballMovement.minY+.6f,ballMovement.maxY-.6f),-1);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        RaycastHit hit, hit2;
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit2, 2f))
        {

            if (hit.transform.gameObject.CompareTag("slope"))
            {
                velocity.y = v / 1.4f * Time.deltaTime * maxSpeed;
                GetComponent<Rigidbody>().useGravity = false;
            }

            }
        else {
            velocity.y = 0;
            GetComponent<Rigidbody>().useGravity = true;
        }*/
    }
    
    void Move(float h,float v)
    {
        //player.SetDestination(new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v));
        velocity = new Vector3(h*Time.deltaTime*maxSpeed, 0f,v*Time.deltaTime*maxSpeed);
        transform.Translate(velocity);
        //print(transform.rotation + " " + GetComponentInChildren<Light>().transform.rotation);
    }
    public void shoot()
    {
        active = true;
        maxSpeed = superSpeed;
    }

    

}
