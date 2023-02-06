using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    NavMeshAgent nav;
    Vector2 cursorPosition;
    Camera cam;

    [SerializeField] Destination destination;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }
    public void OnCursor(InputValue value)
    {
        cursorPosition = value.Get<Vector2>();
    }
    public void OnLeftClick(InputValue value)
    {
        bool input = value.isPressed;
        if (input)
        {
            Move();
        }
    }
    void Move()
    {
        Ray ray = cam.ScreenPointToRay(cursorPosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 position = hit.point;
            nav.SetDestination(position);
            destination.Appear(position);
        }
    }


}
