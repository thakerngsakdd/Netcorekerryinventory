using Microsoft.AspNetCore.Mvc;
using NetcoreKerryInventory.Models;
using Microsoft.AspNetCore.Http;
namespace ASPNetCoreInventory.Controllers;

public class FrontendController : Controller
{
    //ทดสอบเขียนฟังก์ชั่นการเชื่อมต่อ database
    public string testconnectdb()
    {
        //สร้าง object context
        InventoryDBContext dbcontext = new InventoryDBContext();
        if (dbcontext.Database.CanConnect())
        {
            return "connect database success";

        }
        else
        {
            return "connect database fail !!";
        }
    }
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult About()
    {
        return View();
    }

    public ActionResult Webdev()
    {
        return View();
    }

    public ActionResult Mobiledev()
    {
        return View();
    }

    public ActionResult Graphic()
    {
        return View();
    }

    // เรียกแสดงแบบฟอร์มลงทะเบียน
    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    //Submit ฟอร์มลงทะเบียน
    [HttpPost]
    public ActionResult Register(User user)
    {
        string message = null!;

        //ตรวจว่า Validation ผ่านแล้ว
        if (ModelState.IsValid)
        {
            //ผ่านแล้วทำการบันทึกข้อมูลลงตาราง user

            using(InventoryDBContext db = new InventoryDBContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear(); // Reset และ Clear ค่าในฟอร์ม
                message = "<div class = \"alert alert-success text-center\">ลงทะเบียนเรียบร้อย</div>";

                //ส่งไปหน้า Login
                return RedirectToAction("Login","Frontend");
            }

        }
        else
        {
            message = "<div class = \"alert alert-danger text-center\">ป้อนข้อมูลให้ครบก่อน</div>";
        }
        ViewBag.Message = message;

        return View();
    }

    // เรียกแสดงแบบฟอร์มลงเข้าสุ่ระบบ
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    // Submit ฟอร์มลงเข้าสุ่ระบบ
    [HttpPost]
    public ActionResult Login(User user)
    {
        string message = null!;

        //ตรวจว่า Validation ผ่านแล้ว
        if (user.EmailID != null && user.Password != null)
        {

            using (InventoryDBContext db = new InventoryDBContext())
            {
                var query = db.Users.Where(u => u.EmailID == user.EmailID).FirstOrDefault();
                if (query != null)
                {
                    if(string.Compare(user.Password,query.Password) == 0)
                    {
                        //เก็บข้อมูลลง session

                        HttpContext.Session.SetString("Email", query.EmailID);
                        HttpContext.Session.SetString("FirstName", query.FirstName);
                        HttpContext.Session.SetString("LastName", query.LastName);

                        // Redirect ไปยัง Backend
                        return RedirectToAction("Dashboard", "Backend");
                    }
                    else
                    {
                        message = "<div class = \"alert alert-danger text-center\">รหัสผ่านไม่ถูกต้อง</div>";
                    }
                }
                else
                {
                    message = "<div class = \"alert alert-danger text-center\">ไม่พบอีเมลนี้</div>";
                }
            }

        }
        else
        {
            message = "<div class = \"alert alert-danger text-center\">ป้อนข้อมูลให้ครบก่อน</div>";
        }
        ViewBag.Message = message;
        return View();
    }

}

