namespace CrudPro.Models
{
    public class GiphyData
    {
        public List<GifItem> data { get; set; }
    }

    public class GifItem
    {
        public string title { get; set; }
        public string id { get; set; }
        public Images images { get; set; }
    }

    public class Images
    {
        public ImageInfo fixed_height { get; set; }
    }

    public class ImageInfo
    {
        public string url { get; set; }
    }

}
