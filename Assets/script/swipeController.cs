using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeController : MonoBehaviour
{
    [SerializeField] Vector2 firstTouchPos;
    Vector2 currentTouchPos;
    [SerializeField] float touchDistance;
    [SerializeField] bool isTouching;
    [SerializeField] bool isDragging;
    [SerializeField] float angle;
    [SerializeField] string direction;
    [SerializeField] float swipeDistance;
    movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        isTouching= false;  
        isDragging= false;
        _movement = GetComponent<movement>();
        swipeDistance = Screen.height / 10;
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0 && !isTouching)
        {
            isTouching= true;   
            isDragging= true;
            firstTouchPos = Input.touches[0].position;


        }

        else if (Input.touchCount == 0 && isTouching)
        {
            isTouching = false;
            isDragging= false;
            touchDistance= 0;   

        }

        if (isDragging)
        {
            currentTouchPos = Input.touches[0].position;
            touchDistance = Vector2.Distance(firstTouchPos, currentTouchPos);
        }

        if (touchDistance >= swipeDistance && isDragging)
        {
            touchDistance = 0;
            isDragging = false;
            Vector2 lookDir = firstTouchPos - currentTouchPos;
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            if (GameManager.isPlaying)
            {
                if (angle < 90f && angle >= 0f)
                {
                    _movement.GoDirS();
                }
                else if (angle > -90f && angle < 0f)
                {
                    _movement.GoDirA();
                }
                else if (angle <= -90f && angle >= -180f)
                {
                    _movement.GoDirW();
                }
                else if (angle >= 90f && angle <= 180f)
                {
                    _movement.GoDirD();
                }

            }


        }

        
        
        
    }

}
