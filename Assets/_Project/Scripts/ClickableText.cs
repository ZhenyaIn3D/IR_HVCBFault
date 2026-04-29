using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI _textMeshPro;
    
    [SerializeField] private TextMeshProUGUI additionalText;
    [SerializeField] private InfoPanelView infoPanelView;
    
    [SerializeField] private DataBaseSO _dataBase;

    void Awake() => _textMeshPro = GetComponent<TextMeshProUGUI>();

    
    private int _lastButtonIndex = -1;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Проверяем, попал ли клик в зону ссылки
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(_textMeshPro, eventData.position, null);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = _textMeshPro.textInfo.linkInfo[linkIndex];

            Vector3 targetPos = GetLinkCenterPosition(linkIndex);

            // Получаем ID из тега <link="ID">
            string linkId = linkInfo.GetLinkID();

            Debug.Log($"Нажата кнопка с ID: {linkId}");

            // show lahatc dan info
            if (linkId == "my_button_0")
            {
                if (additionalText.gameObject.activeSelf)
                {
                    additionalText.gameObject.SetActive(false);
                }
                else
                {
                    additionalText.gameObject.SetActive(true);
                    additionalText.text =
                        "קיימת בעיה בטבעת תקשורת. קו אדום בין מנתקים עלול להצביע על פגיעה בכבילה ביניהם.\n פורט אדום עלול להצביע על נפילת תקשורת על ארון כוח לגיבוי A או B.";
                }
            }
            else
            {
                additionalText.gameObject.SetActive(false);
            }


            // plus buttons
            if (linkId == "my_button_step_1")
            {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 0) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);
                    
                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }

                _lastButtonIndex = 0;
            } else if (linkId == "my_button_1") {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 1) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);

                    
                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }

                _lastButtonIndex = 1;
            } else if (linkId == "my_button_2")
            {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 2) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);

                    
                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }

                _lastButtonIndex = 2;
            } else if (linkId == "my_button_3") {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 3) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);

                    
                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }

                _lastButtonIndex = 3;
            } else if (linkId == "my_button_step_5") {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 4) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);

                    
                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }
                
                _lastButtonIndex = 4;
            } else if (linkId == "my_button_step_13") {
                if (infoPanelView.extraInfoPanel.activeSelf && _lastButtonIndex == 5) {
                    infoPanelView.ShowExtraInfoPanel(false);
                } else {
                    Vector3 panelPos = infoPanelView.extraInfoPanel.transform.position;
                    infoPanelView.extraInfoPanel.transform.position = new Vector3(panelPos.x, targetPos.y, panelPos.z);


                    // infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }

                _lastButtonIndex = 5;
            } else {
                infoPanelView.ShowExtraInfoPanel(false);
            }
        }
    }
    
    private Vector3 GetLinkCenterPosition(int linkIndex)
    {
        TMP_LinkInfo linkInfo = _textMeshPro.textInfo.linkInfo[linkIndex];
    
        // Берем первый и последний символ ссылки, чтобы найти центр области
        int firstCharIndex = linkInfo.linkTextfirstCharacterIndex;
        int lastCharIndex = firstCharIndex + linkInfo.linkTextLength - 1;

        // Получаем позицию символов
        var firstCharInfo = _textMeshPro.textInfo.characterInfo[firstCharIndex];
        var lastCharInfo = _textMeshPro.textInfo.characterInfo[lastCharIndex];

        // Вычисляем среднюю точку между низом первого и верхом последнего символа
        Vector3 bottomLeft = _textMeshPro.transform.TransformPoint(firstCharInfo.bottomLeft);
        Vector3 topRight = _textMeshPro.transform.TransformPoint(lastCharInfo.topRight);

        return (bottomLeft + topRight) / 2f;
    }
}