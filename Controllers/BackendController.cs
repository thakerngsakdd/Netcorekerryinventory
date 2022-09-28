using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetcoreKerryInventory.Models;


using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace NetcoreKerryInventory.Controllers;

[SessionCheck]
public class BackendController : Controller
{
    private readonly InventoryDBContext _context;

    public BackendController(InventoryDBContext context)
    {
        _context = context;
    }

    //ตัวอย่างการสร้างตัวอย่าง pdf ด้วย QuestPDF
   public RedirectResult ReportPDF(){

        var reportname = "Report_"+DateTime.Now.ToString("ddMMyyyyHHmmss");

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.Background(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Tahoma"));

                page.Header()
                    .Text("My product")
                    .SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .PaddingHorizontal(2, Unit.Millimetre)
                    .Border(1)
                    .Table(async table => {
                        table.ColumnsDefinition(Columns =>{
                            Columns.ConstantColumn(40);
                            // Columns.RelativeColumn();
                            Columns.RelativeColumn();
                            Columns.ConstantColumn(50);
                            Columns.ConstantColumn(50);
                            Columns.ConstantColumn(50);
                            Columns.RelativeColumn();
                        });
                        table.Header(header =>{
                            header.Cell().Element(CellStyle).AlignCenter().Text("#"); 
                            // header.Cell().Element(CellStyle).Text("Images");
                            header.Cell().Element(CellStyle).AlignCenter().Text("Products");
                            header.Cell().Element(CellStyle).AlignCenter().Text("Price");
                            header.Cell().Element(CellStyle).AlignCenter().Text("QTY");
                            header.Cell().Element(CellStyle).AlignCenter().Text("Cat");
                            header.Cell().Element(CellStyle).AlignCenter().Text("Date");

                            static IContainer CellStyle(IContainer container){
                                return container.DefaultTextStyle(x=>x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                            }
                        });

                        // List<Product> products = new List<Product>();
                        // products = await _context.Products.ToListAsync();
                        // Console.WriteLine(products.ToString());

                        foreach(var item in _context.Products.ToList()){
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.ProductID.ToString());
                            // table.Cell().Element(CellStyle).Image(item.ProductPicture.(););
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.ProductName.ToString());
                            table.Cell().Element(CellStyle).AlignRight().Text(item.UnitPrice.ToString());
                            table.Cell().Element(CellStyle).AlignRight().Text(item.UnitInStock.ToString());
                            table.Cell().Element(CellStyle).AlignRight().Text(item.CategoryID.ToString());
                            table.Cell().Element(CellStyle).AlignCenter().Text(item.CreatedDate.ToString());

                            static IContainer CellStyle(IContainer container){
                                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(3).PaddingBottom(5);
                            }
                        }
                    });

                    // .Column(x =>
                    // {
                    //     x.Spacing(20);

                    //     x.Item().Text(_context.Products.ToListAsync());
                    //     // x.Item().Image(Placeholders.Image(200, 100)); //Picture
                    // });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        })
        .GeneratePdf(Url.Content("wwwroot/Reports/"+reportname+".pdf"));

        // return View("~/Views/Backend/ReportPDF.cshtml", await _context.Products.ToListAsync());
        return Redirect (Url.Content("~/Reports/"+reportname+".pdf"));
    }



    public IActionResult Dashboard()
    {
        return View();      
    }

    //อ่านข้อมูลสินค้าทั้งหมด
    //GET: Products
    public async Task<IActionResult> Product()
    {
        return View("~/Views/Backend/Product.cshtml", await _context.Products.ToListAsync());
    }

    public IActionResult Logout()
    {
        //Clear Session
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Frontend");
    }

}
