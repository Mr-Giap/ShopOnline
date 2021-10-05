//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShopAdmin.Controllers
//{
//    public class UpLoadController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult UploadImage()
//        {
//            try
//            {
//                DateTime now = DateTime.Now;
//                var files = Request.Form.Files;
//                if (files.Count == 0)
//                {
//                    return new BadRequestObjectResult(files);
//                }
//                else
//                {
//                    var file = files[0];
//                    var filename = ContentDispositionHeaderValue
//                                        .Parse(file.ContentDisposition)
//                                        .FileName
//                                        .Trim('"');

//                    var imageFolder = $@"\uploaded\images\{now.ToString("yyyyMMdd")}";
//                    var imageproject = $@"\piblog.web\wwwroot";
//                    var folder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + imageproject + imageFolder;

//                    string folderadmin = _hostingEnvironment.WebRootPath + imageFolder;

//                    if (!Directory.Exists(folder))
//                    {
//                        Directory.CreateDirectory(folder)
//;
//                    }
//                    if (!Directory.Exists(folderadmin))
//                    {
//                        Directory.CreateDirectory(folderadmin);
//                    }
//                    string filePath = Path.Combine(folder, filename);

//                    using (FileStream fs = System.IO.File.Create(filePath))
//                    {
//                        file.CopyTo(fs);
//                        fs.Flush();
//                    }

//                    string filePathAdmin = Path.Combine(folderadmin, filename);
//                    using (FileStream fs = System.IO.File.Create(filePathAdmin))
//                    {
//                        file.CopyTo(fs);
//                        fs.Flush();
//                    }
//                    return new OkObjectResult(Path.Combine(imageFolder, filename).Replace(@"\", @"/"));
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }
//    }
//}
