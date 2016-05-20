using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public enum CharacterType
{
    Dog,Cat,Frog,Robot
}
public abstract class Character : MonoBehaviour {

    // Use this for initialization
    public Image CharacterImage;
    public CharacterType Type;
    public GameObject MotherShip;
    public GameObject BigShip;
    public GameObject SmallShip;
    public GameObject LargeShip;
    public Image LoadingBay;
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();
  
}
public class Dog : Character
{
    public override void Start()
    {
        Type = CharacterType.Dog;
    }

    public override void Update()
    {
        
    }
}