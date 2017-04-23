using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Vector3 vel;
    private float timeToRemove = 0;

    public int damage = 5;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(timeToRemove > 0) {
            transform.Translate(vel * Time.deltaTime);
            timeToRemove -= Time.deltaTime;
        } else {
            ThrowBall.instance.resetBullet(this.GetComponent<EnemyBullet>());
        }
	}

    public void shot(float force) {
        Vector3 dir = transform.FindChild("t").position - transform.position;
        vel = dir * force;
        timeToRemove = 7;
        transform.SetParent(null);
        //transform.localScale = new Vector3(2, 2, 2);
    }

    public void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player"))
            col.SendMessage("TakeDamage", damage);

        //Destroy(gameObject);
    }

}
