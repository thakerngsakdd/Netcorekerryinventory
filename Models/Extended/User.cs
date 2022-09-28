using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreKerryInventory.Models;

[ModelMetadataType(typeof(UserMetadata))]
public partial class User 
{
    [NotMapped]
    public string confirmedPassword { get; set; } = null!;
}

public class UserMetadata
{
    [Display(Name ="ชื่อ")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณากรอกชื่อ")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "นามสกุล")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกนามสกุล")]
    public string LastName { get; set; } = null!;


    [Display(Name = "อีเมล")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกอีเมล")]
    public string EmailID { get; set; } = null!;

    [Display(Name = "วันเกิด")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString  = "{0:dd/MM/yyyy}")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกวันเกิด")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "รหัสผ่าน")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกรหัสผ่าน")]
    [DataType(DataType.Password)]
    [MinLength(6,ErrorMessage ="รหัสผ่านต้องไม่น้อยกว่า 6 ตัวอักษร")]

    public string Password { get; set; } = null!;


    //confirmed Password
    [Display(Name = "ยืนยันรหัสผ่าน")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณายืนยันรหัสผ่าน")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "รหัสผ่านยืนยันไม่ตรงกัน")]
    public string confirmedPassword { get; set; } = null!;
}