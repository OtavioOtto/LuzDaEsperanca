using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class PlayerChange : MonoBehaviour
{
    private int currentChildIndex = 0;
    private Transform[] children;
    private List<Transform> cameraChildren;
    private Vector3 sharedPosition;
    private Quaternion sharedRotation;
    private Dash dash;
    private GroundCheck groundCheck;
    private ClimbWall climbWall;
    private float vermelho0;
    [SerializeField] private GameObject gabriel;
    [SerializeField] private GameObject jimmy;
    private bool canChange = true;

    void Start()
    {
        InitializeChildren();
        SetInitialTransform();
        UpdateActiveChild();
    }

    void Update()
    {
        dash = GetComponentInChildren<Dash>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        climbWall = GetComponentInChildren<ClimbWall>();
        vermelho0 = Input.GetAxis("VERMELHO0");
        if (gabriel.activeSelf)
        {
            if (vermelho0 > 0.0f && !dash.isDashing && groundCheck.onGround && canChange)
            {

                SaveCurrentTransform();
                CycleToNextChild();
                UpdateActiveChild();
                canChange = false;
                StartCoroutine(ChangeCharactersCooldown());

            }
        }
        else if (jimmy.activeSelf) {

            if (vermelho0 > 0.0f && climbWall.canDetectWall && groundCheck.onGround && canChange)
            {

                SaveCurrentTransform();
                CycleToNextChild();
                UpdateActiveChild();
                canChange = false;
                StartCoroutine(ChangeCharactersCooldown());

            }

        }
        else {
            if (vermelho0 > 0.0f && groundCheck.onGround && canChange)
            {
                SaveCurrentTransform();
                CycleToNextChild();
                UpdateActiveChild();
                canChange = false;
                StartCoroutine(ChangeCharactersCooldown());

            }
        }
        UpdateCameraChildren();
    }

    private IEnumerator ChangeCharactersCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        canChange = true;
    }

    private void InitializeChildren()
    {
        int childCount = transform.childCount;
        List<Transform> validChildren = new List<Transform>();
        cameraChildren = new List<Transform>();

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.layer == LayerMask.NameToLayer("Camera"))
            {
                cameraChildren.Add(child);
            }
            else
            {
                validChildren.Add(child);
            }
        }

        children = validChildren.ToArray();
    }

    private void SetInitialTransform()
    {
        if (children.Length > 0)
        {
            sharedPosition = children[0].position;
            sharedRotation = children[0].rotation;
        }
    }

    private void SaveCurrentTransform()
    {
        if (children.Length > 0)
        {
            sharedPosition = children[currentChildIndex].position;
            sharedRotation = children[currentChildIndex].rotation;
        }
    }

    private void CycleToNextChild()
    { 
        if (children.Length > 0)
        {

            if (dash != null)
            {
                dash.canDash = false;
            }
            currentChildIndex = (currentChildIndex + 1) % children.Length;
            Dash nextDash = children[currentChildIndex].GetComponent<Dash>();
            if (nextDash != null)
            {
                nextDash.canDash = true;
            }
        }
    }

    private void UpdateActiveChild()
    {
        for (int i = 0; i < children.Length; i++)
        {
            bool isActive = i == currentChildIndex;
            children[i].gameObject.SetActive(isActive);

            if (isActive)
            {
                children[i].position = sharedPosition;
                children[i].rotation = sharedRotation;
            }
        }
    }

    private void UpdateCameraChildren()
    {
        if (children.Length > 0)
        {
            Transform activeChild = children[currentChildIndex];
            foreach (Transform cameraChild in cameraChildren)
            {
                cameraChild.position = activeChild.position;
                cameraChild.rotation = activeChild.rotation;
            }
        }
    }
}


