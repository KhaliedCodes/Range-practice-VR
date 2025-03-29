using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class Interactor : MonoBehaviour
{

    public XRBaseInteractor rayInteractor;
    public XRBaseInteractor directInteractor;
    void Start()
    {
        rayInteractor.selectEntered.AddListener(OnSelectEntered);
        rayInteractor.selectExited.AddListener(OnSelectExited);
        directInteractor.selectEntered.AddListener(OnSelectEntered);
        directInteractor.selectExited.AddListener(OnSelectExited);
    }
    void OnSelectEntered(SelectEnterEventArgs args)
    {
        gameObject.SetActive(false);
        rayInteractor.GetComponent<XRInteractorLineVisual>().enabled = false;
    }
    void OnSelectExited(SelectExitEventArgs args)
    {
        gameObject.SetActive(true);
        rayInteractor.GetComponent<XRInteractorLineVisual>().enabled = true;
    }


}
