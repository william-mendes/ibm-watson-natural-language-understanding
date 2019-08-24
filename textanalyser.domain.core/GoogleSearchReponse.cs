using System;
using System.Collections.Generic;

namespace textanalyser.domain.core
{
    public class GoogleSearchReponse
    {
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public Pagemap pagemap { get; set; }
    }

    public class CseThumbnail
    {
        public string width { get; set; }
        public string height { get; set; }
        public string src { get; set; }
    }

    public class Metatag
    {
        public string viewport { get; set; }
        public string title { get; set; }
        public string video_type { get; set; }
        public string mobileoptimized { get; set; }
        public string handheldfriendly { get; set; }
        public string author { get; set; }
        public string news_keywords { get; set; }
        public string position { get; set; }
        public string correlationvector { get; set; }
        public string mscomcontentlocale { get; set; }
    }

    public class Article
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }

    public class CseImage
    {
        public string src { get; set; }
    }

    public class Listitem
    {
        public string item { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }

    public class Organization
    {
        public string name { get; set; }
        public string url { get; set; }
        public string sameas { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }

    public class Webpage
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string headline { get; set; }
        public string datemodified { get; set; }
    }

    public class Document
    {
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }

    public class Videoobject
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime uploaddate { get; set; }
        public string thumbnailurl { get; set; }
        public string transcript { get; set; }
    }

    public class Article2
    {
        public string text { get; set; }
        public string name { get; set; }
    }

    public class Musicgroup
    {
        public string url { get; set; }
    }

    public class Newsarticle
    {
        public string headline { get; set; }
        public string alternativeheadline { get; set; }
        public string datecreated { get; set; }
        public string datepublished { get; set; }
        public string articlebody { get; set; }
    }

    public class Datadownload
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Pagemap
    {
        public List<CseThumbnail> cse_thumbnail { get; set; }
        public List<Metatag> metatags { get; set; }
        public List<Article> article { get; set; }
        public List<CseImage> cse_image { get; set; }
        public List<Listitem> listitem { get; set; }
        public List<Organization> organization { get; set; }
        public List<Webpage> webpage { get; set; }
        public List<Document> document { get; set; }
        public List<Videoobject> videoobject { get; set; }
        public List<Article2> Article { get; set; }
        public List<Musicgroup> musicgroup { get; set; }
        public List<Newsarticle> newsarticle { get; set; }
        public List<Datadownload> datadownload { get; set; }
    }
}