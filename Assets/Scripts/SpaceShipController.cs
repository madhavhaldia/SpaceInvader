using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float BeamDuration;
    float BeamDurationBuffer;
    public LineRenderer projectile;
    public float projectileWidth;
    public GameObject[] healthIcon;
    int health;

    public RaycastHit hit;
    public bool didHit;
    // Start is called before the first frame update
    void Start()
    {

        projectile.enabled = false;
        projectile.startWidth = projectileWidth;
        projectile.endWidth = projectileWidth;
        BeamDurationBuffer = BeamDuration;
        health = healthIcon.Length;
        didHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        BeamTimer();
        
        Move();
    }

    private void OnMouseDown()
    {
        Fire();
    }

    void Move()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        this.transform.position = new Vector3(Mathf.Clamp((this.transform.position.x), -2, 2), -4.0f, 0);
    }
    void Fire()
    {
        BeamDuration = BeamDurationBuffer;
        
        Vector3 endPosition = transform.position + (Vector3.up * 1000);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            endPosition = hit.point;
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            
            if (hit.transform.gameObject == GameObject.FindGameObjectWithTag("Enemy")) 
            {
                Debug.Log("Hit Enemy");
                didHit = true;
            }
            else
            {
                Debug.Log("Hit Something");
                didHit = false;
            }
        }
        else
        {
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
            // Debug.Log("Did not Hit");
            didHit = false;
        }
        projectile.SetPosition(0, this.transform.position);
        projectile.SetPosition(1, endPosition);
        projectile.enabled = true;
    }

    void BeamTimer()
    {
        if(BeamDuration>=0)
        {
            BeamDuration -= Time.deltaTime;
            //Debug.Log(BeamDuration);
            if (BeamDuration <= 0)
            {
                projectile.enabled = false;
                return;
            }
                
        }
    }
    void TakeDamage()
    {
        if (healthIcon.Length>0)
        {
            Destroy(healthIcon[health]);
            health -= 1;
        }
    }
}
