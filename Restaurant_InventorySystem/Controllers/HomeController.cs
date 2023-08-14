using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;
using System.Diagnostics;
using Syncfusion.XlsIO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using Syncfusion.Drawing;



namespace Restaurant_InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventorySystemContext _db;


        public HomeController(ILogger<HomeController> logger,InventorySystemContext db)
        {
            _logger = logger;
            this._db = db;
        }
        /// <summary>
        /// Display Every item in inventory
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Gf> _Gfs = _db.Gfs.ToList();
            List<Etc> _Etc = _db.Etcs.ToList();
            List<Jfc> _Jfc = _db.Jfcs.ToList();
            List<Sysco> _Sysco = _db.Syscos.ToList();

            var viewItems = new ProductCategoriesModel
            {
                gfs = _Gfs,
                etc = _Etc,
                jfc = _Jfc,
                sysco = _Sysco

            
            };

        
           

            return View(viewItems);
        }
     
        public IActionResult CreateExcel()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                //default excel version
                application.DefaultVersion = ExcelVersion.Excel2016;

                //create a workbook
                //default create 3pages in order to that set create 1 so it creates only single page
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];


                //Add a logo image
              // FileStream imageStream = new FileStream(@"C:\Mike_Work\Restaurant_InventorySystem\Restaurant_InventorySystem\wwwroot\image\mc-logo.jpg", FileMode.Open, FileAccess.Read);
               // IPictureShape shpae = worksheet.Pictures.AddPicture(1, 1, imageStream);

                //disable gridline
               // worksheet.IsGridLinesVisible = false;

                //Ente values to the cells A3

                worksheet.Range["A3"].Text = "Made By Mike Cho";
                worksheet.Range["A3"].CellStyle.Font.Bold = true;

              
                //merge cell
                worksheet.Range["B6:E6"].Merge();
                worksheet.Range["B6"].CellStyle.Font.Bold = true;
                worksheet.Range["B6"].CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.FromArgb(255,0,0);
                worksheet.Range["B6"].Text = "Status Report";
                worksheet.Range["B6"].CellStyle.Font.Size = 35;

                worksheet.Range["A10"].Text = "Name";
                worksheet.Range["A10"].CellStyle.Font.Bold = true;
                worksheet.Range["B10"].Text = "Price";
                worksheet.Range["B10"].CellStyle.Font.Bold = true;
                worksheet.Range["C10"].Text = "Supplier";
                worksheet.Range["C10"].CellStyle.Font.Bold = true;

                List<Gf> _Gfs = _db.Gfs.ToList();
                PopulateWorksheet(worksheet, 11, _Gfs, "GFS",'A','B','C');


                worksheet.Range["E10"].Text = "Name";
                worksheet.Range["E10"].CellStyle.Font.Bold = true;
                worksheet.Range["F10"].Text = "Price";
                worksheet.Range["F10"].CellStyle.Font.Bold = true;
                worksheet.Range["G10"].Text = "Supplier";
                worksheet.Range["G10"].CellStyle.Font.Bold = true;

                List<Jfc> _jfc = _db.Jfcs.ToList();
                PopulateWorksheet(worksheet, 11, _jfc, "JFC", 'E', 'F', 'G');

                worksheet.Range["I10"].Text = "Name";
                worksheet.Range["I10"].CellStyle.Font.Bold = true;
                worksheet.Range["J10"].Text = "Price";
                worksheet.Range["J10"].CellStyle.Font.Bold = true;
                worksheet.Range["K10"].Text = "Supplier";
                worksheet.Range["K10"].CellStyle.Font.Bold = true;

                List<Sysco> _sysco = _db.Syscos.ToList();
                PopulateWorksheet(worksheet, 11, _sysco, "Sysco", 'I', 'J', 'K');

                worksheet.Range["M10"].Text = "Name";
                worksheet.Range["M10"].CellStyle.Font.Bold = true;
                worksheet.Range["N10"].Text = "Price";
                worksheet.Range["N10"].CellStyle.Font.Bold = true;
                worksheet.Range["O10"].Text = "Supplier";
                worksheet.Range["O10"].CellStyle.Font.Bold = true;

                List<Etc> _ETC = _db.Etcs.ToList();
                PopulateWorksheet(worksheet, 11, _ETC, "ETC", 'M', 'N', 'O');


                //save the excel workbook to memorystream
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                //set the position as 0
           
                string filename = $"StatusReport.xlsx";
                //download the excel file in the browser
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");
                fileStreamResult.FileDownloadName = filename;
                
                return fileStreamResult;



            }

        }
        private void PopulateWorksheet<T>(IWorksheet worksheet, int startRowIndex, List<T> items, string supplier,char first,char second,char third)
        {
            for (int i = startRowIndex; i < items.Count + startRowIndex; i++)
            {
                worksheet.Range[$"{first}{i}"].Text = items[i - startRowIndex].GetType().GetProperty("ProductName").GetValue(items[i - startRowIndex])?.ToString();
                worksheet.Range[$"{first}{i}"].CellStyle.Font.Bold = true;

                worksheet.Range[$"{second}{i}"].Text = items[i - startRowIndex].GetType().GetProperty("Price").GetValue(items[i - startRowIndex])?.ToString();
                worksheet.Range[$"{second}{i}"].CellStyle.Font.Bold = true;

                worksheet.Range[$"{third}{i}"].Text = supplier;
                worksheet.Range[$"{third}{i}"].CellStyle.Font.Bold = true;
            }
        }



        /*        [HttpPost]
                public List<object> GetData()
                {

                    List<object> dataResult = new List<object>();

                    List<string> gfsProdcuts = _db.Gfs.Select(i => i.ProductName).ToList();

                    List<string> etcProdcuts = _db.Etcs.Select(i => i.ProductName).ToList();
                    List<string> jkcProdcuts = _db.Jfcs.Select(i => i.ProductName).ToList();
                    List<string> syscoProduct = _db.Syscos.Select(i => i.ProductName).ToList();

                    dataResult.Add(gfsProdcuts);
                    dataResult.Add(etcProdcuts);
                    dataResult.Add(jkcProdcuts);
                    dataResult.Add(syscoProduct);

                    List<double> gfsPrice = _db.Gfs.Select(i => (double)i.Price).ToList();

                }
        */
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}