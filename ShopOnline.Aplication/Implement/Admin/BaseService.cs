using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Aplication.Implement
{
    public class BaseService
    {
        protected HttpClient httpClient;

        public BaseService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:29236/");
        }
    }
}
