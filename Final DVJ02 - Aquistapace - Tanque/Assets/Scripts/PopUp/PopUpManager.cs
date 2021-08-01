using UnityEngine;
using TMPro;

public class PopUpManager : MonoBehaviour
{
    public delegate void CreatePopUp(Transform space, int number, bool isPlayer);
    public static CreatePopUp CallPopUp;

    public new Transform camera;
    public GameObject popUp;
    [SerializeField] Vector3 newPosition;

    [SerializeField] Color normalTarget = Color.green;
    [SerializeField] Color playerTarget = Color.red;

    void OnEnable()
    {
        CallPopUp += Create;
    }

    void OnDisable()
    {
        CallPopUp -= Create;
    }

    void Create(Transform space, int number, bool isPlayer)
    {
        GameObject textPopUp = Instantiate(popUp, space.position, space.rotation);
        textPopUp.transform.LookAt(camera.transform.position, Vector3.up);
        textPopUp.transform.position += newPosition;

        textPopUp.transform.GetComponentInChildren<TextMeshPro>().text = number.ToString();

        if (isPlayer)
        {
            textPopUp.transform.GetComponentInChildren<TextMeshPro>().color = playerTarget;
        }
        else
        {
            textPopUp.transform.GetComponentInChildren<TextMeshPro>().color = normalTarget;
        }
    }
}
