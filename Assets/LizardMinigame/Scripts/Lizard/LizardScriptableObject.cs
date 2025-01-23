using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LizardObject", menuName = "Scriptable Objects/LizardObject")]
public class LizardScriptableObject : ScriptableObject
{
    public string lizardName;
    public int lizardPrice;
    public Sprite lizardImage;
    public GameObject lizardObject;
    public Vector3 offsetForCenter;
}
