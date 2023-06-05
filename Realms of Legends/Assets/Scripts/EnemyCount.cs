
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    private EnemySpawn enemySpawn;
    private RoomGenerator roomGenerator;

    //public GameObject portalPrefab;

    public static Button button;


    private void Start()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
        roomGenerator = FindObjectOfType<RoomGenerator>();

    }

    //private void CreatePortal()
    //{
    //    if(enemySpawn.enemyCount >= 0)
    //    {
    //        int randomRoom = Random.Range(1, roomGenerator.generatedRooms.Count);
    //        GameObject portalRoom = roomGenerator.generatedRooms[randomRoom];
    //        Transform portal = portalRoom.transform.Find("portal");

    //        GameObject spawnedPortal = Instantiate(portalPrefab, portal.position, portal.rotation);
    //    }
    //}

    public static void OnButtonClick()
    {
        Debug.Log("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void aaa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static Button CreateButton()
    {
        GameObject canvasObject = new GameObject("Canvas");

        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 1;

        CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        GameObject buttonObject = new GameObject("Button");
        buttonObject.transform.SetParent(canvasObject.transform);

        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = Color.white;

        RectTransform imageTransform = buttonImage.GetComponent<RectTransform>();
        imageTransform.sizeDelta = new Vector2(300, 100);

        Button button = buttonObject.AddComponent<Button>();

        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(buttonObject.transform);

        Text buttonTextComponent = textObject.AddComponent<Text>();
        buttonTextComponent.text = "Перейти на следующую локацию";
        buttonTextComponent.color = Color.black;
        buttonTextComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        buttonTextComponent.fontSize = 20;
        buttonTextComponent.alignment = TextAnchor.MiddleCenter;

        RectTransform textTransform = textObject.GetComponent<RectTransform>();
        textTransform.anchorMin = new Vector2(0.5f, 0.5f);
        textTransform.anchorMax = new Vector2(0.5f, 0.5f);
        textTransform.pivot = new Vector2(0.5f, 0.5f);
        textTransform.anchoredPosition = new Vector2(0, 0);
        textTransform.sizeDelta = new Vector2(buttonImage.rectTransform.rect.width, buttonImage.rectTransform.rect.height);

        RectTransform buttonTransform = buttonObject.GetComponent<RectTransform>();
        buttonTransform.sizeDelta = new Vector2(400, 100);
        buttonTransform.anchoredPosition = new Vector2(0, 0);

        return button;
    }
}
