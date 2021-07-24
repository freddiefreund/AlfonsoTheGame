using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigation : MonoBehaviour
{
    Rigidbody2D enemyrb;

    [SerializeField]
    float CurrentDirection;

    Vector2 targetDir;

    float currentSpeed;
    float topSpeed = 1;
    int currentWaypoint;

    public Transform waypointSample;

    List<Transform> Waypoints = new List<Transform>();

    float minimumDistanceX = 2;
    float minimumDistanceY = 2;

    [SerializeField]
    Transform CurrentPos;

    [SerializeField]
    Transform NextPos;

    [SerializeField]
    float accelerationPower = 1f;
    [SerializeField]
    float steeringPower = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        enemyrb = this.GetComponent<Rigidbody2D>();
        CurrentPos = this.GetComponent<Transform>();
        currentWaypoint = 0;
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

        if (Waypoints[0] == null)
        {
            return;
        }

        if (NextPos == null)
        {
            //NextPos == Waypoints[1];
            NextPos = Waypoints[0];
        }

        if (Mathf.Abs(CurrentPos.position.x - NextPos.position.x) <= minimumDistanceX && 
            Mathf.Abs(CurrentPos.position.y - NextPos.position.y) <= minimumDistanceY )
        {
            NextPos = Waypoints[currentWaypoint +1];
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

        else if(CurrentDirection != 0)
        {
            enemyrb.rotation += (steeringPower *  CurrentDirection)/100 ;
        }

    }


    public void SetWaypointList ( List<Transform> WaypointList)
    {
        Waypoints = WaypointList;
    }
}
