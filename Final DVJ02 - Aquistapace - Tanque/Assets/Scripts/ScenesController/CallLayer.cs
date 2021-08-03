using UnityEngine;

public class CallLayer : MonoBehaviour
{
    //[SerializeField] private GameObject layer;

    Animator anim;
    bool state;

    private void Awake()
    {
        anim = this.transform.GetComponent<Animator>();

        state = false;
    }

    public void CallWithAnimation()
    {
        anim.SetBool("State", true);
    }

    public void CloseWithAnimation()
    {
        anim.SetBool("State", false);
    }

    public void CallWithoutAnimation()
    {
        if (!state)
        {
            state = true;

            this.gameObject.SetActive(state);
        }
        else
        {
            state = false;

            this.gameObject.SetActive(state);
        }
    }
}
