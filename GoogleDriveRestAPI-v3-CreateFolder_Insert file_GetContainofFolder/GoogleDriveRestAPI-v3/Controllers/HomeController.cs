using ElearningSubject_v3.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject_v3.Controllers
{
    public class HomeController : Controller
    {
        ContentSubject content = new ContentSubject();

        [HttpGet]
        public ActionResult GetGoogleDriveFiles()
        {
            return View(GoogleDriveFilesRepository.GetDriveFiles());
        }

        [HttpGet]
        public ActionResult GetContainsInFolder(string folderId)
        {
            return View(GoogleDriveFilesRepository.GetContainsInFolder(folderId));
        }

        [HttpPost]
        public ActionResult CreateFolder(String FolderName)
        {
            GoogleDriveFilesRepository.CreateFolder(FolderName);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUpload(file);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult FileUploadInFolder(GoogleDriveFiles FolderId, HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUploadInFolder(FolderId.Id, file);
            return RedirectToAction("GetGoogleDriveFiles");
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            return View();
        }

        [HttpGet]
        public ActionResult GetSubjectDetailDataList(string id)
        {
            return View(content.PrepareData());
        }
        public ActionResult ShowDetailSubject(string id)
        {
            ContentSubject item = content.PrepareData().Find(x => x.Index + "" == id);
            return View(item);
        }
        private bool IsNotLogin()
        {
            if (string.IsNullOrEmpty(Session["UserLogin"] + ""))
                return true;
            return false;
        }
    }
}
public class ContentSubject
{
    public int Index { set; get; }
    public string Name { set; get; }
    public string Time { set; get; }
    public ContentSubject(int index, string name, string time)
    {
        this.Name = name;
        this.Index = index;
        this.Time = time;
    }
    public ContentSubject()
    {

    }
    public List<ContentSubject> PrepareData()
    {
        List<ContentSubject> contentDataList = new List<ContentSubject>();
        contentDataList.Add(new ContentSubject(1, "Giới thiệu về C#", "00:08:59"));
        contentDataList.Add(new ContentSubject(2, "Cài đặt và sử dụng Visual Studio", "00:26:40"));
        contentDataList.Add(new ContentSubject(3, "Kiểu dữ liệu,Biến và biểu thức", "00:36:13"));
        contentDataList.Add(new ContentSubject(4, "Các phép toán trong C#", "00:40:30"));
        contentDataList.Add(new ContentSubject(5, "Các cách ghi chú trong C#", "00:13:31"));
        contentDataList.Add(new ContentSubject(6, "Các cấu trúc điều kiện", "00:23:10"));
        contentDataList.Add(new ContentSubject(7, "Các cấu trúc lặp.", "00:31:33"));
        contentDataList.Add(new ContentSubject(8, "Hàm trong C#", "00:29:34"));
        contentDataList.Add(new ContentSubject(9, "Một số thư viện thường dùng", "00:27:37"));
        contentDataList.Add(new ContentSubject(10, "Project tổng hợp", "00:21:19"));
        contentDataList.Add(new ContentSubject(11, "Debug trong c#", "00:26:16"));
        contentDataList.Add(new ContentSubject(12, "Xử lý biệt lệ trong C#", "00:19:57"));
        contentDataList.Add(new ContentSubject(13, "Chuỗi và các thao tác trên chuỗi", "00:59:07"));
        contentDataList.Add(new ContentSubject(14, "Mảng", "00:46:32"));
        contentDataList.Add(new ContentSubject(15, "List", "00:15:20"));
        contentDataList.Add(new ContentSubject(16, "Dictionary", "00:15:18"));
        contentDataList.Add(new ContentSubject(17, "Project thực tế", "00:19:14"));
        contentDataList.Add(new ContentSubject(18, "Các khái niệm liên quan tới lớp và đối tượng", "00:10:50"));
        contentDataList.Add(new ContentSubject(19, "Xây dựng các lớp (Class) các thành phần của lớp", "01:14:31"));
        contentDataList.Add(new ContentSubject(20, "Xây dựng các lớp kế thừa trong C#", "00:59:41"));
        contentDataList.Add(new ContentSubject(21, "Project thực tế", "00:50:18"));
        contentDataList.Add(new ContentSubject(22, "Giới thiệu về Windows Form", "00:31:42"));
        contentDataList.Add(new ContentSubject(23, "Giới thiệu về thanh công cụ Toolbox & Properties", "00:19:55"));
        contentDataList.Add(new ContentSubject(24, "MessageBox", "00:14:09"));
        contentDataList.Add(new ContentSubject(25, "Panel & SplitContainer", "00:14:44"));
        contentDataList.Add(new ContentSubject(26, "Các control cơ bản nhất: Label,Textbox, Button", "00:20:39"));
        contentDataList.Add(new ContentSubject(27, "Checkbox, RadioButton", "00:21:36"));
        contentDataList.Add(new ContentSubject(28, "Picturebox", "00:24:55"));
        contentDataList.Add(new ContentSubject(29, "DateTimePicker & MonthCalendar", "00:15:23"));
        contentDataList.Add(new ContentSubject(30, "ListBox", "00:37:33"));
        contentDataList.Add(new ContentSubject(31, "ComboBox", "00:22:10"));
        contentDataList.Add(new ContentSubject(32, "CheckedListBox", "00:24:47"));
        contentDataList.Add(new ContentSubject(33, "Project thực tế", "00:58:52"));
        contentDataList.Add(new ContentSubject(34, "Bài tập rèn luyện 1 - Vẽ giao diện và xử lý sự kiện lúc Runtime", "00:26:55"));
        contentDataList.Add(new ContentSubject(35, "Bài tập rèn luyện 2 - Chương trình tính tiền bán sách", "00:33:24"));
        contentDataList.Add(new ContentSubject(36, "Bài tập rèn luyện 3 - Thiết kế giao diện xử lý chuỗi", "01:09:43"));
        contentDataList.Add(new ContentSubject(37, "Bài tập rèn luyện 4- Viết chương trình đặt vé cho Rạp chiếu phim", "00:55:04"));
        contentDataList.Add(new ContentSubject(38, "Bài tập rèn luyện 5- Thiết kế giao diện tương tác với mảng", "00:17:24"));
        contentDataList.Add(new ContentSubject(39, "Bài tập rèn luyện 6- Thiết kế màn hình Hóa đơn bán xe", "00:03:05"));
        contentDataList.Add(new ContentSubject(40, "Bài tập rèn luyện 7 - Viết Game Caro 2 người chơi với nhau", "00:04:25"));
        contentDataList.Add(new ContentSubject(41, "Bài tập rèn luyện 8 - Viết phần mềm Kiểm tra gõ phím", "00:03:09"));
        contentDataList.Add(new ContentSubject(42, "Bài tập rèn luyện 9 - Viết phần mềm tương tự MsPaint", "00:08:09"));
        contentDataList.Add(new ContentSubject(43, "Bài tập rèn luyện 10- Viết game Xếp hình", "00:04:35"));
        contentDataList.Add(new ContentSubject(44, "Tổng kết khóa học", "00:01:11"));
        return contentDataList;
    }

}