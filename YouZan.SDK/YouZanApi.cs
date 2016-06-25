using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouZan.SDK
{
    public class YouZanApi
    {
        private string _clientId;
        private string _clientSecret;
        public YouZanApi(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }
    }
}
