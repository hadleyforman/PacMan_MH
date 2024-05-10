using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject currentNode;
    public float speed = 4f;

    public string direction = " ";
    public string lastMovingDirection = "";

    public bool isGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager  = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);

        bool reverseDirection = false;
        if(
           (direction == "left" && lastMovingDirection == "right")
            || (direction == "right" && lastMovingDirection == "left")
            || (direction == "up" && lastMovingDirection == "down")
            || (direction == "down" && lastMovingDirection == "up")
            )
            reverseDirection = true;

        //figure out if we're @ center of current node
        if ((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection)
        {
            if (isGhost)
            {
                GetComponent<EnemyController>().ReachedCenterOfNode(currentNodeController);
            }
            //get next node 
            GameObject newNode = currentNodeController.GetNodefromDirection(direction);

            if (newNode != null && newNode.tag == "Node2")
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }
            // try to go in last moving because cannot go in desired direction
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodefromDirection(direction);
                if (newNode != null)
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
