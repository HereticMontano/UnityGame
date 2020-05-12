using Assets.Scripts.Enum;
using UnityEngine;

public class PresentationCharacterControllers : MonoBehaviour
{
    public TipoCharacter Character;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().SetInteger("TypeOfCharacter", (int)Character);
    }
}


