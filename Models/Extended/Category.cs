using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreKerryInventory.Models;

[ModelMetadataType(typeof(CategoryMetadata))]

public partial class Category
{


}
public class CategoryMetadata
{

    [Display(Name = "CategoryID")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกรหัสหมวดหมู่")]
    public int CategoryID { get; set; }

    [Display(Name = "Category Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณากรอกชื่อหมวดหมู่")]
    public string CategoryName { get; set; } = null!;

    [Display(Name = "Category Status")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Status")]
    public int CategoryStatus { get; set; }

}