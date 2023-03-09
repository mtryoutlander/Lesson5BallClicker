using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float minSpeed = 12, maxSpeed = 16, MaxTorque = 10, xRange = 4, ySpawnPos = -6;
    private GameManager gameManager;
    [SerializeField] private int points;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position =RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.lives > 0)
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().UpdateScore(points);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (points > 0)
        {
            //gameManager.GetComponent<GameManager>().UpdateScore(-10);
            gameManager.LoseALife();
        }
        Destroy(gameObject);
    }
    
   
}
