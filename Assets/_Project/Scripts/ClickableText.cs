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

    public void OnPointerClick(PointerEventData eventData)
    {
        // Проверяем, попал ли клик в зону ссылки
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(_textMeshPro, eventData.position, null);
        
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = _textMeshPro.textInfo.linkInfo[linkIndex];
            
            // Получаем ID из тега <link="ID">
            string linkId = linkInfo.GetLinkID();
            
            Debug.Log($"Нажата кнопка с ID: {linkId}");
            
            if (linkId == "my_button_0") {
                if (additionalText.gameObject.activeSelf) {
                    additionalText.gameObject.SetActive(false);
                } else {
                    additionalText.gameObject.SetActive(true);
                    additionalText.text = "קיימת בעיה בטבעת תקשורת.\n קו אדום בין מנתקים עלול להצביע על פגיעה בכבילה ביניהם.\n פורט אדום עלול להצביע על נפילת תקשורת על ארון כוח לגיבוי A או B.";
                }
            } else {
                additionalText.gameObject.SetActive(false);
            }

            if (linkId == "my_button_1") {
                if (infoPanelView.extraInfoPanel.activeSelf) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }
            } else if (linkId == "my_button_2")
            {
                if (infoPanelView.extraInfoPanel.activeSelf) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }
            } else if (linkId == "my_button_3") {
                if (infoPanelView.extraInfoPanel.activeSelf) {
                    infoPanelView.ShowExtraInfoPanel(false);
                }
                else {
                    infoPanelView.ChnageExtraInfoPanel(null, null);
                    infoPanelView.ShowExtraInfoPanel(true);
                }
            } else {
                infoPanelView.ShowExtraInfoPanel(false);
            }
        }
    }
}