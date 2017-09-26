using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class ImageResult: ActionResult
    {
        byte[] imageContent;
        string contentType;

        public ImageResult(byte[] imageContent, string contentType)
        {
            this.imageContent = imageContent;
            this.contentType = contentType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = this.contentType;
            if (this.imageContent != null)
                context.HttpContext.Response.BinaryWrite(imageContent);
        }
    }
}