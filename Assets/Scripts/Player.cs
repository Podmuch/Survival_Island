using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform CocountPosition;
    public CharacterController PlayerChController;
    public Camera PlayerCamera;

    public float Speed = 5;
    public int CollectedCells { get; private set; }
    public bool HaveCocount { get { return currentCocount != null; } }
    [SerializeField]
    private Vector2 RotationSensivity;
    private Vector3 prevMousePosRel;
    private Cocount currentCocount;

    private void Start ()
    {
        prevMousePosRel = new Vector3(0.5f, 0.5f);
        CollectedCells = 0;
    }


    private void Update ()
    {
        Move();
        RotatePlayer();
        if (HaveCocount)
        {
            ThrowCocount();
        }
    }

    private void RotatePlayer()
    {
        Vector3 mousePosRel = PlayerCamera.ScreenToViewportPoint(Input.mousePosition);
        if(prevMousePosRel != mousePosRel)
        {
            PlayerTransform.Rotate(Vector3.up, (mousePosRel.x - prevMousePosRel.x) * RotationSensivity.x);
            PlayerCamera.transform.Rotate(Vector3.right, -(mousePosRel.y - prevMousePosRel.y) * RotationSensivity.y);
            prevMousePosRel = mousePosRel;
        }
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(input != Vector2.zero)
        {
            PlayerTransform.Rotate(Vector3.up, input.x);
            PlayerChController.SimpleMove(PlayerTransform.forward * input.y* Speed);
        }
    }

    private void ThrowCocount()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !currentCocount.HasThrown)
        {
            currentCocount.Throw(PlayerCamera.ScreenPointToRay(Input.mousePosition));
        }
    }

    public void AddCocount(Cocount cocount)
    {
        currentCocount = cocount;
        cocount.transform.SetParent(CocountPosition);
        cocount.transform.localPosition = Vector3.zero;
    }

    public void RemoveCocount()
    {
        if(currentCocount != null)
        {
            Destroy(currentCocount.gameObject);
        }
        currentCocount = null;
    }

    public void CollectCell()
    {
        CollectedCells++;
    }
}
