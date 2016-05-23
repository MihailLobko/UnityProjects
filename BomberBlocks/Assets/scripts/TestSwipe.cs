using UnityEngine;
using System.Collections;

public class TestSwipe : MonoBehaviour {
    private Touch initialToush = new Touch();
    private float distance = 0;
    private bool hasSwiped = false;

    void FixedUpdate()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initialToush = t;
            }
            else if (t.phase == TouchPhase.Moved && !hasSwiped)
            {
                float deltaX = initialToush.position.x - t.position.x;
                float deltaY = initialToush.position.y - t.position.y;

                distance = Mathf.Sqrt((deltaX*deltaX) + (deltaY*deltaY));
                bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
                if (distance > 100f)
                {
                    if (swipedSideways && deltaX > 0)//swiped left
                    {
                        
                    }
                    else if(swipedSideways && deltaX <= 0)//swiped right
                    {
                        
                    }
                    else if(!swipedSideways && deltaY > 0)//swiped down
                    {
                        
                    }
                    else if (!swipedSideways && deltaY < 0)//swiped up
                    {

                    }
                    hasSwiped = true;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                initialToush = new Touch();
                hasSwiped = false;
            }
        }
      
    }
}
