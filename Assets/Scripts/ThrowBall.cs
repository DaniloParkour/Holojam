using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public static ThrowBall instance;

    public EnemyBullet bullet;

    private List<EnemyBullet> bullets;

    [SerializeField]
    private float randTimeMin;
    [SerializeField]
    private float randTimeMax;

    private float timeToShot;
    private int currentBullet = 0;
    
    // Use this for initialization
    void Start () {

        instance = this;

        timeToShot = Random.Range(randTimeMin, randTimeMax);
        bullets = new List<EnemyBullet>();
        for(int i = 0; i < 5; i++) {
            EnemyBullet obj = Instantiate(bullet, transform.Find("tube")) as EnemyBullet;
            bullets.Add(obj);
            obj.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        timeToShot -= Time.deltaTime;
        //if(timeToShot <= 0.2f && timeToShot > 0)
        transform.LookAt(Camera.main.transform);
        if (timeToShot <= 0) {
            if(currentBullet < bullets.Count) {
                bullets[currentBullet].gameObject.SetActive(true);
                bullets[currentBullet].shot(20);
                currentBullet++;
            }
            timeToShot = Random.Range(randTimeMin, randTimeMax);
        }
	}

    public void resetBullet(EnemyBullet b) {
        b.transform.parent = this.transform;
        b.transform.localRotation = Quaternion.identity;
        b.transform.localPosition = Vector3.zero;
        b.gameObject.SetActive(false);
        currentBullet--;
    }
}
