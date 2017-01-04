using UnityEngine;
using System.Collections;

///Controls player movement and speed.
//Author: Vikram P.
public class pl_controller : MonoBehaviour {

    public Rigidbody2D playerBody;

    
    public float MaxSpeed = 10f;
    public float Acceleration = 0.1f;

    public float CurSpeed = 0f;
    private float Horizontal = 0.0f;
    private float Vertical = 0.0f;

	// Use this for initialization
	void Start () {
	    playerBody.freezeRotation = true;
	}
	
    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            CurSpeed = CurSpeed + Acceleration;
        }
        else
        {
            CurSpeed = 0.0f;
        }

        playerBody.velocity = new Vector2(CurSpeed * Horizontal, CurSpeed*Vertical);

    }
    // Update is called once per frame
    void Update () {

        

        if (CurSpeed > MaxSpeed)
        {
            CurSpeed = MaxSpeed;
        }


	}

    public string GetCurrentSpeed() {
        float rValue = CurSpeed * 10;
        rValue = Mathf.Round(rValue);
        rValue = rValue/10;
        return rValue.ToString();
    }
}
