using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialMenu : MonoBehaviour
{
    public RadialButton buttonPrefab;
    public RadialButton selected;
    public DashAbility dash;
    public RangedAbility ranged;
    public MeleeAbility melee;
    public ShieldAbility shield;
    public Interactable Menu;
    public GameMaster gm;
    public TextMeshProUGUI text;

    void Start()
    {
        Menu = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactable>();
    }

    // Start is called before the first frame update
    public void SpawnButtons(Interactable obj)
    {
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<DashAbility>();
        ranged = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<RangedAbility>();
        melee = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeleeAbility>();
        shield = GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldAbility>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        for (int i = 0; i < obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            TextMeshProUGUI newText = Instantiate(text) as TextMeshProUGUI;
            newButton.transform.SetParent(transform, false);
            newText.transform.SetParent(transform, false);

            //Gets the position of each of the items of the radial menu
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);

            //Iterates through them x,yf away from the center
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 300f;
            newText.transform.localPosition = new Vector3(xPos, yPos - 0.5f, 0f) * 300f;

            //Gives each button its parameters
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].name;
            newButton.unlocked = gm.unlockedAbility[i];
            newButton.myMenu = this;
            newText.text = obj.options[i].name;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (selected)
            {
                Debug.Log(selected.title);
                if (selected.title == "DASH")
                {
                    dash.dashBool = true;
                }
                else
                {
                    dash.dashBool = false;
                }

                if (selected.title == "RANGED")
                {
                    ranged.rangedBool = true;
                }
                else
                {
                    ranged.rangedBool = false;
                }

                if (selected.title == "MELEE")
                {
                    melee.meleeBool = true;
                }
                else
                {
                    melee.meleeBool = false;
                }

                if (selected.title == "SHIELD")
                {
                    shield.shieldBool = true;
                }
                else
                {
                    shield.shieldBool = false;
                    shield.destroyShield();
                }
            }
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Menu.MenuActive = false;
            Destroy(gameObject);
        }
    }
}
