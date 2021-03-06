using Doctrina.ExperienceApi.Client.Http;
using Doctrina.ExperienceApi.Data;
using Doctrina.ExperienceApi.Data.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Doctrina.ExperienceApi.Server.Mvc.ActionResults
{
    public static class MultipartContentExtensions
    {
        public static void AddAttachment(this MultipartContent multipart, Attachment attachment)
        {
            if (attachment.Payload == null)
            {
                throw new ArgumentException();
            }

            var byteArrayContent = new ByteArrayContent(attachment.Payload);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(attachment.ContentType);
            byteArrayContent.Headers.Add(Data.Http.ExperienceApiHeaders.ContentTransferEncoding, "binary");
            byteArrayContent.Headers.Add(Data.Http.ExperienceApiHeaders.XExperienceApiHash, attachment.SHA2);
            multipart.Add(byteArrayContent);
        }
    }
}