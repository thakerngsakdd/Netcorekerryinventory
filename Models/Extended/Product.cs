using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreKerryInventory.Models;

[ModelMetadataType(typeof(ProductMetadata))]

public partial class Product
{


}

public class ProductMetadata
{

    [Display(Name ="Category")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณากรอกหมวดหมู่")]
    public int? CategoryID { get; set; }

    [Display(Name ="Product Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณากรอกชื่อสินค้า")]
    public string? ProductName { get; set; }

    [Display(Name ="Unit Price")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString  = "{0:n}")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณากรอกราคา")]
    public decimal? UnitPrice { get; set; }

    [Display(Name ="Picture")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณาใส่รูปสินค้า")]
    public string? ProductPicture { get; set; }

    [Display(Name ="Unit InStock")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="กรุณาใส่จำนวนสินค้า")]
    public int? UnitInStock { get; set; }

    [Display(Name = "Created Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString  = "{0:dd/MM/yyyy}")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณาใส่วันที่ให้ถูกต้อง")]
    public DateTime? CreatedDate { get; set; }

    // [Display(Name = "Modified Date")]
    // [DataType(DataType.Date)]
    // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString  = "{0:dd/MM/yyyy}")]
    // [Required(AllowEmptyStrings = false, ErrorMessage = "กรุณาใส่วันที่ให้ถูกต้อง")]
    // public DateTime? ModifiedDate { get; set; }

}
