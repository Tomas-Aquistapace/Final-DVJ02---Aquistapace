using UnityEngine;

public class CallCredits : MonoBehaviour
{
    [SerializeField] private Animator credits;
    [SerializeField] private GameObject closeButton;

    public void CallCredit()
    {
        credits.SetTrigger("Activate");

        //closeButton.SetActive(true);
    }

    public void CloseCredit()
    {
        credits.SetTrigger("Activate");

        //closeButton.SetActive(false);
    }

}
