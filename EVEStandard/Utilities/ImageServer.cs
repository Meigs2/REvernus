namespace EVEStandard.Utilities
{
    /*
     * You can use this service to obtain images related to entities in New Eden. At this time, it is possible to get alliance logos, corp logos, 
     *      character portraits, faction logos, ship renders and inventory type icons in various resolutions.
     *  Corporation logos, alliance logos, inventory type icons and ship renders are returned as transparency-enabled 32 bit PNGs. Character portraits are returned as JPEGs.
     *  If a given image is not found in the database, the service responds with a 302 Moved HTTP response and redirects the HTTP client to a generic image. If you request an image in an invalid size, you get a plain 404.
     *  You are welcome to point your clients and applications directly at the image server and use it as a CDN. You do not need to cache the images and serve them yourself.
    */
    public static class ImageServer
    {
        private const string BASE_URL = "https://imageserver.eveonline.com";

        public enum AllianceWidth { x32 = 32, x64 = 64, x128 = 128 }
        public enum CorporationWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256 }
        public enum CharacterWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256, x512 = 512, x1024 = 1024 }
        public enum FactionWidth { x32 = 32, x64 = 64, x128 = 128 }
        public enum InventoryTypesWidth { x32 = 32, x64 = 64 }
        public enum ShipAndDroneRendersWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256, x512 = 512 }

        public static string AllianceImageURL(int allianceId, AllianceWidth width)
        {
            return BASE_URL + $"/Alliance/{allianceId}_{((int)width).ToString()}.png";
        }

        public static string CorporationImageURL(int corpId, CorporationWidth width)
        {
            return BASE_URL + $"/Corporation/{corpId}_{((int)width).ToString()}.png";
        }

        public static string CharacterImageURL(int characterId, CharacterWidth width)
        {
            return BASE_URL + $"/Character/{characterId}_{((int)width).ToString()}.jpg";
        }

        public static string FactionImageURL(int factionId, FactionWidth width)
        {
            return BASE_URL + $"/Alliance/{factionId}_{((int)width).ToString()}.png";
        }

        public static string InventoryImageURL(int typeId, InventoryTypesWidth width)
        {
            return BASE_URL + $"/Type/{typeId}_{((int)width).ToString()}.png";
        }

        public static string ShipAndDroneRenderImageURL(int typeId, ShipAndDroneRendersWidth width)
        {
            return BASE_URL + $"/Render/{typeId}_{((int)width).ToString()}.png";
        }
    }
}
