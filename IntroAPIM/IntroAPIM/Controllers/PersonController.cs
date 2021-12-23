using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPIM.Controllers
{
    public class PersonController : ApiController
    {
        public List<string> GetNames() //Get requ er jonno method name er shuru te get thakte hobe
        {
            List<string> names = new List<string>();
            names.Add("Tanha");
            names.Add("Reja");
            return names;
        }

        public string Get(int id)
        {
            return "Get Name " + id;
        }

        public string Post() //Post e val or obj or compact obosthay ekta obj er data rcv hoy
        {
            return "Post Name";
        }

        //public string Post(string name) //evabe post requ pathano jay na. obj e bind kore pathate hoy
        //{
        //    return "Post Name " + name;
        //}

        public string Put(string name, int id) //Put e url id er sathe sathe data or obj o rcv hoy
        {
            return "Put Name, Id " + name + id;
        }

        public string Delete(string name, int id) //delete e same as Put
        {
            return "Delete Name, Id " + name + id;
        }
    }
}
