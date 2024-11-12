using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public float moveAmount = 5f;
    public float moveAmount2 = 10f;

    public GameObject objectToMove;

    public Button rightArrow;
    public Button leftArrow;

    public void MoveCamRight()
    {
        objectToMove.transform.position += new Vector3(moveAmount, 0, 0);

        rightArrow.gameObject.SetActive(false);
        leftArrow.gameObject.SetActive(true);
    }

    public void MoveCamLeft()
    {
        objectToMove.transform.position += new Vector3(moveAmount2, 0, 0);

        rightArrow.gameObject.SetActive(true);
        leftArrow.gameObject.SetActive(false);
    }
}