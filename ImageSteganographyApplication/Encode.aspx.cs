using System;
using System.Net.Http;
using System.Web;

namespace ImageSteganographyApplication
{
    public partial class Encode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void EncodeSubmitButton_Click(object sender, EventArgs e)
        {
            int imagefilelenth = image_upload.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = image_upload.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);
            byte[] ret = null;

            //Encoding Image
            //using (var client = new Steganography.HideAndSeekClient())
            //{
            //    ret = client.hideMessage(message.Text, key.Text, imgarray, encrypt.Text);
            //}

            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync((string)Application["Api_baseAddress"] + "api/HideAndSeek/hideMessage", new
                {
                    msg = message.Text,
                    key = key.Text,
                    encryptType = encrypt.Text,
                    cover = imgarray

                }).Result.Content.ReadAsStringAsync().Result.Replace("\"", string.Empty);
                ret = Convert.FromBase64String(response);

            }

            if (ret == null)
            {
                error.Visible = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(ret.Length);

                Session.Add("Image", ret);
                Response.Redirect("DownloadImage.aspx");
            }
        }
    }
}