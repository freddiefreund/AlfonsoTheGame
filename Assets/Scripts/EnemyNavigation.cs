using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigation : MonoBehaviour
{
    Rigidbody2D enemyrb;

    [SerializeField]
    float CurrentDirection;

    Vector2 targetDir;
    
    [SerializeField]
    bool waypointLeft;

    [SerializeField]
    int currentWaypoint;

    Collider2D WaypointCollider;

    [SerializeField]
    List<Transform> Waypoints = new List<Transform>();

    float minimumDistanceX = 5;
    float minimumDistanceY = 5;

    [SerializeField]
    Transform CurrentPos;

    [SerializeField]
    Transform NextPos;

    //[SerializeField]
    float accelerationPower = 3f;

    [SerializeField]
    float steeringPower = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        enemyrb = this.GetComponent<Rigidbody2D>();
        CurrentPos = this.GetComponent<Transform>();
        currentWaypoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCurrentPos();
        MovingShip();

        
    }

    //Check's the current position of the ship.
    //If the ship has no waypoint assigned to go to then give it the position of the next waypoint to go.
    //If it is already on the next waypoint then set it to the next one.
    void CheckCurrentPos()
    {

        if (Waypoints[0] == null || Waypoints[Waypoints.Count - 1] == null)
        {
            return;
        }

        if (NextPos == null)
        {
            //NextPos == Waypoints[1];
            NextPos = Waypoints[1];
        }

        //calculating distance between ship and waypoint to decide if the shif should switch to the next waypoint

        if (Waypoints[currentWaypoint] != null /*&& Waypoints[currentWaypoint+1] != null*/)
        {
            /*
            if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                   Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
            {
                waypointLeft = false;
                currentWaypoint++;
                NextPos = Waypoints[currentWaypoint];
                WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                print("case1.1)");
            }
            */

            if (currentWaypoint == Waypoints.Count - 1)
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    Destroy(this.gameObject);
                }
            }


            //if both x positions are above or below 0 and y positions are above or below 0
            if ((CurrentPos.position.x > 0 && NextPos.position.x >0 
                && CurrentPos.position.y >0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case1.1)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x < 0 
                    && CurrentPos.position.y < 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case1.2)");
                }
            }

            else if ((CurrentPos.position.x > 0 && NextPos.position.x > 0 
                    && CurrentPos.position.y < 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case1.3)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x < 0 
                    && CurrentPos.position.y > 0 && NextPos.position.y > 0)                    )
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case1.4)");
                }
            }

            //if one of the x positions is above 0 while the other is below 0 while both y values are above or below 0

            else if ((CurrentPos.position.x > 0 && NextPos.position.x < 0) 
                    && (CurrentPos.position.y > 0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case2.1)");
                }
            }

            else if ((CurrentPos.position.x > 0 && NextPos.position.x < 0) 
                    && (CurrentPos.position.y < 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case2.2)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x > 0) 
                    && (CurrentPos.position.y > 0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case2.3)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x > 0) 
                    && (CurrentPos.position.y < 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();
                    print("case2.4)");
                }
            }

            //if one of the y positions is above 0 while the other is below 0 while both x values are above or below 0

            else if ((CurrentPos.position.x > 0 && NextPos.position.x > 0)  
                    && (CurrentPos.position.y > 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case3)");
                }
            }

            else if ((CurrentPos.position.x > 0 && NextPos.position.x > 0) 
                    && (CurrentPos.position.y < 0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case3)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x < 0)
                    && (CurrentPos.position.y > 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case3)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x < 0)
                    && (CurrentPos.position.y < 0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case3)");
                }
            }

            //if one of the x positions is above 0 while the other is below 0 and
            //one of the y positions is above 0 while the other is below 0

            else if ((CurrentPos.position.x > 0 && NextPos.position.x < 0) 
                    && (CurrentPos.position.y > 0 && NextPos.position.y < 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case4.1)");
                }
            }

            else if ((CurrentPos.position.x > 0 && NextPos.position.x < 0) 
                    && (CurrentPos.position.y < 0 && NextPos.position.y > 0) )
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case4.2)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x > 0)
                    && (CurrentPos.position.y > 0 && NextPos.position.y < 0) )
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case4.3)");
                }
            }

            else if ((CurrentPos.position.x < 0 && NextPos.position.x > 0)
                    && (CurrentPos.position.y < 0 && NextPos.position.y > 0))
            {
                if (Mathf.Abs(CurrentPos.position.x + NextPos.position.x) <= minimumDistanceX &&
                    Mathf.Abs(CurrentPos.position.y + NextPos.position.y) <= minimumDistanceY)
                {
                    waypointLeft = false;
                    currentWaypoint++;
                    NextPos = Waypoints[currentWaypoint];
                    WaypointCollider = Waypoints[currentWaypoint].gameObject.GetComponent<BoxCollider2D>();

                    print("case4.4)");
                }
            }
            
        }  
        
        else
        {
            
            return;
        }
    }

    //Find out the current direction of the ship in comparison with the next waypoint.
    //If it is not looking towards it then turn it until it looks straight ahead at it.
    //Then, push's the ship towards the next waypoint's position.
    void MovingShip()
    {
        targetDir =  NextPos.position - CurrentPos.position;
        CurrentDirection = Vector2.Angle(targetDir, transform.up);

        if (CurrentDirection <= 10)
        {
            enemyrb.AddRelativeForce(Vector2.up * accelerationPower);
        }


        else if (CurrentDirection > 10 && waypointLeft == true)
        {
            enemyrb.rotation += (steeringPower * CurrentDirection) / 20;
        }

        else if (CurrentDirection > 10 && waypointLeft == false)
        {
            enemyrb.rotation -= (steeringPower * CurrentDirection) / 20;
        }

    }


    public void SetWaypointList ( List<Transform> WaypointList)
    {
        Waypoints = WaypointList;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == WaypointCollider)
        {
            waypointLeft = true;
        }
    }
}
