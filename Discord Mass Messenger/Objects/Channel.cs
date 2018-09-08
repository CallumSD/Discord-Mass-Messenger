using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Mass_Messenger.Objects
{
    public class Recipient
    {
        public string username { get; set; }
        public string discriminator { get; set; }
        public string id { get; set; }
        public string avatar { get; set; }
    }

    public class Channel
    {
        public string last_message_id { get; set; }
        public int type { get; set; }
        public string id { get; set; }
        public List<Recipient> recipients { get; set; }
    }
}
