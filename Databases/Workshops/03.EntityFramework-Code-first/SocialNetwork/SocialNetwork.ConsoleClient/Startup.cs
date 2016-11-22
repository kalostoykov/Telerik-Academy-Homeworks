namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Searcher;
    using Data;
    using SocialNetwork.Data.Migrations;
    using System.Xml;
    using Models;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.IO;
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            var dbContext = new SocialNetworkDbContext();

            dbContext.Database.CreateIfNotExists();
            
            var postsPath = "./XmlFiles/Posts-Test.xml";
            var friendshipsPath = "./XmlFiles/Friendships-Test.xml";
            List<PostXmlModel> posts = GetXml<PostXmlModel>(postsPath, "Posts").ToList();
            List<FriendshipXmlModel> friendships = GetXml<FriendshipXmlModel>(friendshipsPath, "Friendships").ToList();
            
            foreach (var item in friendships)
            {
                Console.WriteLine($"{item.FirstUser.Username}");
            }
        }

        private static IEnumerable<T> GetXml<T>(string path, string root)
        {
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(root));
            List<T> result = new List<T>();
            var reader = new FileStream(path, FileMode.Open);

            using (reader)
            {
                result = (List<T>)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
