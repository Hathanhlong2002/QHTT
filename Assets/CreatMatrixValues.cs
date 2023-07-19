using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatMatrixValues : MonoBehaviour
{
    public InputField CountVar;//ô nhập số biến
    public InputField countCol;//ô nhập số cột
    public InputField sizeShape;//ô nhập kích thước
    public InputField inputFieldPrefab;//ô gốc dùng tạo bản sao
    protected int numberRows;//giá trị số dòng
    protected int numberColumns;//giá trị số cột
    protected int size;// Giá trị kích thước cột 
    bool success = true;// kiểm tra ma trận có được tạo thành công hay không?
    protected Text errorMessageText;
    public InputField[][] numberFields; // Một mảng 2 chiều chứa các giá trị số
    public InputField[][] varFields;
    private void Start()
    {
        errorMessageText = GameObject.Find("errorMessageText").GetComponent<Text>();//Kết nối vật thể thông báo lỗi 
    }
    void Update()
    {
        int.TryParse(CountVar.text, out int result1); //Chuyển đổi sang số có thể tính toán được, dạng (int)
        numberRows = result1;
        int.TryParse(countCol.text, out int result2); //tương tự
        numberColumns = result2;
        int.TryParse(sizeShape.text, out int result3); 
        size = result3;
        if(size==0)//trường hợp chuyển đổi thất bại thì ta để false
        {
            success=false;
        }
        else 
        {
            success=true;
        }
    }
    //hàm sử dụng
    public void CreateMatrix()
    {
        if (!success) {// kiểm tra điều kiện
            // nếu không tạo được ma trận, hiển thị thông báo lỗi
            errorMessageText.text = "Lỗi: Không thể tạo ma trận";//cho văn bản là lỗi
            errorMessageText.gameObject.SetActive(true);// Hiện thị văn bản lỗi
            Matrix(2,2,0);// Tạo ma trận 2,2,0
        }
        else
        {
            Matrix(numberColumns,numberRows,size);// Ngược lại tạo ma trận với thông số ban đầu
            errorMessageText.text = " ";
            errorMessageText.gameObject.SetActive(false);//tắt thông báo lỗi
        }
    }
    void Matrix(int numCol,int numrows,int size)// Tham số: số cột, số dòng, kích thước
    {
        GameObject[] oldMatrix = GameObject.FindGameObjectsWithTag("Respawn");//
        //Kết nối oldmatrix là các ô cũ đã được khởi tạo trước đó
        foreach (GameObject old in oldMatrix) 
        {
            Destroy(old);// Xóa các object cũ
        }   
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();//kết nối canvas cũ để sử dụng
        for (int i = 0; i < numCol; i++)// cho i từ 0 đến số cột
        {
            for (int j = 0; j < 3* numrows+1; j++)//cho j từ 0 đến (3 lần số dòng +1)
            {
                InputField newInputField = Instantiate(inputFieldPrefab, canvas.transform);// Khởi tạo ô theo ô gốc và gán vào trong canvas
                GameObject parentObject = GameObject.Find("Matrix");//Tạo một object cha chứa các object con được tạo ra 
                newInputField.transform.SetParent(parentObject.transform);// Thiết lập mối quan hệ cha con , object cha chứa object con

                RectTransform rectTransform = newInputField.GetComponent<RectTransform>();// kết nối rectTransform với các object mới tạo
                rectTransform.localPosition = newInputField.transform.parent.position + new Vector3(j *size, -i * size, 0);// Cài đặt vị trí khởi tạo phù hợp
                rectTransform.sizeDelta = new Vector2(size, size);//Thiết lập kích thước cho từng ô
                // đã tạo thành công một trường nhập
            }
            // khởi tạo dòng chứa các biến x1,x2,.... và tương tự như trên
            InputField InputField = Instantiate(inputFieldPrefab, canvas.transform);
            RectTransform rectTrans = InputField.GetComponent<RectTransform>();
            rectTrans.localPosition = new Vector3(-500+size*i, 200+size* numCol, 0);
            rectTrans.sizeDelta = new Vector2(size, size);
        }
        
    }
    

}
