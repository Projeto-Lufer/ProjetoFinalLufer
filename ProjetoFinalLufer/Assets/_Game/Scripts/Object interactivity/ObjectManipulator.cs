using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    [SerializeField] private Transform holdingPosition;
    [SerializeField] private Transform grabPosition;

    private GameObject currentObject;
    private LiftableObject currLiftableObjectScript;
    private PushableObject currPushableObjectScript;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string voiceAylaShortActions;
    

    // Bloco de funcoes referentes ao lancamento de objetos
    public void LiftObject(GameObject liftedObject)
    {
        currentObject = liftedObject;
        currLiftableObjectScript = currentObject.GetComponent<LiftableObject>();

        currLiftableObjectScript.Lift(holdingPosition);
    }

    public void PutDownObject()
    {
        Vector3 placingPosition = transform.position + (transform.forward * 1.5f);
        currLiftableObjectScript.PutDown(placingPosition);
        currLiftableObjectScript = null;
    }

    public void ThrowObject()
    {
        Vector3 throwingDirection = transform.forward;
        currLiftableObjectScript.Throw(throwingDirection);
    }

    // Bloco de funcoes referente a acao de empurrar objetos
    public void GrabObject(GameObject heldObject)
    {
        FMODUnity.RuntimeManager.PlayOneShot(voiceAylaShortActions, transform.position);
        currentObject = heldObject;
        currPushableObjectScript = currentObject.GetComponent<PushableObject>();

        currPushableObjectScript.Grab(grabPosition);
    }

    public void ReleaseObject()
    {
        currPushableObjectScript.Release();
        currPushableObjectScript = null;
    }
}
