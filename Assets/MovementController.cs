using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{

    public GameObject currentNode;
    public float speed = 4f;

    public string direction = " ";
    public string lastMovingDirection = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);
        bool reverseDirection = false;

        if (
           (direction == "left" && lastMovingDirection == "right") ||
            (direction == "right" && lastMovingDirection == "left") ||
            (direction == "up" && lastMovingDirection == "down") ||
            (direction == "down" && lastMovingDirection == "up")
            )
        { 
        reverseDirection = true;
    }

        //add the || reverse!!!!!!!!!!!!!!!!!!!
        //figure out if we're @ center of current node
        if ((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y))
            { 
            //get next node 
            GameObject newNode = currentNodeController.GetNodefromDirection(direction);
       
        if(newNode != null )
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodefromDirection(direction);
                if(newNode != null )
                {
                    currentNode = newNode;
                }
            }
        }
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;
    }

}
