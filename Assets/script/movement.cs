using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] float rollSpeed;
    [SerializeField] private bool _isRotating;
    [SerializeField] private bool _isMoving;
    [SerializeField] private float rolledAngle = 0;
    [SerializeField] private float rotateTimer = 0f;
    [SerializeField] private float rotateDelay;

    

    [Header("Set Wall And Ground Check")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] GameObject wallCheck;

    [Header("Ground Checks")]
    [SerializeField] GameObject gforwardCheck;
    [SerializeField] GameObject gbackCheck;
    [SerializeField] GameObject grightCheck;
    [SerializeField] GameObject gleftCheck;

    [Header("Wall Checks")]
    [SerializeField] GameObject wforwardCheck;
    [SerializeField] GameObject wbackCheck;
    [SerializeField] GameObject wrightCheck;
    [SerializeField] GameObject wleftCheck;

    [Header("Check If Move Available")]
    [SerializeField] bool wforward;
    [SerializeField] bool wback;
    [SerializeField] bool wright;
    [SerializeField] bool wleft;

    [SerializeField] bool gforward;
    [SerializeField] bool gback;
    [SerializeField] bool gright;
    [SerializeField] bool gleft;

    [Header("other")]
    [SerializeField] Vector3 anchor;
    Vector3 axis;
    private GameObject _gameManager;

    private void Start()
    {   
        _isRotating = false;

        _gameManager = GameObject.FindGameObjectWithTag("gameManager");


        groundCheck = GameObject.FindGameObjectWithTag("groundCheck");
        wallCheck = GameObject.FindGameObjectWithTag("wallCheck");

        //ground check box
        gforwardCheck = groundCheck.gameObject.transform.Find("forward").gameObject;
        gbackCheck = groundCheck.gameObject.transform.Find("back").gameObject;
        gleftCheck = groundCheck.gameObject.transform.Find("left").gameObject;
        grightCheck = groundCheck.gameObject.transform.Find("right").gameObject;

        //wall check box
        wforwardCheck = wallCheck.gameObject.transform.Find("forward").gameObject;
        wbackCheck = wallCheck.gameObject.transform.Find("back").gameObject;
        wleftCheck = wallCheck.gameObject.transform.Find("left").gameObject;
        wrightCheck = wallCheck.gameObject.transform.Find("right").gameObject;
        
    }

    private void Update()
    {
        gforward = gforwardCheck.GetComponent<moveAvailable>().moveAvailabe;
        gback= gbackCheck.GetComponent<moveAvailable>().moveAvailabe;
        gleft = gleftCheck.GetComponent<moveAvailable>().moveAvailabe;
        gright= grightCheck.GetComponent<moveAvailable>().moveAvailabe;

        wforward = !wforwardCheck.GetComponent<moveAvailable>().moveAvailabe;
        wback = !wbackCheck.GetComponent<moveAvailable>().moveAvailabe;
        wleft = !wleftCheck.GetComponent<moveAvailable>().moveAvailabe;
        wright = !wrightCheck.GetComponent<moveAvailable>().moveAvailabe;


        if (!_isMoving && GameManager.isPlaying)
        {
            if (Input.GetKey(KeyCode.A) && gleft && wleft) Assenmble(Vector3.left);
            else if (Input.GetKey(KeyCode.D) && gright && wright) Assenmble(Vector3.right);
            else if (Input.GetKey(KeyCode.W) && gforward && wforward) Assenmble(Vector3.forward);
            else if (Input.GetKey(KeyCode.S) && gback && wback) Assenmble(Vector3.back);

        }

        

        
        rotateTimer += Time.deltaTime;
        if (_isRotating)
        {
            _isMoving = true;

            if (rotateDelay <= rotateTimer && rolledAngle < 90)
            {
                transform.RotateAround(anchor, axis, rollSpeed);
                rolledAngle += rollSpeed;
                rotateTimer = 0;
            }

            if (rolledAngle == 90)
            {
                _isMoving = false;
                _isRotating = false;
                rolledAngle = 0;
            }
            
            
            
            
        }

    }


    void Assenmble(Vector3 dir)
    {
        anchor = transform.position + (Vector3.down + dir);
        axis = Vector3.Cross(Vector3.up,dir);
        _isRotating = true;
        _gameManager.GetComponent<starManager>().AddToMovesCount();
        
        

        //StartCoroutine(Roll(anchor, axis));
    }
    public void GoDirW()
    {
        if (_isMoving) return;
        else if (gforward && wforward) Assenmble(Vector3.forward);
    }
    public void GoDirA()
    {
        if (_isMoving) return;
        else if(gleft && wleft) Assenmble(Vector3.left);
    }
    public void GoDirS()
    {
        if (_isMoving) return;
        else if(gback && wback) Assenmble(Vector3.back);
    }
    public void GoDirD()
    {
        if (_isMoving) return;
        else if(gright&& wright) Assenmble(Vector3.right);
    }


    /*
    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }
    */
}
