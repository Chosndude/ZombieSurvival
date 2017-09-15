using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour
{
    public AudioSource jumpSound;
    float reload = 2f;
    bool active;
    float timer;
    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
        }
        if (timer >= reload)
        {
            timer = 0;
            active = false;
        }
    }
    public void shoot()
    {
        if (!active)
        {
            jumpSound.Play();
            active = true;
            GetComponent<Rigidbody>().AddForce(Vector3.up * 600f);
        }
    }
}
