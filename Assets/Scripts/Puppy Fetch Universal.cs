using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PuppyFetchUniversal : MonoBehaviour
{

    [Header("Fetching")]
    public LayerMask fetchableLayer;
    public Transform fetchPoint;   
    public float fetchDistance = 2f;
    private Rigidbody fetchedRigidbody;
    private Transform fetchedObject;
    private bool isFetching = false;


    [Header("Receiving")]
    public Transform owner;
    public bool isReceiving = false;
    public float receiveDistance = 3f;
    public Transform receivedObject;
    public ParticleSystem sadParticle;
    public UnityEvent objectReceived;


    [Header("Ball")]
    public Transform ballRig;
    public Transform ballNoRig;


    public void Start()
    {
        ballNoRig.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            
        {
            if (isFetching && fetchedObject != null)
            {

                    ReceiveClosestObject();
                    HideObjectAfterReceiving();
          
            }
            else
            {
                FetchClosestObject();
            }
            
        }
        
    }

    //Fetch closest object
    public void FetchClosestObject()
    {
        Collider[] fetchablesInRange = Physics.OverlapSphere(fetchPoint.position, fetchDistance, fetchableLayer);
        Transform closestFetchable = null;
        float closestDistance = Mathf.Infinity;
        
        foreach (var fetchable in fetchablesInRange)
        {
            float distance = Vector3.Distance(fetchPoint.position, fetchable.transform.position);

            //Fetch Closest One
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFetchable = fetchable.transform;
            }

        }
        //Change Position
        if (closestFetchable != null && fetchedObject == null)
        {
          
            fetchedObject = closestFetchable;
            
            // Find root parent
            Transform rootParent = closestFetchable.root;

            closestFetchable = rootParent;
            fetchedRigidbody = rootParent.GetComponent<Rigidbody>();

            closestFetchable.position = fetchPoint.position;
            closestFetchable.SetParent(fetchPoint);
            isFetching = true;

            //Ban Rigidbody
            if (fetchedRigidbody != null)
            {
                fetchedRigidbody.isKinematic = true;
            }
            
        }
    }

    //Drop fetched object
    public void DropFetchObject()
    {
        if (isFetching == true)
        {           
            isReceiving = false;
            fetchedObject.SetParent(null);

            if (fetchedRigidbody != null)
            {
                fetchedRigidbody.isKinematic = false;
            }

            fetchedRigidbody = null;
            fetchedObject = null;
        }

    }

    //Owner receives objects
    public void ReceiveClosestObject()
    {

        float distanceToOwner = Vector3.Distance(owner.position, fetchedObject.position);
        if (distanceToOwner <= receiveDistance )
        {
            isReceiving = true;
            receivedObject = fetchedObject;
            StopBeingSad();
            objectReceived.Invoke(); 
        }
        else
        {
            DropFetchObject();
        }
    }
    public void HideObjectAfterReceiving()
    {
        if (isReceiving == true&&receivedObject!= null )
        {
            isFetching = false;
            receivedObject = null;
            fetchedObject.SetParent(null);
            if (fetchedRigidbody != null)
            {
                fetchedRigidbody.isKinematic = false;
            }

            fetchedRigidbody = null;
            fetchedObject.gameObject.SetActive(false);
            fetchedObject = null;

        }
    }

    public void StopBeingSad()
    {
        if(sadParticle != null)
        {
            sadParticle.gameObject.SetActive(false);
        }
        
    }

}