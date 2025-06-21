using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Channels
{
    internal class Channels
    {
        public void ChannelDefinations()
        {
            //creating unbounded channels
            var channel = Channel.CreateUnbounded<string>();

            var options = new BoundedChannelOptions(100) // Capacity of 100 items
            {
                FullMode = BoundedChannelFullMode.Wait // Wait for space to be available
            };

            //creating bounded channels
            channel = Channel.CreateBounded<string>(options);
        }
    }
}
