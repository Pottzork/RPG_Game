using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    public Image CooldownWaitImage_1;
    public Image CooldownWaitImage_2;
    public Image CooldownWaitImage_3;
    public Image CooldownWaitImage_4;
    public Image CooldownWaitImage_5;
    public Image CooldownWaitImage_6;
    public Image CooldownWaitImage_7;

    private Image lmbIcon;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0, 0 };

    private Animator anim;
    private bool canAttack = true;

    private PlayerMove playerMove;
    PlayerStats playerStats;


    void Awake()
    {
        playerStats = GameObject.Find("Black Knight").GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        lmbIcon = GameObject.Find("PowerLMB icon").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }


        CheckToFade();
        CheckInput();
    }


    void CheckInput()
    {
        if (anim.GetInteger("Atk") == 0)
        {
            playerMove.FinishedMovemet = true;

            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovemet = true;
            }
        }

        var Energy = GameObject.Find("Black Knight").GetComponent<EnergyScript>().currentEnergy;
        //var Cost = GameObject.Find("Black Knight").GetComponent<SkillDamage>().energyCost;
        //if num 1-6 is pressed, player should not move and instead attack from it's current position
        //if the movement is finished and the cooldown is clear then attack
        if (Input.GetKeyDown(KeyCode.Alpha1) && Energy > 40f && playerStats.currentLevel >= 2)
        {

            if (playerMove.FinishedMovemet && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                anim.SetInteger("Atk", 1);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Energy > 40f && playerStats.currentLevel >= 4)
        {

            if (playerMove.FinishedMovemet && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                anim.SetInteger("Atk", 2);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Energy > 70f && playerStats.currentLevel >= 6)
        {
            Vector3 targetPos = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            }
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(targetPos - transform.position), 150f * Time.deltaTime);

            if (playerMove.FinishedMovemet && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                anim.SetInteger("Atk", 3);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && Energy > 10f && playerStats.currentLevel >= 8)
        {

            if (playerMove.FinishedMovemet && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                anim.SetInteger("Atk", 4);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && Energy > 50f && playerStats.currentLevel >= 3)
        {

            if (playerMove.FinishedMovemet && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                anim.SetInteger("Atk", 5);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        //Mousebutton instead of number 6
        else if (Input.GetMouseButtonDown(1) && Energy > 90f && playerStats.currentLevel >= 10)
        {

            if (playerMove.FinishedMovemet && fadeImages[5] != 1 && canAttack)
            {
                fadeImages[5] = 1;
                anim.SetInteger("Atk", 6);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        //Holds shift+right mousebutton to stand still and attack towards the point of the mouse click
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            Vector3 targetPos = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                
            }
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(targetPos - transform.position), 150f * Time.deltaTime);

            // && fadeImages[6] != 1
            if (playerMove.FinishedMovemet && fadeImages[6] != 1 && canAttack)
            {

                lmbIcon.color = new Color32(255, 255, 255, 140);
                fadeImages[6] = 1;
                anim.SetInteger("Atk", 7);

                playerMove.TargetPosition = transform.position;
                RemoveCursorPoint();
            }
        }
        else
        {
            anim.SetInteger("Atk", 0);
        }
    }
    void CheckToFade()
    {
        if (fadeImages[0] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_1, 1.0f))
            {
                fadeImages[0] = 0;
            }
        }
        if (fadeImages[1] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_2, 0.7f))
            {
                fadeImages[1] = 0;
            }
        }
        if (fadeImages[2] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_3, 0.1f))
            {
                fadeImages[2] = 0;
            }
        }
        if (fadeImages[3] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_4, 0.2f))
            {
                fadeImages[3] = 0;
            }
        }
        if (fadeImages[4] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_5, 0.3f))
            {
                fadeImages[4] = 0;
            }
        }
        if (fadeImages[5] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_6, 0.08f))
            {
                fadeImages[5] = 0;
            }
        }
        if (fadeImages[6] == 1)
        {
            if (FadeAndWait(CooldownWaitImage_7, 1f))
            {
                fadeImages[6] = 0;
                lmbIcon.color = new Color32(255, 255, 255, 255);
            }
        }
    }
    //This handles the Cooldowns e.g making the spell darker and not active/usable
    bool FadeAndWait(Image fadeImg, float fadeTime)
    {
        bool faded = false;
        if (fadeImg == null)
        {
            return faded;
        }
        //Checks if the image is not active in the Hierarchy
        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1f;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0.0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }

    void RemoveCursorPoint()
    {
        GameObject cursorObj = GameObject.FindGameObjectWithTag("Cursor");
        if (cursorObj)
        {
            Destroy(cursorObj);
        }
        
    }
}
