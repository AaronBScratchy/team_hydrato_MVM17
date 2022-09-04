using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image[] Hearts;
    private PlayerHurtBehaviour player;
    public void Init(PlayerHurtBehaviour playerREF)
    {
        int health = playerREF.Health;
        int max = playerREF.MaxHealth;

        Transform bar = GetComponentInChildren<HorizontalLayoutGroup>().transform;

        Hearts = new Image[(max / 2) + (max % 2)];

        for (int i = 0; i < max; i += 2)
        {
            GameObject obj = new("Heart");
            obj.transform.SetParent(bar);
            obj.AddComponent<LayoutElement>();
            Hearts[i / 2] = obj.AddComponent<Image>();
            obj.GetComponent<RectTransform>().sizeDelta = new(30, 30);
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            int j = (health - (i * 2)) switch
            {
                > 1 => 2,
                1 => 1,
                _ => 0
            };

            Hearts[i].sprite = Resources.LoadAll<Sprite>("UI/Images/Hearts")[j];
        }

        playerREF.damageTaken += OnDamageTaken;
        player = playerREF;

    }

    private void OnDamageTaken()
    {
        int index = player.Health / 2;
        Hearts[index].sprite = Resources.LoadAll<Sprite>("UI/Images/Hearts")[player.Health % 2];
    }

    private void ResetHealthBar()
    {
        foreach(Image Heart in Hearts)
        {
            Heart.sprite = Resources.LoadAll<Sprite>("UI/Images/Hearts")[2];
        }
    }

}
