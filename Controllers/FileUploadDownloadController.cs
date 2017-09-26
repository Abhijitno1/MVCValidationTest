using MVCValidationTest.Infra;
using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVCValidationTest.Controllers
{
    public class FileUploadDownloadController : Controller
    {
        // GET: FileUploadDownload
        public ActionResult Index()
        {
            IEnumerable<FileModel> fileInfo = DBDataInteract.GetFilesList();
            return View(fileInfo);
        }

        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
            if (postedFile == null)
                return null; //same as returning empty result
            BinaryReader reader = new BinaryReader(postedFile.InputStream);
            byte[] filedata = new Byte[postedFile.ContentLength];
            reader.Read(filedata, 0, filedata.Length);

            FileModel newFile = new FileModel
            {
                FileName = postedFile.FileName,
                ContentType = postedFile.ContentType,
                FileData = filedata
            };
            DBDataInteract.StoreFileData(newFile);
            return RedirectToAction("Index");
        }

        public ActionResult Download(int hdnFileId)
        {          
            FileModel foundFile = DBDataInteract.GetFileData(hdnFileId);
            if (foundFile != null)
            {
                return this.File(foundFile.FileData, foundFile.ContentType, foundFile.FileName);
            }
            return new EmptyResult();
        }
    }
}