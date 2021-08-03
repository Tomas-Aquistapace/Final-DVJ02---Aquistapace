using UnityEngine;

public class CallLayer : MonoBehaviour
{
    [SerializeField] private GameObject layer;

    Animator anim;
    bool state;

    private void Awake()
    {
        anim = layer.GetComponent<Animator>();

        state = false;
    }

    public void CallWithAnimation()
    {
        //anim.SetTrigger("Activate");

        anim.SetBool("State", true);
    }

    public void CloseWithAnimation()
    {
        //anim.SetTrigger("Activate");

        anim.SetBool("State", false);
    }

    public void CallWithoutAnimation()
    {
        if (!state)
        {
            state = true;

            layer.SetActive(state);
        }
        else
        {
            state = false;

            layer.SetActive(state);
        }
    }
}
