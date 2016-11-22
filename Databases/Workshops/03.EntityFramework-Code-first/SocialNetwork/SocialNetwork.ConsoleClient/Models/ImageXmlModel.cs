using System;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    public class ImageXmlModel
    {
        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}