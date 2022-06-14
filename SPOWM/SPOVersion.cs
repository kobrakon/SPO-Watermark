using System;
using System.IO;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using UnityEngine;

namespace SPOWM
{
    class SPOVersion : MonoBehaviour
    {
        public static void ReturnVersion(out string commit, out string version)
        {
            string git;
            commit = "";
            version = "";

            var commitfile = Path.Combine(Application.dataPath, "..\\git\\release.json");
            if (File.Exists(commitfile))
            {
                using (StreamReader streamReader = new StreamReader(commitfile, Encoding.UTF8))
                {
                    git = streamReader.ReadToEnd();
                }

                var commitObject = JsonConvert.DeserializeObject<CommitObject>(git);
                commit = commitObject.sha.Substring(0, 7);
            }

            var versionfile = Path.Combine(Application.dataPath, "..\\git\\notes.json");
            if (File.Exists(versionfile))
            {
                using (StreamReader streamReader = new StreamReader(versionfile, Encoding.UTF8))
                {
                    git = streamReader.ReadToEnd();
                }

                var versiontObject = JsonConvert.DeserializeObject<VersionObject>(git);
                version = versiontObject.name;
            }
        }
    }


    public class CommitObject
    {
        public string sha { get; set; }
        public string node_id { get; set; }
        public object commit { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string comments_url { get; set; }
        public object author { get; set; }
        public object committer { get; set; }
        public object[] parents { get; set; }
        public object stats { get; set; }
        public object[] files { get; set; }
    }

    public class VersionObject
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public object author { get; set; }
        public string node_id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public object[] assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public string body { get; set; }
    }
}
