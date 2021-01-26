using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RSSReader.Model
{
    public class CData
    {
        public string ActuralString { get; set; }
    }

    public class Item
    {
        public CData Title { get; set; }

        public CData Description{ get; set; }

        public string Link { get; set; }

        private string mPubData;
        public string PubData 
        {
            get { return mPubData; }
            set 
            {
                mPubData = value;
                PublishedData = DateTime.ParseExact(mPubData, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture);
            }
        }
        public DateTime PublishedData { get; private set; }

        public string Creator { get; set; }
    }

    public class Channel
    {
        public List<Item> Items { get; set; }

        public string Link { get; set; }
    }

    public class WhetherNews
    {
        public Channel Channel { get; set; }
    }
}
