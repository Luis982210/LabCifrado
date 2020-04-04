using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab5.Clases;
namespace Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CipherController : ControllerBase
    {
        [HttpPost("ZigZag", Name = "PostCiperZigzag")]
        public void Post(string RServerPath, string newname, int key)
        {
            string WServerPath = "";
            if (RServerPath != "")
            {
                /*All the pre-compress path preparation*/
                Zig_Zag zz = new Zig_Zag();
                string ServerDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(ServerDirectory, "Cipher/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                WServerPath = path + newname + ".txt";
                /*Compress the file*/
                zz.Encode(RServerPath, WServerPath,key);                
            }
        }
        [HttpPost("Cesar", Name = "PostCiperCesar")]
        public void Post(string RServerPath, string newname, string key)
        {
            string WServerPath = "";
            if (RServerPath != "")
            {
                /*All the pre-compress path preparation*/
                Cesar cs = new Cesar();
                string ServerDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(ServerDirectory, "Cipher/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                WServerPath = path + newname + ".txt";
                /*Compress the file*/
                cs.Encode(RServerPath, WServerPath, key);
            }
        }

        [HttpPost("Spiral", Name = "PostCiperSpiral")]
        public void Post(string RServerPath, int key, string newname)
        {
            string WServerPath = "";
            if (RServerPath != "")
            {
                /*All the pre-compress path preparation*/
                spiral sp = new spiral();
                string ServerDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(ServerDirectory, "Cipher/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                WServerPath = path + newname + ".txt";
                /*Compress the file*/
                sp.Spiral(RServerPath, WServerPath, key);
            }
        }
    }
}